using System;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class DiagnosticsPanel : Form
    {
        private static bool diagnosticsOpen;
        private static PictureBox truePicture;
        private static PictureBox rightPicture;
        private static PictureBox leftPicture;
        private static Label decodeError;
        private static int cannyThreshold;
        private static int circleAccThreshold;
        private static int minRad;
        private static int maxRad;
        private static int blur;

        public static bool DiagnosticsOpen { get => diagnosticsOpen; set => diagnosticsOpen = value; }
        public static PictureBox TruePicture { get => truePicture; set => truePicture = value; }
        public static PictureBox RightPicture { get => rightPicture; set => rightPicture = value; }
        public static PictureBox LeftPicture { get => leftPicture; set => leftPicture = value; }
        public static Label DecodeError { get => decodeError; set => decodeError = value; }
        public static int CannyThreshold { get => cannyThreshold; set => cannyThreshold = value; }
        public static int CircleAccThreshold { get => circleAccThreshold; set => circleAccThreshold = value; }
        public static int MinRad { get => minRad; set => minRad = value; }
        public static int MaxRad { get => maxRad; set => maxRad = value; }
        public static int Blur { get => blur; set => blur = value; }

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
