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
    public partial class About : Form
    {
        public static bool aboutOpen;

        public About()
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
