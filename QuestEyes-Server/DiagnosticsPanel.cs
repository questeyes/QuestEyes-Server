using System;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class DiagnosticsPanel : Form
    {
        public static bool diagnosticsOpen;
        public static PictureBox truePicture;
        public static PictureBox rightPicture;
        public static PictureBox leftPicture;
        public static Label decodeError;
        public static int cannyThreshold;
        public static int circleAccThreshold;
        public static int minRad;
        public static int maxRad;
        public static int blur;

        public DiagnosticsPanel()
        {
            InitializeComponent();
            cannyThreshold = 100;
            circleAccThreshold = 65;
            minRad = 1;
            maxRad = 100;
            blur = 1;
            truePicture = truepic;
            rightPicture = rightImage;
            leftPicture = leftImage;
            decodeError = decodeErrorMessage;
        }

        private void Diagnostics_Load(object sender, System.EventArgs e)
        {
            diagnosticsOpen = true;
        }

        private void Diagnostics_FormClosing(object sender, FormClosingEventArgs e)
        {
            diagnosticsOpen = false;
            decodeError.Visible = true;
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if (textBox1.Text == "" || Int32.Parse(textBox1.Text) < 1)
            {
                cannyThreshold = 1;
            }
            else
            {
                cannyThreshold = Int32.Parse(textBox1.Text);
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || Int32.Parse(textBox2.Text) < 1)
            {
                circleAccThreshold = 1;
            }
            else
            {
                circleAccThreshold = Int32.Parse(textBox2.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || Int32.Parse(textBox3.Text) < 1)
            {
                maxRad = 1;
            }
            else
            {
                maxRad = Int32.Parse(textBox3.Text);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || Int32.Parse(textBox4.Text) < 1)
            {
                minRad = 1;
            }
            else
            {
                minRad = Int32.Parse(textBox4.Text);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || Int32.Parse(textBox5.Text) < 1)
            {
                blur = 1;
            }
            else
            {
                blur = Int32.Parse(textBox5.Text);
            }
        }
    }
}
