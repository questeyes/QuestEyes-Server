using System;
using System.Collections.Generic;
using System.IO;

namespace QuestEyes_Server
{
    class OSC_SoftwareControlSystem
    {
        public class OSCSetting
        {
            public string Name { get; set; }
            public string Port { get; set; }
            public string State { get; set; }
        }
        internal static List<OSCSetting> OSCSettings { get; set; }

        public static void generateSettingsStorage()
        {
            Directory.CreateDirectory(Main.storageFolder);
            if(!File.Exists(Main.storageFolder + "\\OSC_configuration.conf"))
            {
                File.WriteAllText(Main.storageFolder + "\\OSC_configuration.conf", Properties.Resources.OSCConfInternal);
            }
        }

        public static void readSettings()
        {
            OSCSettings = new List<OSCSetting>();
            var settingStream = File.ReadAllLines(Main.storageFolder + "\\OSC_configuration.conf");
            foreach (var line in settingStream)
            {
                string[] lineContent = line.Split(':');
                OSCSettings.Add(new OSCSetting { Name = lineContent[0], Port = lineContent[1], State = lineContent[2] });
            }
        }

        public static void storeSettings()
        {
            File.Delete(Main.storageFolder + "\\OSC_configuration.conf");
            foreach (OSCSetting setting in OSCSettings)
            {
                string settingOutput = $"{setting.Name}:{setting.Port}:{setting.State}";
                File.AppendAllText(Main.storageFolder + "\\OSC_configuration.conf", settingOutput + Environment.NewLine);
            }
        }
    }
}
