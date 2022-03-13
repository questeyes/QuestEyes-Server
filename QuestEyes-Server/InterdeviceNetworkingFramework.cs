using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Timers;
using System;
using System.Threading;
using System.IO;

namespace QuestEyes_Server
{
    class InterdeviceNetworkingFramework
    {
        /** 
         * PORTS:
         *  7579 device discovery port
         *  7580 command/ota/stream socket
        **/
        public static UdpClient discoverPort;
        public static ClientWebSocket communicationSocket;

        public static string url = null;
        public static bool connected = false;
        public static bool attemptingConnect = false;
        public static System.Timers.Timer heartbeatTimer;
        public static System.Timers.Timer connectionTimeoutTimer;

        public static string packet = null;
        public static string[] packetInfo = Array.Empty<string>();

        private static string DeviceIP;
        public static string DeviceName;
        public static string DeviceFirmware;
        public static string DeviceMode = "NORMAL";

        public static async void Search()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    while (!connected && !attemptingConnect)
                    {
                        SupportFunctions.outConsole("Searching for device...");
                        Main.ReconnectButton.Invoke((MethodInvoker)delegate
                        {
                            Main.ReconnectButton.Enabled = false;
                            Main.UpdateButton.Enabled = false;
                        });
                        packet = null;
                        packetInfo = Array.Empty<string>();
                        discoverPort = new UdpClient(7579);
                        var receivedResults = await discoverPort.ReceiveAsync();
                        packet += Encoding.ASCII.GetString(receivedResults.Buffer);
                        packetInfo = packet.Split(new char[] { ':' });
                        if (packetInfo[0] == ("QUESTEYE_REQ_CONN"))
                        {
                            discoverPort.Close();
                            attemptingConnect = true;
                            string hostname = packetInfo[1];
                            DeviceIP = packetInfo[2];
                            SupportFunctions.outConsole("Detected " + hostname);
                            SupportFunctions.outConsole("Attempting connection to " + hostname);
                            url = "ws://" + DeviceIP + ":7580";
                            communicationSocket = new ClientWebSocket();
                            await ConnectAsync(url);
                        }
                    }
                }
            });
        }

        public static async Task ConnectAsync(string url)
        {
            Main.ConnectionStatus.Invoke((MethodInvoker)delegate
            {
                Main.ConnectionStatus.Text = "Connecting...";
                Main.ConnectionStatus.ForeColor = Color.DarkOrange;
            });

            connectionTimeoutTimer = new System.Timers.Timer(10000);
            connectionTimeoutTimer.Elapsed += OnConnectionTimeout;
            connectionTimeoutTimer.AutoReset = true;
            connectionTimeoutTimer.Enabled = true;

            try
            {
                await communicationSocket.ConnectAsync(new Uri(url), CancellationToken.None);
            } catch
            {
                //ignore
            }
            
            do {
                try
                {
                    await Receive(communicationSocket);
                } catch
                {
                    CloseCommunicationSocket(communicationSocket);
                }
            } while (connected);
        }

        private static void OnConnectionTimeout(object sender, ElapsedEventArgs e)
        {
            //connection failed within 10 seconds...
            connectionTimeoutTimer.Stop();
            connectionTimeoutTimer.Close();
            SupportFunctions.outConsole("ERROR: Failed to establish connection to device.");
            communicationSocket.Abort();
            communicationSocket.Dispose();
            attemptingConnect = false;
        }

        public static async Task Send(ClientWebSocket socket, string data) => await socket.SendAsync(Encoding.UTF8.GetBytes(data), WebSocketMessageType.Text, true, CancellationToken.None);
        public static async Task SendData(ClientWebSocket socket, byte[] data) => await socket.SendAsync(data, WebSocketMessageType.Binary, true, CancellationToken.None);

        static async Task Receive(ClientWebSocket socket)
        {
            var buffer = new ArraySegment<byte>(new byte[2048]);
            do
            {
                WebSocketReceiveResult result;
                using var ms = new MemoryStream();
                do
                {
                    result = await socket.ReceiveAsync(buffer, CancellationToken.None);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                } while (!result.EndOfMessage);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    //websocket is closed
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Websocket Closed", CancellationToken.None);
                    socket.Dispose();
                    return;
                }

                else if (result.MessageType == WebSocketMessageType.Text)
                {
                    //message is a text message
                    await TextReceiveAsync(ms);
                    return;
                }

                else if (result.MessageType == WebSocketMessageType.Binary)
                {
                    //message is binary
                    BinaryReceive(ms);
                    return;
                }
            } while (true);
        }

        private static void OnHeartbeatFailure(object sender, ElapsedEventArgs e)
        {
            //heartbeat was failed to be received within 10 seconds...
            SupportFunctions.outConsole("ERROR: Device timed out, Disconnecting...");
            heartbeatTimer.Stop();
            heartbeatTimer.Close();
            CloseCommunicationSocket(communicationSocket);
        }

        private static async Task TextReceiveAsync(MemoryStream ms)
        {
            //IF NAME, TREAT AS DEVICE NAME
            //IF FIRMWARE_VER, TREAT AS FIRMWARE VERSION
            //IF BATTERY, TREAT AS BATTERY LEVEL
            //IF EXCESSIVE_FRAME_FAILURE, TREAT AS DEVICE ERROR, DISCONNECT AND EXPECT REBOOT

            string messageText;

            ms.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(ms, Encoding.UTF8))
                messageText = await reader.ReadToEndAsync();

            if (messageText.Contains("NAME"))
            {
                connectionTimeoutTimer.Stop();
                connectionTimeoutTimer.Close();
                SupportFunctions.outConsole("Successful connection confirmed");
                connected = true;
                attemptingConnect = false;
                heartbeatTimer = new System.Timers.Timer(10000);
                heartbeatTimer.Elapsed += OnHeartbeatFailure;
                heartbeatTimer.AutoReset = true;
                heartbeatTimer.Enabled = true;
                Main.ReconnectButton.Invoke((MethodInvoker)delegate
                {
                    Main.ReconnectButton.Enabled = true;
                    Main.UpdateButton.Enabled = true;
                });
                string[] split = messageText.Split(' ');
                Main.ConnectionStatus.Invoke((MethodInvoker)delegate
                {
                    Main.ConnectionStatus.Text = "Connected to " + split[1];
                    Main.ConnectionStatus.ForeColor = Color.Green;
                });
                DeviceName = split[1];
                return;
            }
            if (messageText.Contains("FIRMWARE_VER"))
            {
                string[] split = messageText.Split(' ');
                Main.FirmwareVersion.Invoke((MethodInvoker)delegate
                {
                    Main.FirmwareVersion.Text = "Device firmware version: " + split[1];
                });
                SupportFunctions.outConsole("Device reported firmware version " + split[1]);
                DeviceFirmware = split[1];
                return;
            }
            if (messageText.Contains("BATTERY"))
            {
                //TODO: ADD BATTERY PARSING
                return;
            }
            if (messageText.Contains("HEARTBEAT"))
            {
                heartbeatTimer.Interval = 10000;
                return;
            }
            if (messageText.Contains("EXCESSIVE_FRAME_FAILURE"))
            {
                SupportFunctions.outConsole("ERROR: Device reported excessive frame failure, disconnecting...");
                heartbeatTimer.Stop();
                heartbeatTimer.Close();
                CloseCommunicationSocket(communicationSocket);
                return;
            }
            if (messageText.Contains("OTA_MODE_ACTIVE"))
            {
                SupportFunctions.outConsole("Device has entered OTA mode.");
                Main.ConnectionStatus.Invoke((MethodInvoker)delegate
                {
                    Main.ConnectionStatus.ForeColor = Color.FromArgb(102, 0, 204);
                    Main.ConnectionStatus.Text = "Connected in OTA mode";
                });
                DeviceMode = "OTA";
            }
            else
            {
                SupportFunctions.outConsole("Invalid command received from device: " + messageText);
                return;
            }
        }

        private static void BinaryReceive(MemoryStream ms)
        {
            (int right_X, int right_Y, int left_X, int left_Y) = EyeTrackingFramework.detectEyes(ms.ToArray());
        }

        public static void CloseCommunicationSocket(WebSocket socket)
        {
            socket.Dispose();
            Main.ConnectionStatus.Invoke((MethodInvoker)delegate
            {
                Main.ConnectionStatus.ForeColor = Color.FromArgb(192, 0, 0);
                Main.ConnectionStatus.Text = "Searching...";
                Main.BatteryStatus.Text = "Battery percentage: Unknown";
                Main.FirmwareVersion.Text = "Firmware version: Unknown";
            });
            packetInfo = Array.Empty<string>();
            packet = null;
            url = null;

            connected = false;
            attemptingConnect = false;

            if (DiagnosticsPanel.DiagnosticsOpen)
            {
                DiagnosticsPanel.DecodeError.Invoke((MethodInvoker)delegate
                {
                    DiagnosticsPanel.DecodeError.Visible = true;
                });
            }
        }
    }
}
