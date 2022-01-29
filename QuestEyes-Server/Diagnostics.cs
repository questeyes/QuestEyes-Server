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
    public partial class Diagnostics : Form
    {
        public static PictureBox pictureBox;

        public Diagnostics()
        {
            InitializeComponent();
            pictureBox = pictureBox1;
        }
    }
}
