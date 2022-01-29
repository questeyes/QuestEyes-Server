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
        Diagnostics diagnosticsWindow = new Diagnostics();
        public static Label connectionStatus;
        public static Label batteryStatus;
        public static Label firmwareVersion;
        public static Label leftEyeYStatus;
        public static Label leftEyeXStatus;
        public static Label rightEyeYStatus;
        public static Label rightEyeXStatus;

        public Main()
        {
            InitializeComponent();
            connectionStatus = conStat;
            batteryStatus = batPercentage;
            firmwareVersion = firmwareVer;
            leftEyeYStatus = rightDetect;
            leftEyeXStatus = leftDetect;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Activated += AfterLoading;
        }

        private void AfterLoading(object sender, EventArgs e)
        {
            this.Activated -= AfterLoading;
            string url = "ws://192.168.1.237:81";
            Networking.Connect(url);
        }

        private void checkFirmUpdate_Click(object sender, EventArgs e)
        {

        }

        private void diagnostics_Click(object sender, EventArgs e)
        {
            Diagnostics diagnosticsWindow = new Diagnostics();
            diagnosticsWindow.Show();
        }
    }
}
