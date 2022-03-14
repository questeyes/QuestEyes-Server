using System;
using System.Linq;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class OSCControlPanel : Form
    {
        public static bool OscOpen { get; set; }

        public OSCControlPanel()
        {
            InitializeComponent();
        }

        private void OSCControl_Load(object sender, EventArgs e)
        {
            OscOpen = true;
            //check the saved states of the OSC control
            foreach (var setting in OSC_SoftwareControlSystem.OSCSettings.ToList())
            {
                if (setting.Name == "VRC" && setting.State == "1")
                {
                    vrcCheckBox.Checked = true;
                }
                if (setting.Name == "Custom" && setting.State == "1")
                {
                    if (setting.Port !=  "0")
                    {
                        customPortBox.Text = setting.Port;
                    }
                    customCheckBox.Checked = true;
                }
            }
        }

        private void OSCControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            OscOpen = false;
        }

        private void vrcCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!vrcCheckBox.Checked) //if unchecked
            {
                int index = OSC_SoftwareControlSystem.OSCSettings.FindIndex(setting => setting.Name == "VRC");
                OSC_SoftwareControlSystem.OSCSettings[index] = new OSC_SoftwareControlSystem.OSCSetting { Name = OSC_SoftwareControlSystem.OSCSettings[index].Name, Port = OSC_SoftwareControlSystem.OSCSettings[index].Port, State = "0" };
                OSC_SoftwareControlSystem.storeSettings();
            }
            else if (vrcCheckBox.Checked) //if checked
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
            if (!customCheckBox.Checked)
            {
                int index = OSC_SoftwareControlSystem.OSCSettings.FindIndex(setting => setting.Name == "Custom");
                OSC_SoftwareControlSystem.OSCSettings[index] = new OSC_SoftwareControlSystem.OSCSetting { Name = OSC_SoftwareControlSystem.OSCSettings[index].Name, Port = OSC_SoftwareControlSystem.OSCSettings[index].Port, State = "0" };
                OSC_SoftwareControlSystem.storeSettings();
            }
            if (customCheckBox.Checked) {
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
            if (customCheckBox.Checked)
            {
                int index = OSC_SoftwareControlSystem.OSCSettings.FindIndex(setting => setting.Name == "Custom");
                OSC_SoftwareControlSystem.OSCSettings[index] = new OSC_SoftwareControlSystem.OSCSetting { Name = OSC_SoftwareControlSystem.OSCSettings[index].Name, Port = customPortBox.Text, State = "1" };
                OSC_SoftwareControlSystem.storeSettings();
            }
        }
    }
}
