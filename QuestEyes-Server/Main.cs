using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestEyes_Server
{ 
    public partial class Main : Form
    {
        public static readonly string storageFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\QuestEyes";
        public static Label ConnectionStatus { get; set; }
        public static Label BatteryStatus { get; set; }
        public static Label FirmwareVersion { get; set; }
        public static Button ReconnectButton { get; set; }
        public static Button UpdateButton { get; set; }
        public static RichTextBox Console { get; set; }

        public Main()
        {
            InitializeComponent();
            ConnectionStatus = conStat;
            BatteryStatus = batPercentage;
            FirmwareVersion = firmwareVer;
            ReconnectButton = forceReconnect;
            UpdateButton = checkFirmUpdate;
            Console = consoleBox;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            OSC_SoftwareControlSystem.generateSettingsStorage();
            OSC_SoftwareControlSystem.readSettings();
            OSC_CommunicationFramework.LoadOSCCommunication();
            EyeTrackingFramework.loadEyeClassifierData();
            Activated += AfterLoading;
        }

        private void AfterLoading(object sender, EventArgs e)
        {
            Activated -= AfterLoading;
            Task.Run(() =>
            {
                _ = InterdeviceNetworkingFramework.Search();
            });
        }

        private void diagnostics_Click(object sender, EventArgs e)
        {
            if (!DiagnosticsPanel.DiagnosticsOpen)
            {
                DiagnosticsPanel diagnosticsWindow = new();
                diagnosticsWindow.Show();
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            if (!AboutPanel.AboutOpen)
            {
                AboutPanel aboutWindow = new();
                aboutWindow.Show();
            }
        }

        private void forceReconnect_Click(object sender, EventArgs e)
        {
            SupportFunctions.outConsole("Forcing reconnect per user request...");
            Task.Run(() =>
            {
                InterdeviceNetworkingFramework.HeartbeatTimer.Stop();
                InterdeviceNetworkingFramework.HeartbeatTimer.Close();
                InterdeviceNetworkingFramework.CloseCommunicationSocket(InterdeviceNetworkingFramework.CommunicationSocket);
            });
        }

        private void checkFirmUpdate_Click(object sender, EventArgs e)
        {
            if (!Updater.UpdaterOpen)
            {
                Updater updater = new();
                updater.Show();
            }
        }

        private void resetDevice_Click(object sender, EventArgs e)
        {
            //TODO: Reset Device system
        }

        private void oscButton_Click(object sender, EventArgs e)
        {
            if (!OSCControlPanel.OscOpen)
            {
                OSCControlPanel oscControl = new();
                oscControl.Show();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}