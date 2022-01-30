using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using WebSocketSharp;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace QuestEyes_Server
{
    class Networking
    {
        public static WebSocket ws;
        public static bool connecting = false;
        public static bool connected = false;

        public static void Search()
        {
            Task.Run(async () =>
            {
                using (var udpClient = new UdpClient(7579))
                {
                    Console.WriteLine("Listening for device...");
                    string rMessage = "";
                    string[] rArgs = new string[0];
                    while (true)
                    {
                        while (connected == false && connecting == false)
                        {
                            Main.reconnectButton.Invoke((MethodInvoker)delegate
                            {
                                Main.reconnectButton.Enabled = false;
                            });
                            var receivedResults = await udpClient.ReceiveAsync();
                            rMessage += Encoding.ASCII.GetString(receivedResults.Buffer);
                            rArgs = rMessage.Split(new char[] { ':' });
                            if (rArgs[0] == ("QUESTEYE_REQ_CONN"))
                            {
                                connecting = true;
                                string str = rArgs[2];

                                str = Regex.Replace(str, "[^0-9.]", String.Empty);
                                Console.WriteLine("Detected " + rArgs[1]);
                                Console.WriteLine("Attempting connection to " + rArgs[1]);
                                string url = "ws://" + str + ":7580";
                                try
                                {
                                    Networking.Connect(url);
                                }
                                catch
                                {
                                    Console.WriteLine("Connection error.");
                                    connecting = false;
                                }
                            }
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
            ws = new WebSocket(url);

            ws.OnMessage += Ws_OnMessage;
            ws.OnClose += Ws_OnClose;
            ws.OnError += Ws_OnError;

            ws.ConnectAsync();
        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.IsText) //Message from system
            {
                //IF NAME, TREAT AS DEVICE NAME
                //IF FIRMWARE_VER, TREAT AS FIRMWARE VERSION
                //IF BATTERY, TREAT AS BATTERY LEVEL
                //IF HEARTBEAT, TREAT AS A KEEPALIVE MESSAGE
                //IF EXCESSIVE_FRAME_FAILURE, TREAT AS DEVICE ERROR, DISCONNECT AND EXPECT REBOOT
                if (e.Data.Contains("NAME"))
                {
                    Console.WriteLine("Successful connection confirmed");
                    connected = true;
                    connecting = false;
                    Main.reconnectButton.Invoke((MethodInvoker)delegate
                    {
                        Main.reconnectButton.Enabled = true;
                    });
                    Console.WriteLine(e.Data);
                    string[] split = e.Data.Split(' ');
                    Main.connectionStatus.Invoke((MethodInvoker)delegate
                    {
                        Main.connectionStatus.Text = "Connected to " + split[1];
                        Main.connectionStatus.ForeColor = Color.Green;
                    });
                }
                if (e.Data.Contains("FIRMWARE_VER"))
                {
                    Console.WriteLine(e.Data);
                    string[] split = e.Data.Split(' ');
                    Main.firmwareVersion.Invoke((MethodInvoker)delegate
                    {
                        Main.firmwareVersion.Text = "Firmware version: " + split[1];
                    });
                }
                if (e.Data.Contains("BATTERY"))
                {

                }
                if (e.Data.Contains("HEARTBEAT"))
                {
                    
                }
                if (e.Data.Contains("EXCESSIVE_FRAME_FAILURE"))
                {

                }
            }

            else if (e.IsBinary) //Image from system
            {
                BitmapImage image = CamFeed.Decode(e.RawData);
                Diagnostics.pictureBox.Image = MakeNet2BitmapFromWPFBitmapSource(image);
            }
        }

        public static Bitmap MakeNet2BitmapFromWPFBitmapSource(BitmapSource src)
        {
            try
            {
                System.IO.MemoryStream TransportStream = new System.IO.MemoryStream();
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(src));
                enc.Save(TransportStream);
                return new Bitmap(TransportStream);
            }
            catch { Console.WriteLine("Could not convert image"); return null; }
        }

        private static void Ws_OnClose(object sender, CloseEventArgs e)
        {
            Main.connectionStatus.Invoke((MethodInvoker)delegate
            {
                Main.connectionStatus.ForeColor = Color.FromArgb(192, 0, 0);
                Main.connectionStatus.Text = "Searching...";
                Main.batteryStatus.Text = "Battery percentage: Unknown";
                Main.firmwareVersion.Text = "Firmware version: Unknown";
            });
            connecting = false;
            connected = false;
        }

        private static void Ws_OnError(object sender, ErrorEventArgs e)
        {
            ws.Close();
        }
    }
}
