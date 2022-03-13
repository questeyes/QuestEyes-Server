using System;
using System.Net;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class Updater : Form
    {
        private static bool updaterOpen;
        private static ProgressBar firmwareProgressBar;
        private static ProgressBar softwareProgressBar;
        private static Label firmwareStatusLabel;
        private static Label softwareStatusLabel;
        private static Button closeButton;

        public static bool UpdaterOpen { get => updaterOpen; set => updaterOpen = value; }
        public static ProgressBar FirmwareProgressBar { get => firmwareProgressBar; set => firmwareProgressBar = value; }
        public static ProgressBar SoftwareProgressBar { get => softwareProgressBar; set => softwareProgressBar = value; }
        public static Label FirmwareStatusLabel { get => firmwareStatusLabel; set => firmwareStatusLabel = value; }
        public static Label SoftwareStatusLabel { get => softwareStatusLabel; set => softwareStatusLabel = value; }
        public static Button CloseButton { get => closeButton; set => closeButton = value; }

        public Updater()
        {
            InitializeComponent();
            FirmwareProgressBar = firmwareUpdateProgressBar;
            SoftwareProgressBar = softwareUpdateProgressBar;
            FirmwareStatusLabel = firmwareUpdateStageLabel;
            SoftwareStatusLabel = softwareUpdateStageLabel;
            CloseButton = updateClose;
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            UpdaterOpen = true;
            Main.ReconnectButton.Invoke((MethodInvoker)delegate
            {
                Main.ReconnectButton.Enabled = false;
            });
        }

        private void updateClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Updater_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdaterOpen = false;
            Main.ReconnectButton.Invoke((MethodInvoker)delegate
            {
                Main.ReconnectButton.Enabled = true;
            });
        }

        private async void Updater_Shown(object sender, EventArgs e)
        {
            SupportFunctions.outConsole("Connecting to server to check for updates...");
            //check if updates are available at cdn.stevenwheeler.co.uk
            using var webClient = new WebClient();
            //check for FIRMWARE UPDATE (/QuestEyes/Firmware)
            (bool firmwareUpdateAvailable, string firmwareVersion, string firmwareChanges) = Updater_Firmware.checkForUpdate(webClient);
            if (firmwareUpdateAvailable)
            {
                await Updater_Firmware.beginUpdateProceedure(firmwareVersion, firmwareChanges);
            }

            //check for SOFTWARE UPDATE (/QuestEyes/Software)
            (bool softwareUpdateAvailable, string softwareVersion, string softwareChanges) = Updater_Software.checkForUpdate(webClient);
            if (softwareUpdateAvailable)
            {
                Updater_Software.beginUpdateProceedure(softwareVersion, softwareChanges);
            }
        }
    }
}