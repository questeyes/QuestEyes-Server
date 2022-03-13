using System;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class AboutPanel : Form
    {
        private static bool aboutOpen;

        public static bool AboutOpen { get => aboutOpen; set => aboutOpen = value; }

        public AboutPanel()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            AboutOpen = true;
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            AboutOpen = false;
        }
    }
}
