using System;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class Updater : Form
    {
        public static bool UpdaterOpen { get; set; }
        public static ProgressBar FirmwareProgressBar { get; set; }
        public static ProgressBar SoftwareProgressBar { get; set; }
        public static Label FirmwareStatusLabel { get; set; }
        public static Label SoftwareStatusLabel { get; set; }
        public static Button CloseButton { get; set; }

        public static HttpClient httpClient { get; set; } = new();

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
            //check for FIRMWARE UPDATE (/QuestEyes/Firmware)
            (bool firmwareUpdateAvailable, string firmwareVersion, string firmwareChanges) = await Updater_Firmware.checkForUpdate();
            if (firmwareUpdateAvailable)
            {
                await Updater_Firmware.beginUpdateProceedure(firmwareVersion, firmwareChanges);
            }

            //check for SOFTWARE UPDATE (/QuestEyes/Software)
            (bool softwareUpdateAvailable, string softwareVersion, string softwareChanges) = await Updater_Software.checkForUpdate();
            if (softwareUpdateAvailable)
            {
                await Updater_Software.beginUpdateProceedure(softwareVersion, softwareChanges);
            }
        }
    }
}