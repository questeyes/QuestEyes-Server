using System;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class DiagnosticsPanel : Form
    {
        public static bool DiagnosticsOpen { get; set; }
        public static PictureBox TruePicture { get; set; }
        public static PictureBox RightPicture { get; set; }
        public static PictureBox LeftPicture { get; set; }
        public static Label DecodeError { get; set; }
        public static int CannyThreshold { get; set; }
        public static int CircleAccThreshold { get; set; }
        public static int MinRad { get; set; }
        public static int MaxRad { get; set; }
        public static int Blur { get; set; }

        public DiagnosticsPanel()
        {
            InitializeComponent();
            CannyThreshold = 100;
            CircleAccThreshold = 65;
            MinRad = 1;
            MaxRad = 100;
            Blur = 1;
            TruePicture = truepic;
            RightPicture = rightImage;
            LeftPicture = leftImage;
            DecodeError = decodeErrorMessage;
        }

        private void Diagnostics_Load(object sender, System.EventArgs e)
        {
            DiagnosticsOpen = true;
        }

        private void Diagnostics_FormClosing(object sender, FormClosingEventArgs e)
        {
            DiagnosticsOpen = false;
            DecodeError.Visible = true;
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if (textBox1.Text == "" || Int32.Parse(textBox1.Text) < 1)
            {
                CannyThreshold = 1;
            }
            else
            {
                CannyThreshold = Int32.Parse(textBox1.Text);
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || Int32.Parse(textBox2.Text) < 1)
            {
                CircleAccThreshold = 1;
            }
            else
            {
                CircleAccThreshold = Int32.Parse(textBox2.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || Int32.Parse(textBox3.Text) < 1)
            {
                MaxRad = 1;
            }
            else
            {
                MaxRad = Int32.Parse(textBox3.Text);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || Int32.Parse(textBox4.Text) < 1)
            {
                MinRad = 1;
            }
            else
            {
                MinRad = Int32.Parse(textBox4.Text);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || Int32.Parse(textBox5.Text) < 1)
            {
                Blur = 1;
            }
            else
            {
                Blur = Int32.Parse(textBox5.Text);
            }
        }
    }
}
