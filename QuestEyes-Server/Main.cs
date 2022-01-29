using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace QuestEyes_Server
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Create websocket client instance
            //CHANGE THE IP TO BE PART OF THE SEARCH SYSTEM
            string url = "ws://192.168.1.237:81";
            WebSocket ws = new WebSocket(url);

            ws.OnMessage += Ws_OnMessage;
            ws.OnClose += Ws_OnClose;

            Console.WriteLine("Attempting to connect to " + url);
            ws.Connect();
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("Received: " + e.Data);
            if (e.IsBinary == false) //Message from system
            {
                //IF FIRMWARE_VER, TREAT AS FIRMWARE VERSION
                //IF EXCESSIVE_FRAME_FAILURE, TREAT AS DEVICE ERROR, DISCONNECT AND EXPECT REBOOT
                if (e.Data.Contains("FIRMWARE_VER"))
                {
                    string[] split = e.Data.Split(' ');
                    Console.WriteLine("Successful connection confirmed.");
                    conStat.Invoke((MethodInvoker)delegate
                    {
                        conStat.Text = "Connected";
                        conStat.ForeColor = Color.Green;
                    });
                    firmwareVer.Invoke((MethodInvoker)delegate
                    {
                        firmwareVer.Text = "Firmware version: " + split[1];
                    });
                }
            }
            else //Image from system
            {

            }
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            Console.WriteLine("Connection was lost or couldn't be established");
            conStat.Invoke((MethodInvoker)delegate
            {
                conStat.ForeColor = Color.FromArgb(192, 0, 0);
                conStat.Text = "Disconnected";
            });
        }
    }
}
