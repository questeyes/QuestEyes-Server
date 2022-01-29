using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using WebSocketSharp;

namespace QuestEyes_Server
{
    class Networking
    {
        public static WebSocket ws;

        public static void Connect(string url)
        {
            //Create websocket client instance
            ws = new WebSocket(url);

            ws.OnMessage += Ws_OnMessage;
            ws.OnClose += Ws_OnClose;
            ws.OnError += Ws_OnError;

            ws.EmitOnPing = true;

            Console.WriteLine("Attempting to connect to " + url);
            ws.Connect();
        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.IsText) //Message from system
            {
                //IF NAME, TREAT AS DEVICE NAME
                //IF BATTERY, TREAT AS BATTERY LEVEL
                //IF FIRMWARE_VER, TREAT AS FIRMWARE VERSION
                //IF EXCESSIVE_FRAME_FAILURE, TREAT AS DEVICE ERROR, DISCONNECT AND EXPECT REBOOT
                if (e.Data.Contains("NAME"))
                {
                    Console.WriteLine("Successful connection confirmed.");
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
            Console.WriteLine("Connection was lost or couldn't be established");
            Main.connectionStatus.Invoke((MethodInvoker)delegate
            {
                Main.connectionStatus.ForeColor = Color.FromArgb(192, 0, 0);
                Main.connectionStatus.Text = "Disconnected";
            });
        }

        private static void Ws_OnError(object sender, ErrorEventArgs e)
        {
            ws.Close(1, "ERROR");
        }
    }
}
