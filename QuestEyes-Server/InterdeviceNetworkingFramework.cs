using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text;
using WebSocketSharp;
using System.Timers;
using System;

namespace QuestEyes_Server
{
    class InterdeviceNetworkingFramework
    {
        /** 
         * PORTS:
         *  7579 device discovery port
         *  7580 command/stream socket
        **/
        public static UdpClient discoverPort;
        public static WebSocket communicationSocket;

        public static string url = null;
        public static bool connected = false;
        public static bool attemptingConnect = false;
        public static System.Timers.Timer heartbeatTimer;

        public static string packet = null;
        public static string[] packetInfo = new string[0];

        private static string DeviceIP;
        public static string DeviceName;
        public static string DeviceFirmware;
        public static string DeviceMode = "NORMAL";

        public static void Search()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    while (connected == false && attemptingConnect == false)
                    {
                        SupportFunctions.outConn("Listening for device...");
                        Main.reconnectButton.Invoke((MethodInvoker)delegate
                        {
                            Main.reconnectButton.Enabled = false;
                            Main.updateButton.Enabled = false;
                        });
                        packet = null;
                        packetInfo = new string[0];
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
                            SupportFunctions.outConn("Detected " + hostname);
                            SupportFunctions.outConn("Attempting connection to " + hostname);
                            url = "ws://" + DeviceIP + ":7580";
                            Connect(url);
                        }
                    }
                }
            });
        }

        public static void Connect(string url)
        {
            Main.connectionStatus.Invoke((MethodInvoker)delegate
            {
                Main.connectionStatus.Text = "Connecting...";
                Main.connectionStatus.ForeColor = Color.DarkOrange;
            });

            //Create websocket client instance
            communicationSocket = new WebSocket(url);

            communicationSocket.OnMessage += Ws_OnMessage;
            communicationSocket.OnClose += Ws_OnClose;
            communicationSocket.OnError += Ws_OnError;

            //Attempt connection
            communicationSocket.ConnectAsync();
        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.IsText) //Message from system
            {
                //IF NAME, TREAT AS DEVICE NAME
                //IF FIRMWARE_VER, TREAT AS FIRMWARE VERSION
                //IF BATTERY, TREAT AS BATTERY LEVEL
                //IF EXCESSIVE_FRAME_FAILURE, TREAT AS DEVICE ERROR, DISCONNECT AND EXPECT REBOOT
                if (e.Data.Contains("NAME"))
                {
                    SupportFunctions.outConn("Successful connection confirmed");
                    connected = true;
                    attemptingConnect = false;
                    heartbeatTimer = new System.Timers.Timer(10000);
                    heartbeatTimer.Elapsed += OnHeartbeatFailure;
                    heartbeatTimer.AutoReset = true;
                    heartbeatTimer.Enabled = true;
                    Main.reconnectButton.Invoke((MethodInvoker)delegate
                    {
                        Main.reconnectButton.Enabled = true;
                        Main.updateButton.Enabled = true;
                    });
                    string[] split = e.Data.Split(' ');
                    Main.connectionStatus.Invoke((MethodInvoker)delegate
                    {
                        Main.connectionStatus.Text = "Connected to " + split[1];
                        Main.connectionStatus.ForeColor = Color.Green;
                    });
                    DeviceName = split[1];
                    return;
                }
                if (e.Data.Contains("FIRMWARE_VER"))
                {
                    string[] split = e.Data.Split(' ');
                    Main.firmwareVersion.Invoke((MethodInvoker)delegate
                    {
                        Main.firmwareVersion.Text = "Device firmware version: " + split[1];
                    });
                    SupportFunctions.outConn("Device reported firmware version " + split[1]);
                    DeviceFirmware = split[1];
                    return;
                }
                if (e.Data.Contains("BATTERY"))
                {

                    return;
                }
                if (e.Data.Contains("HEARTBEAT"))
                {
                    heartbeatTimer.Interval = 10000;
                    return;
                }
                if (e.Data.Contains("EXCESSIVE_FRAME_FAILURE"))
                {
                    SupportFunctions.outConn("ERROR: Device reported excessive frame failure, disconnecting...");
                    heartbeatTimer.Stop();
                    heartbeatTimer.Close();
                    communicationSocket.Close();
                    return;
                }
                if (e.Data.Contains("OTA_MODE_ACTIVE"))
                {
                    SupportFunctions.outConn("Device has entered OTA mode.");
                    Main.connectionStatus.Invoke((MethodInvoker)delegate
                    {
                        Main.connectionStatus.ForeColor = Color.FromArgb(102, 0, 204);
                        Main.connectionStatus.Text = "Connected in OTA mode";
                    });
                    DeviceMode = "OTA";
                }
                else
                {
                    SupportFunctions.outConn("Invalid command received from device: " + e.Data);
                    return;
                }
            }
            else if (e.IsBinary) //Image from system
            {
                (int right_X, int right_Y, int left_X, int left_Y) = EyeTrackingFramework.detectEyes(e.RawData);
            }
        }

        private static void OnHeartbeatFailure(object sender, ElapsedEventArgs e)
        {
            //heartbeat was failed to be received within 10 seconds...
            SupportFunctions.outConn("ERROR: Device timed out, Disconnecting...");
            heartbeatTimer.Stop();
            heartbeatTimer.Close();
            communicationSocket.Close();
        }

        private static void Ws_OnClose(object sender, CloseEventArgs e)
        {
            SupportFunctions.outConn("Disconnected from device");
            heartbeatTimer.Stop();
            heartbeatTimer.Close();
            Main.connectionStatus.Invoke((MethodInvoker)delegate
            {
                Main.connectionStatus.ForeColor = Color.FromArgb(192, 0, 0);
                Main.connectionStatus.Text = "Searching...";
                Main.batteryStatus.Text = "Battery percentage: Unknown";
                Main.firmwareVersion.Text = "Firmware version: Unknown";
            });
            packetInfo = new string[0];
            packet = null;
            url = null;

            connected = false;
            attemptingConnect = false;


            if (DiagnosticsPanel.diagnosticsOpen == true)
            {
                DiagnosticsPanel.decodeError.Invoke((MethodInvoker)delegate
                {
                    DiagnosticsPanel.decodeError.Visible = true;
                });
            }
        }

        private static void Ws_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            SupportFunctions.outConn("Socket error: " + e);
            SupportFunctions.outConn("Closing connection");
            communicationSocket.Close();
        }
    }
}
