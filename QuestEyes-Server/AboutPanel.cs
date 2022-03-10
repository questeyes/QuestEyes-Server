using System;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class AboutPanel : Form
    {
        public static bool aboutOpen;

        public AboutPanel()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            aboutOpen = true;
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            aboutOpen = false;
        }
    }
}
