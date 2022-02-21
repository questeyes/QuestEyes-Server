using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestEyes_Server
{ 
    public partial class Main : Form
    {
        public static string storageFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\QuestEyes";

        public static Diagnostics diagnosticsWindow;
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
            OSCCommunicationFramework.generateSettingsStorage();
            OSCCommunicationFramework.readSettings();
            EyeTrackingFramework.loadEyeClassifierData();
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

        private void diagnostics_Click(object sender, EventArgs e)
        {
            if (Diagnostics.diagnosticsOpen == false)
            {
                Diagnostics diagnosticsWindow = new Diagnostics();
                diagnosticsWindow.Show();
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            if (About.aboutOpen == false)
            {
                About aboutWindow = new About();
                aboutWindow.Show();
            }
        }

        private void forceReconnect_Click(object sender, EventArgs e)
        {
            SupportFunctions.outConn("Forcing reconnect per user request...");
            Task.Run(() =>
            {
                Networking.communicationSocket.Close();
            });
        }

        private void checkFirmUpdate_Click(object sender, EventArgs e)
        {
            if (Updater.updaterOpen == false)
            {
                Updater updater = new Updater();
                updater.Show();
            }
        }

        private void resetDevice_Click(object sender, EventArgs e)
        {

        }

        private void oscButton_Click(object sender, EventArgs e)
        {
            if (OSCControl.oscOpen == false)
            {
                OSCControl osccontrol = new OSCControl();
                osccontrol.Show();
            }
        }
    }
}