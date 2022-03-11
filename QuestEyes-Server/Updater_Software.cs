using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public class Updater_Software
    {
        private static string downloadedInfo;
        private static string[] versionInfo;

        public static Tuple<bool, string, string> checkForUpdate(WebClient webClient)
        {
            Updater.softwareStatusLabel.Text = "Checking for software updates...";
            try
            {
                downloadedInfo = webClient.DownloadString("https://cdn.stevenwheeler.co.uk/QuestEyes/Software/info");
            }
            catch
            {
                Updater.softwareProgressBar.Value = 100;
                Updater.softwareStatusLabel.Text = "Could not check for software update.";
                SupportFunctions.outConsole("Could not check for software update.");
                return Tuple.Create(false, "null", "null");
            }

            Updater.softwareProgressBar.Value = 25;
            char[] delims = new[] { '\r', '\n' };
            versionInfo = downloadedInfo.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            int newversioncheck = int.Parse(versionInfo[0].Replace(".", ""));
            int oldversioncheck = int.Parse(InterdeviceNetworkingFramework.DeviceFirmware.Replace(".", ""));

            if (newversioncheck > oldversioncheck)
            {
                SupportFunctions.outConsole("Software update available: " + versionInfo[0]);
                return Tuple.Create(true, versionInfo[0], versionInfo[1]);
            }
            else
            {
                Updater.softwareProgressBar.Value = 100;
                Updater.softwareStatusLabel.Text = "Software is up to date.";
                SupportFunctions.outConsole("No new software updates are available.");
                return Tuple.Create(false, "null", "null");
            }
        }

        public static void beginUpdateProceedure(string newVersion, string changelog)
        {
            DialogResult updatePrompt = MessageBox.Show(
                "Update software to version " + newVersion + "?\n\n" + newVersion + " changelog: \n" + changelog,
                "Software update available", MessageBoxButtons.YesNo);
            if (updatePrompt == DialogResult.Yes)
            {
                SupportFunctions.outConsole("Software update accepted by user.");

                //download it and verify it as official and not corrupt
                using (var webClient = new WebClient())
                {
                    SupportFunctions.outConsole("Downloading software update file...");
                    Updater.softwareStatusLabel.Text = "Downloading software update...";
                    Directory.CreateDirectory(Main.storageFolder);
                    try
                    {
                        webClient.DownloadFile("https://cdn.stevenwheeler.co.uk/QuestEyes/Software/QE_SOFT_UPDATE_latest.exe", Main.storageFolder + "\\QE_SOFT_UPDATE_latest.exe");
                    }
                    catch
                    {
                        Updater.softwareProgressBar.Value = 100;
                        Updater.softwareStatusLabel.Text = "Could not download software update.";
                        SupportFunctions.outConsole("Could not download software update from server.");
                        return;
                    }
                    SupportFunctions.outConsole("File downloaded.");
                    Updater.softwareProgressBar.Value = 50;
                }
                SupportFunctions.outConsole("Verifying downloaded software update file...");
                Updater.softwareStatusLabel.Text = "Verifying downloaded software update file...";
                //verify the file here



                //TODO: VERIFY


                Updater.softwareProgressBar.Value = 75;


                //TODO: UPDATE SOFTWARE HERE

            }
            else if (updatePrompt == DialogResult.No)
            {
                SupportFunctions.outConsole("Software update was rejected by user.");
                Updater.softwareProgressBar.Value = 100;
                Updater.softwareStatusLabel.Text = "Software update cancelled";
            }
        }
    }
}
