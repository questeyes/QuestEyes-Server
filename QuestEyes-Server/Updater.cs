using System;
using System.Net;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class Updater : Form
    {
        public static bool updaterOpen;
        public static ProgressBar firmwareProgressBar;
        public static ProgressBar softwareProgressBar;
        public static Label firmwareStatusLabel;
        public static Label softwareStatusLabel;
        public static Button closeButton;

        public Updater()
        {
            InitializeComponent();
            firmwareProgressBar = firmwareUpdateProgressBar;
            softwareProgressBar = softwareUpdateProgressBar;
            firmwareStatusLabel = firmwareUpdateStageLabel;
            softwareStatusLabel = softwareUpdateStageLabel;
            closeButton = updateClose;
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            updaterOpen = true;
            Main.reconnectButton.Invoke((MethodInvoker)delegate
            {
                Main.reconnectButton.Enabled = false;
            });
        }

        private void updateClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Updater_FormClosing(object sender, FormClosingEventArgs e)
        {
            updaterOpen = false;
            Main.reconnectButton.Invoke((MethodInvoker)delegate
            {
                Main.reconnectButton.Enabled = true;
            });
        }

        private async void Updater_Shown(object sender, EventArgs e)
        {
            SupportFunctions.outConsole("Connecting to server to check for updates...");
            //check if updates are available at cdn.stevenwheeler.co.uk
            using (var webClient = new WebClient())
            {
                //check for FIRMWARE UPDATE (/QuestEyes/Firmware)
                (bool firmwareUpdateAvailable, string firmwareVersion, string firmwareChanges) = Updater_Firmware.checkForUpdate(webClient);
                if (firmwareUpdateAvailable) {
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
}