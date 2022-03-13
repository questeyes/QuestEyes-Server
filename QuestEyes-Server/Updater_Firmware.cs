using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public class Updater_Firmware
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
                Updater.FirmwareProgressBar.Value = 100;
                Updater.FirmwareStatusLabel.Text = "Could not check for firmware update.";
                SupportFunctions.outConsole("Could not check for firmware update.");
                return Tuple.Create(false, "null", "null");
            }

            Updater.FirmwareProgressBar.Value = 20;
            char[] delims = new[] { '\r', '\n' };
            versionInfo = downloadedInfo.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            int newversioncheck = int.Parse(versionInfo[0].Replace(".", ""));
            int oldversioncheck = int.Parse(InterdeviceNetworkingFramework.DeviceFirmware.Replace(".", ""));

            if (newversioncheck > oldversioncheck)
            {
                SupportFunctions.outConsole("Firmware update available: " + versionInfo[0]);
                return Tuple.Create(true, versionInfo[0], versionInfo[1]);
            }
            else
            {
                Updater.FirmwareProgressBar.Value = 100;
                Updater.FirmwareStatusLabel.Text = "Device is up to date.";
                SupportFunctions.outConsole("No new firmware updates are available.");
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
                SupportFunctions.outConsole("Firmware update accepted by user.");
                //put device in OTA mode
                Updater.FirmwareStatusLabel.Text = "Preparing device for update...";
                putDeviceInOTAMode();

                //wait here and confirm in ota mode
                await delayOTAModeCheck();

                //download it and verify it as official and not corrupt
                using (var webClient = new WebClient())
                {
                    SupportFunctions.outConsole("Downloading OTA firmware file...");
                    Updater.FirmwareStatusLabel.Text = "Downloading firmware update...";
                    Directory.CreateDirectory(Main.storageFolder);
                    try
                    {
                        webClient.DownloadFile("https://cdn.stevenwheeler.co.uk/QuestEyes/Firmware/QE_UPDATE_IMG_latest.bin", Main.storageFolder + "\\QE_UPDATE_IMG_latest.bin");
                    }
                    catch
                    {
                        Updater.FirmwareProgressBar.Value = 100;
                        Updater.FirmwareStatusLabel.Text = "Could not download firmware update.";
                        SupportFunctions.outConsole("Could not download firmware update from server.");
                        return;
                    }
                    SupportFunctions.outConsole("Firmware update downloaded.");
                    Updater.FirmwareProgressBar.Value = 40;
                }
                SupportFunctions.outConsole("Verifying downloaded firmware file...");
                Updater.FirmwareStatusLabel.Text = "Verifying downloaded firmware update file...";
                //verify the file here


                //TODO: VERIFY OTA FILE



                Updater.FirmwareProgressBar.Value = 60;

                if (InterdeviceNetworkingFramework.DeviceMode == "OTA")
                {
                    //process the update on the ESP
                    await Task.Run(() =>
                    {
                        _ = performRemoteUpdateAsync();
                    });
                }
                else
                {
                    //error occured, tell user to reboot device
                    DialogResult otaModeError = MessageBox.Show(
                    "Could not put device in OTA mode.\nPlease reboot device and try again.",
                    "OTA Mode error", MessageBoxButtons.OK);
                    Updater.FirmwareProgressBar.Value = 100;
                    Updater.FirmwareStatusLabel.Text = "Update cancelled";
                    Updater.CloseButton.Enabled = true;
                }
            }
            else if (updatePrompt == DialogResult.No)
            {
                SupportFunctions.outConsole("Firmware update was rejected by user.");
                Updater.FirmwareProgressBar.Value = 100;
                Updater.FirmwareStatusLabel.Text = "Firmware update cancelled.";
            }
        }

        async static Task delayOTAModeCheck()
        {
            await Task.Delay(1000);
        }

        private static void putDeviceInOTAMode()
        {
            Updater.CloseButton.Enabled = false;
            SupportFunctions.outConsole("Beginning OTA update of connected device...");
            SupportFunctions.outConsole("Putting device into OTA mode...");
            _ = InterdeviceNetworkingFramework.Send(InterdeviceNetworkingFramework.communicationSocket, "OTA_MODE");
        }

        private static async Task performRemoteUpdateAsync()
        {
            SupportFunctions.outConsole("Transferring firmware update file to device...");
            Updater.FirmwareStatusLabel.Invoke((MethodInvoker)delegate
            {
                Updater.FirmwareStatusLabel.Text = "Transferring to device...";
            });

            byte[] filebuffer = File.ReadAllBytes(Main.storageFolder + "\\QE_UPDATE_IMG_latest.bin");
            SupportFunctions.outConsole("File length: " + filebuffer.Length);

            await InterdeviceNetworkingFramework.SendData(InterdeviceNetworkingFramework.communicationSocket, filebuffer);
            SupportFunctions.outConsole("File transferred.");
            
            //delete the file off the PC as its no longer required
            File.Delete(Main.storageFolder + "\\QE_UPDATE_IMG_latest.bin");
            SupportFunctions.outConsole("Cleaned up unnecessary files.");
            //device will take care of the rest and send websocket commands with progress
            SupportFunctions.outConsole("Device is installing update...");
            Updater.FirmwareStatusLabel.Invoke((MethodInvoker)delegate
            {
                Updater.FirmwareProgressBar.Value = 80;
                Updater.FirmwareStatusLabel.Text = "Installing firmware update...";
            });


            //TODO: PROGRESS INFO

        }
    }
}
