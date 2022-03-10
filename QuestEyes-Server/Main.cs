using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestEyes_Server
{ 
    public partial class Main : Form
    {
        public static readonly string storageFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\QuestEyes";

        public static DiagnosticsPanel diagnosticsWindow;
        public static Label connectionStatus;
        public static Label batteryStatus;
        public static Label firmwareVersion;
        public static Button reconnectButton;
        public static Button updateButton;
        public static RichTextBox console;

        public Main()
        {
            InitializeComponent();
            connectionStatus = conStat;
            batteryStatus = batPercentage;
            firmwareVersion = firmwareVer;
            reconnectButton = forceReconnect;
            updateButton = checkFirmUpdate;
            console = consoleBox;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OSC_SoftwareControlSystem.generateSettingsStorage();
            OSC_SoftwareControlSystem.readSettings();
            OSC_CommunicationFramework.UponOpenInitialize();
            EyeTrackingFramework.loadEyeClassifierData();
            Activated += AfterLoading;
        }

        private void AfterLoading(object sender, EventArgs e)
        {
            Activated -= AfterLoading;
            Task.Run(() =>
            {
                InterdeviceNetworkingFramework.Search();
            });
        }

        private void diagnostics_Click(object sender, EventArgs e)
        {
            if (!DiagnosticsPanel.diagnosticsOpen)
            {
                DiagnosticsPanel diagnosticsWindow = new DiagnosticsPanel();
                diagnosticsWindow.Show();
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            if (!AboutPanel.aboutOpen)
            {
                AboutPanel aboutWindow = new AboutPanel();
                aboutWindow.Show();
            }
        }

        private void forceReconnect_Click(object sender, EventArgs e)
        {
            SupportFunctions.outConn("Forcing reconnect per user request...");
            Task.Run(() =>
            {
                InterdeviceNetworkingFramework.CloseWebsocket(InterdeviceNetworkingFramework.communicationSocket);
            });
        }

        private void checkFirmUpdate_Click(object sender, EventArgs e)
        {
            if (!Updater.updaterOpen)
            {
                Updater updater = new Updater();
                updater.Show();
            }
        }

        private void resetDevice_Click(object sender, EventArgs e)
        {
            //TODO: Reset Device system
        }

        private void oscButton_Click(object sender, EventArgs e)
        {
            if (!OSCControlPanel.oscOpen)
            {
                OSCControlPanel osccontrol = new OSCControlPanel();
                osccontrol.Show();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}