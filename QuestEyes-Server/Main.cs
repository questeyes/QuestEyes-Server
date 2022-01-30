using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestEyes_Server
{ 
    public partial class Main : Form
    {
        public Diagnostics diagnosticsWindow = new Diagnostics();
        public static Label connectionStatus;
        public static Label batteryStatus;
        public static Label firmwareVersion;
        public static Button reconnectButton;

        public Main()
        {
            InitializeComponent();
            connectionStatus = conStat;
            batteryStatus = batPercentage;
            firmwareVersion = firmwareVer;
            reconnectButton = forceReconnect;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Activated += AfterLoading;
        }

        private void AfterLoading(object sender, EventArgs e)
        {
            Activated -= AfterLoading;
            Task.Run(() =>
            {
                Networking.Search();
            });
        }

        private void checkFirmUpdate_Click(object sender, EventArgs e)
        {

        }

        private void diagnostics_Click(object sender, EventArgs e)
        {
            Diagnostics diagnosticsWindow = new Diagnostics();
            diagnosticsWindow.Show();
        }

        private void forceReconnect_Click(object sender, EventArgs e)
        {
            Networking.ws.Close();
            Networking.connected = false;
        }
    }
}
