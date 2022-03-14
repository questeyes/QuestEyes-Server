using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public static class Updater_Software
    {
        public static async Task<Tuple<bool, string, string>> checkForUpdate()
        {
            string downloadedInfo;
            Updater.SoftwareStatusLabel.Text = "Checking for software updates...";
            try
            {
                Uri softwareInfo = new("https://cdn.stevenwheeler.co.uk/QuestEyes/Software/info");
                downloadedInfo = await Updater.httpClient.GetStringAsync(softwareInfo);
            }
            catch
            {
                Updater.SoftwareProgressBar.Value = 100;
                Updater.SoftwareStatusLabel.Text = "Could not check for software update.";
                SupportFunctions.outConsole("Could not check for software update.");
                return Tuple.Create(false, "null", "null");
            }

            Updater.SoftwareProgressBar.Value = 25;
            char[] delims = new[] { '\r', '\n' };
            string[] versionInfo = downloadedInfo.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            int newversioncheck = int.Parse(versionInfo[0].Replace(".", ""));
            int oldversioncheck = int.Parse(InterdeviceNetworkingFramework.DeviceFirmware.Replace(".", ""));

            if (newversioncheck > oldversioncheck)
            {
                SupportFunctions.outConsole("Software update available: " + versionInfo[0]);
                return Tuple.Create(true, versionInfo[0], versionInfo[1]);
            }
            else
            {
                Updater.SoftwareProgressBar.Value = 100;
                Updater.SoftwareStatusLabel.Text = "Software is up to date.";
                SupportFunctions.outConsole("No new software updates are available.");
                return Tuple.Create(false, "null", "null");
            }
        }

        public static async Task beginUpdateProceedure(string newVersion, string changelog)
        {
            DialogResult updatePrompt = MessageBox.Show(
                "Update software to version " + newVersion + "?\n\n" + newVersion + " changelog: \n" + changelog,
                "Software update available", MessageBoxButtons.YesNo);
            if (updatePrompt == DialogResult.Yes)
            {
                SupportFunctions.outConsole("Software update accepted by user.");

                //download it and verify it as official and not corrupt
                using (Updater.httpClient)
                {
                    SupportFunctions.outConsole("Downloading software update file...");
                    Updater.SoftwareStatusLabel.Text = "Downloading software update...";
                    Directory.CreateDirectory(Main.storageFolder);
                    try
                    {
                        Uri softwarePackage = new("https://cdn.stevenwheeler.co.uk/QuestEyes/Software/QE_SOFT_UPDATE_latest.exe");
                        byte[] downloadedFile = await Updater.httpClient.GetByteArrayAsync(softwarePackage);
                        File.WriteAllBytes(Main.storageFolder + "\\QE_SOFT_UPDATE_latest.exe", downloadedFile);
                    }
                    catch
                    {
                        Updater.SoftwareProgressBar.Value = 100;
                        Updater.SoftwareStatusLabel.Text = "Could not download software update.";
                        SupportFunctions.outConsole("Could not download software update from server.");
                        return;
                    }
                    SupportFunctions.outConsole("File downloaded.");
                    Updater.SoftwareProgressBar.Value = 50;
                }
                SupportFunctions.outConsole("Verifying downloaded software update file...");
                Updater.SoftwareStatusLabel.Text = "Verifying downloaded software update file...";
                //verify the file here



                //TODO: VERIFY


                Updater.SoftwareProgressBar.Value = 75;


                //TODO: UPDATE SOFTWARE HERE

            }
            else if (updatePrompt == DialogResult.No)
            {
                SupportFunctions.outConsole("Software update was rejected by user.");
                Updater.SoftwareProgressBar.Value = 100;
                Updater.SoftwareStatusLabel.Text = "Software update cancelled";
            }
        }
    }
}
