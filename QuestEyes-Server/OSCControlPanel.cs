using System;
using System.Linq;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class OSCControlPanel : Form
    {

        public static bool oscOpen;

        public OSCControlPanel()
        {
            InitializeComponent();
        }

        private void OSCControl_Load(object sender, EventArgs e)
        {
            oscOpen = true;
            //check the saved states of the OSC control
            foreach (var setting in OSC_SoftwareControlSystem.OSCSettings.ToList())
            {
                if (setting.Name == "VRC")
                {
                    if (setting.State == "1")
                    {
                        vrcCheckBox.Checked = true;
                    }
                }
                if (setting.Name == "Custom")
                {
                    if (setting.Port !=  "0")
                    {
                        customPortBox.Text = setting.Port;
                    }
                    if (setting.State == "1")
                    {
                        customCheckBox.Checked = true;
                    }
                }
            }
        }

        private void OSCControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            oscOpen = false;
        }

        private void vrcCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vrcCheckBox.Checked == false) //if unchecked
            {
                int index = OSC_SoftwareControlSystem.OSCSettings.FindIndex(setting => setting.Name == "VRC");
                OSC_SoftwareControlSystem.OSCSettings[index] = new OSC_SoftwareControlSystem.OSCSetting { Name = OSC_SoftwareControlSystem.OSCSettings[index].Name, Port = OSC_SoftwareControlSystem.OSCSettings[index].Port, State = "0" };
                OSC_SoftwareControlSystem.storeSettings();
            }
            else if (vrcCheckBox.Checked == true) //if checked
            {
                int index = OSC_SoftwareControlSystem.OSCSettings.FindIndex(setting => setting.Name == "VRC");
                OSC_SoftwareControlSystem.OSCSettings[index] = new OSC_SoftwareControlSystem.OSCSetting { Name = OSC_SoftwareControlSystem.OSCSettings[index].Name, Port = OSC_SoftwareControlSystem.OSCSettings[index].Port, State = "1" };
                OSC_SoftwareControlSystem.storeSettings();
                VRCHAT_OSC.InitVRCConnection();
            }
        }

        private void customPortBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void customCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (customCheckBox.Checked == false)
            {
                int index = OSC_SoftwareControlSystem.OSCSettings.FindIndex(setting => setting.Name == "Custom");
                OSC_SoftwareControlSystem.OSCSettings[index] = new OSC_SoftwareControlSystem.OSCSetting { Name = OSC_SoftwareControlSystem.OSCSettings[index].Name, Port = OSC_SoftwareControlSystem.OSCSettings[index].Port, State = "0" };
                OSC_SoftwareControlSystem.storeSettings();
            }
            if (customCheckBox.Checked == true) {
                if (customPortBox.Text.Length == 0)
                {
                    MessageBox.Show("Custom port cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customCheckBox.Checked = false;
                }
                else
                {
                    int index = OSC_SoftwareControlSystem.OSCSettings.FindIndex(setting => setting.Name == "Custom");
                    OSC_SoftwareControlSystem.OSCSettings[index] = new OSC_SoftwareControlSystem.OSCSetting { Name = OSC_SoftwareControlSystem.OSCSettings[index].Name, Port = customPortBox.Text, State = "1" };
                    OSC_SoftwareControlSystem.storeSettings();
                    CUSTOM_OSC.InitCustomConnection(int.Parse(customPortBox.Text));
                }
            }
        }

        private void customPortBox_TextChanged(object sender, EventArgs e)
        {
            if (customCheckBox.Checked == true)
            {
                int index = OSC_SoftwareControlSystem.OSCSettings.FindIndex(setting => setting.Name == "Custom");
                OSC_SoftwareControlSystem.OSCSettings[index] = new OSC_SoftwareControlSystem.OSCSetting { Name = OSC_SoftwareControlSystem.OSCSettings[index].Name, Port = customPortBox.Text, State = "1" };
                OSC_SoftwareControlSystem.storeSettings();
            }
        }
    }
}
