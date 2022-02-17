using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class Updater : Form
    {
        public static bool updaterOpen;
        private string downloadedInfo;
        private string[] versionInfo;
        public static string storageFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\QuestEyes";

        public Updater()
        {
            InitializeComponent();
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

        private void Updater_Shown(object sender, EventArgs e)
        {
            //check if an update is available at cdn.stevenwheeler.co.uk
            using (var webClient = new WebClient())
            {
                SupportFunctions.outConn("Checking for device firmware updates...");
                downloadedInfo = webClient.DownloadString("https://cdn.stevenwheeler.co.uk/QuestEyes/info");
                updateProgressBar.Value = 20;
                char[] delims = new[] { '\r', '\n' };
                versionInfo = downloadedInfo.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            }
            int newversioncheck = int.Parse(versionInfo[0].Replace(".", ""));
            int oldversioncheck = int.Parse(Networking.DeviceFirmware.Replace(".", ""));

            if (newversioncheck > oldversioncheck)
            {
                SupportFunctions.outConn("Update available: " + versionInfo[0]);
                _ = promptUserToUpdateAsync(versionInfo[0], versionInfo[1]);
            }
            else
            {
                updateProgressBar.Value = 100;
                updateStageLabel.Text = "Device is up to date.";
                SupportFunctions.outConn("No new firmware updates are available.");
            }
            
        }

        async Task delayOTAModeCheck()
        {
            await Task.Delay(1000);
        }

        private async Task promptUserToUpdateAsync(string newVersion, string changelog)
        {
            DialogResult updatePrompt = MessageBox.Show(
                "Update " + Networking.DeviceName + " from " + Networking.DeviceFirmware + " to " + newVersion + "?\n\n" + newVersion + " changelog: \n" + changelog, 
                "Update available", MessageBoxButtons.YesNo);
            if (updatePrompt == DialogResult.Yes)
            {
                SupportFunctions.outConn("Update accepted by user.");
                //put device in OTA mode
                updateStageLabel.Text = "Preparing device...";
                putDeviceInOTAMode();

                //wait here and confirm in ota mode
                await delayOTAModeCheck();

                //download it and verify it as official and not corrupt
                using (var webClient = new WebClient())
                {
                    SupportFunctions.outConn("Downloading OTA firmware file...");
                    updateStageLabel.Text = "Downloading update...";
                    Directory.CreateDirectory(storageFolder);
                    webClient.DownloadFile("https://cdn.stevenwheeler.co.uk/QuestEyes/QE_UPDATE_IMG_latest.bin", storageFolder + "\\QE_UPDATE_IMG_latest.bin");
                    SupportFunctions.outConn("File downloaded.");
                    updateProgressBar.Value = 40;
                }
                SupportFunctions.outConn("Verifying downloaded file...");
                updateStageLabel.Text = "Verifying downloaded update file...";
                //verify the file here

                updateProgressBar.Value = 60;

                if (Networking.DeviceMode == "OTA")
                {
                    //process the update on the ESP
                    await Task.Run(() =>
                    {
                        performRemoteUpdate();
                    });
                }
                else
                {
                    //error occured, tell user to reboot device
                    DialogResult otaModeError = MessageBox.Show(
                    "Could not put device in OTA mode.\nPlease reboot device and try again.",
                    "OTA Mode error", MessageBoxButtons.OK);
                    updateProgressBar.Value = 100;
                    updateStageLabel.Text = "Update cancelled";
                    updateClose.Enabled = true;
                }
            }
            else if (updatePrompt == DialogResult.No)
            {
                SupportFunctions.outConn("Update was rejected by user.");
                updateProgressBar.Value = 100;
                updateStageLabel.Text = "Update cancelled";
                return;
            }
        }

        private void putDeviceInOTAMode()
        {
            updateClose.Enabled = false;
            SupportFunctions.outConn("Beginning OTA update of connected device...");
            SupportFunctions.outConn("Putting device into OTA mode...");
            Networking.communicationSocket.Send("OTA_MODE");
        }

        private void performRemoteUpdate()
        {
            SupportFunctions.outConn("Transferring OTA file to device...");
            updateStageLabel.Invoke((MethodInvoker)delegate
            {
                updateStageLabel.Text = "Transferring to device...";
            });
            byte[] filebuffer = File.ReadAllBytes(storageFolder + "\\QE_UPDATE_IMG_latest.bin");
            SupportFunctions.outConn("File length: " + filebuffer.Length);
            Networking.communicationSocket.Send(filebuffer);
            SupportFunctions.outConn("File transferred.");
            //delete the file off the PC as its no longer required
            File.Delete(storageFolder + "\\QE_UPDATE_IMG_latest.bin");
            SupportFunctions.outConn("Cleaned up unnecessary files.");
            //device will take care of the rest and send websocket commands with progress
            SupportFunctions.outConn("Device is installing update...");
            updateStageLabel.Invoke((MethodInvoker)delegate
            {
                updateProgressBar.Value = 80;
                updateStageLabel.Text = "Installing...";
            });
        }
    }
}