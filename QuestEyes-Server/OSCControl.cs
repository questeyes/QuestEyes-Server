using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class OSCControl : Form
    {

        public static bool oscOpen;

        public OSCControl()
        {
            InitializeComponent();
        }

        private void OSCControl_Load(object sender, EventArgs e)
        {
            oscOpen = true;
            //check the saved states of the OSC control
            foreach (var setting in OSCCommunicationFramework.OSCSettings.ToList())
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
                int index = OSCCommunicationFramework.OSCSettings.FindIndex(setting => setting.Name == "VRC");
                OSCCommunicationFramework.OSCSettings[index] = new OSCCommunicationFramework.OSCSetting { Name = OSCCommunicationFramework.OSCSettings[index].Name, Port = OSCCommunicationFramework.OSCSettings[index].Port, State = "0" };
                OSCCommunicationFramework.storeSettings();
            }
            else if (vrcCheckBox.Checked == true) //if checked
            {
                int index = OSCCommunicationFramework.OSCSettings.FindIndex(setting => setting.Name == "VRC");
                OSCCommunicationFramework.OSCSettings[index] = new OSCCommunicationFramework.OSCSetting { Name = OSCCommunicationFramework.OSCSettings[index].Name, Port = OSCCommunicationFramework.OSCSettings[index].Port, State = "1" };
                OSCCommunicationFramework.storeSettings();
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
                int index = OSCCommunicationFramework.OSCSettings.FindIndex(setting => setting.Name == "Custom");
                OSCCommunicationFramework.OSCSettings[index] = new OSCCommunicationFramework.OSCSetting { Name = OSCCommunicationFramework.OSCSettings[index].Name, Port = OSCCommunicationFramework.OSCSettings[index].Port, State = "0" };
                OSCCommunicationFramework.storeSettings();
            }
            if (customCheckBox.Checked == true) {
                if (customPortBox.Text.Length == 0)
                {
                    MessageBox.Show("Custom port cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customCheckBox.Checked = false;
                }
                else
                {
                    int index = OSCCommunicationFramework.OSCSettings.FindIndex(setting => setting.Name == "Custom");
                    OSCCommunicationFramework.OSCSettings[index] = new OSCCommunicationFramework.OSCSetting { Name = OSCCommunicationFramework.OSCSettings[index].Name, Port = customPortBox.Text, State = "1" };
                    OSCCommunicationFramework.storeSettings();
                }
            }
        }

        private void customPortBox_TextChanged(object sender, EventArgs e)
        {
            if (customCheckBox.Checked == true)
            {
                int index = OSCCommunicationFramework.OSCSettings.FindIndex(setting => setting.Name == "Custom");
                OSCCommunicationFramework.OSCSettings[index] = new OSCCommunicationFramework.OSCSetting { Name = OSCCommunicationFramework.OSCSettings[index].Name, Port = customPortBox.Text, State = "1" };
                OSCCommunicationFramework.storeSettings();
            }
        }
    }
}
