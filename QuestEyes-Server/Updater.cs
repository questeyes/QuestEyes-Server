using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class Updater : Form
    {
        public static bool updaterOpen;
        public static ProgressBar progressBar;
        public static Label statusLabel;
        public static Button closeButton;

        public Updater()
        {
            InitializeComponent();
            progressBar = updateProgressBar;
            statusLabel = updateStageLabel;
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
            SupportFunctions.outConn("Connecting to server to check for updates...");
            //check if updates are available at cdn.stevenwheeler.co.uk
            using (var webClient = new WebClient())
            {
                //check for FIRMWARE UPDATE (/QuestEyes/Firmware)
                (bool firmwareUpdateAvailable, string firmwareVersion, string firmwareChanges) = FirmwareUpdater.checkForUpdate(webClient);
                if (firmwareUpdateAvailable) {
                    await FirmwareUpdater.beginUpdateProceedure(firmwareVersion, firmwareChanges);
                }

                //check for SOFTWARE UPDATE (/QuestEyes/Software)
                (bool softwareUpdateAvailable, string softwareVersion, string softwareChanges) = SoftwareUpdater.checkForUpdate(webClient);
                if (softwareUpdateAvailable)
                {
                    SoftwareUpdater.beginUpdateProceedure(softwareVersion, softwareChanges);
                }
            }
        }
    }

    public class FirmwareUpdater
    {
        private static string downloadedInfo;
        private static string[] versionInfo;

        public static Tuple<bool, string, string> checkForUpdate(WebClient webClient)
        {
            try
            {
                downloadedInfo = webClient.DownloadString("https://cdn.stevenwheeler.co.uk/QuestEyes/Firmware/info");
            }
            catch
            {
               Updater.progressBar.Value = 50;
               Updater.statusLabel.Text = "Could not connect to server.";
               SupportFunctions.outConn("Could not connect to update server to check for firmware update.");
               return Tuple.Create(false, "null", "null");
            }

            Updater.progressBar.Value = 10;
            char[] delims = new[] { '\r', '\n' };
            versionInfo = downloadedInfo.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            int newversioncheck = int.Parse(versionInfo[0].Replace(".", ""));
            int oldversioncheck = int.Parse(InterdeviceNetworkingFramework.DeviceFirmware.Replace(".", ""));

            if (newversioncheck > oldversioncheck)
            {
                SupportFunctions.outConn("Update available: " + versionInfo[0]);
                return Tuple.Create(true, versionInfo[0], versionInfo[1]);
            }
            else
            {
                Updater.progressBar.Value = 50;
                Updater.statusLabel.Text = "Device is up to date.";
                SupportFunctions.outConn("No new firmware updates are available.");
                return Tuple.Create(false, "null", "null");
            }
        }

        public static async Task beginUpdateProceedure(string newVersion, string changelog)
        {
            DialogResult updatePrompt = MessageBox.Show(
                "Update " + InterdeviceNetworkingFramework.DeviceName + " from " + InterdeviceNetworkingFramework.DeviceFirmware + " to " + newVersion + "?\n\n" + newVersion + " changelog: \n" + changelog,
                "Firmware update available", MessageBoxButtons.YesNo);
            if (updatePrompt == DialogResult.Yes)
            {
                SupportFunctions.outConn("Update accepted by user.");
                //put device in OTA mode
                Updater.statusLabel.Text = "Preparing device...";
                putDeviceInOTAMode();

                //wait here and confirm in ota mode
                await delayOTAModeCheck();

                //download it and verify it as official and not corrupt
                using (var webClient = new WebClient())
                {
                    SupportFunctions.outConn("Downloading OTA firmware file...");
                    Updater.statusLabel.Text = "Downloading update...";
                    Directory.CreateDirectory(Main.storageFolder);
                    try
                    {
                        webClient.DownloadFile("https://cdn.stevenwheeler.co.uk/QuestEyes/Firmware/QE_UPDATE_IMG_latest.bin", Main.storageFolder + "\\QE_UPDATE_IMG_latest.bin");
                    }
                    catch
                    {
                        Updater.progressBar.Value = 50;
                        Updater.statusLabel.Text = "Could not download OTA.";
                        SupportFunctions.outConn("Could not download OTA from server.");
                        return;
                    }
                    SupportFunctions.outConn("File downloaded.");
                    Updater.progressBar.Value = 20;
                }
                SupportFunctions.outConn("Verifying downloaded file...");
                Updater.statusLabel.Text = "Verifying downloaded update file...";
                //verify the file here


                //TODO: VERIFY OTA FILE



                Updater.progressBar.Value = 30;

                if (InterdeviceNetworkingFramework.DeviceMode == "OTA")
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
                    Updater.progressBar.Value = 50;
                    Updater.statusLabel.Text = "Update cancelled";
                    Updater.closeButton.Enabled = true;
                }
            }
            else if (updatePrompt == DialogResult.No)
            {
                SupportFunctions.outConn("Update was rejected by user.");
                Updater.progressBar.Value = 50;
                Updater.statusLabel.Text = "Update cancelled";
            }
        }

        async static Task delayOTAModeCheck()
        {
            await Task.Delay(1000);
        }

        private static void putDeviceInOTAMode()
        {
            Updater.closeButton.Enabled = false;
            SupportFunctions.outConn("Beginning OTA update of connected device...");
            SupportFunctions.outConn("Putting device into OTA mode...");
            _ = InterdeviceNetworkingFramework.Send(InterdeviceNetworkingFramework.communicationSocket, "OTA_MODE");
        }

        private static void performRemoteUpdate()
        {
            SupportFunctions.outConn("Transferring OTA file to device...");
            Updater.statusLabel.Invoke((MethodInvoker)delegate
            {
                Updater.statusLabel.Text = "Transferring to device...";
            });
            byte[] filebuffer = File.ReadAllBytes(Main.storageFolder + "\\QE_UPDATE_IMG_latest.bin");
            SupportFunctions.outConn("File length: " + filebuffer.Length);
            _ = InterdeviceNetworkingFramework.SendData(InterdeviceNetworkingFramework.communicationSocket, filebuffer);
            SupportFunctions.outConn("File transferred.");
            //delete the file off the PC as its no longer required
            File.Delete(Main.storageFolder + "\\QE_UPDATE_IMG_latest.bin");
            SupportFunctions.outConn("Cleaned up unnecessary files.");
            //device will take care of the rest and send websocket commands with progress
            SupportFunctions.outConn("Device is installing update...");
            Updater.statusLabel.Invoke((MethodInvoker)delegate
            {
                Updater.progressBar.Value = 40;
                Updater.statusLabel.Text = "Installing...";
            });


            //TODO: PROGRESS INFO

        }
    }

    public class SoftwareUpdater
    {
        private static string downloadedInfo;
        private static string[] versionInfo;

        public static Tuple<bool, string, string> checkForUpdate(WebClient webClient)
        {
            Updater.statusLabel.Text = "Checking for software updates...";
            try
            {
                downloadedInfo = webClient.DownloadString("https://cdn.stevenwheeler.co.uk/QuestEyes/Software/info");
            } catch
            {
                Updater.progressBar.Value = 50;
                Updater.statusLabel.Text = "Could not connect to update server.";
                SupportFunctions.outConn("Could not connect to update server to check for software.");
                return Tuple.Create(false, "null", "null");
            }

            Updater.progressBar.Value = 60;
            char[] delims = new[] { '\r', '\n' };
            versionInfo = downloadedInfo.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            int newversioncheck = int.Parse(versionInfo[0].Replace(".", ""));
            int oldversioncheck = int.Parse(InterdeviceNetworkingFramework.DeviceFirmware.Replace(".", ""));

            if (newversioncheck > oldversioncheck)
            {
                SupportFunctions.outConn("Update available: " + versionInfo[0]);
                return Tuple.Create(true, versionInfo[0], versionInfo[1]);
            }
            else
            {
                Updater.progressBar.Value = 100;
                Updater.statusLabel.Text = "Device is up to date.";
                SupportFunctions.outConn("No new firmware updates are available.");
                return Tuple.Create(false, "null", "null");
            }
        }

        public static void beginUpdateProceedure(string newVersion, string changelog)
        {
            DialogResult updatePrompt = MessageBox.Show(
                "Update software to version "+ newVersion + "?\n\n" + newVersion + " changelog: \n" + changelog,
                "Software update available", MessageBoxButtons.YesNo);
            if (updatePrompt == DialogResult.Yes)
            {
                SupportFunctions.outConn("Update accepted by user.");

                //download it and verify it as official and not corrupt
                using (var webClient = new WebClient())
                {
                    SupportFunctions.outConn("Downloading software update file...");
                    Updater.statusLabel.Text = "Downloading update...";
                    Directory.CreateDirectory(Main.storageFolder);
                    try
                    {
                        webClient.DownloadFile("https://cdn.stevenwheeler.co.uk/QuestEyes/Software/QE_SOFT_UPDATE_latest.exe", Main.storageFolder + "\\QE_SOFT_UPDATE_latest.exe");
                    }
                    catch
                    {
                        Updater.progressBar.Value = 100;
                        Updater.statusLabel.Text = "Could not download OTA.";
                        SupportFunctions.outConn("Could not download OTA from server.");
                        return;
                    }
                    SupportFunctions.outConn("File downloaded.");
                    Updater.progressBar.Value = 70;
                }
                SupportFunctions.outConn("Verifying downloaded file...");
                Updater.statusLabel.Text = "Verifying downloaded update file...";
                //verify the file here



                //TODO: VERIFY


                Updater.progressBar.Value = 80;


                //TODO: UPDATE SOFTWARE HERE

            }
            else if (updatePrompt == DialogResult.No)
            {
                SupportFunctions.outConn("Update was rejected by user.");
                Updater.progressBar.Value = 100;
                Updater.statusLabel.Text = "Update cancelled";
            }
        }
    }
}