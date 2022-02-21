using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class Diagnostics : Form
    {
        public static bool diagnosticsOpen;
        public static PictureBox truePicture;
        public static PictureBox rightPicture;
        public static PictureBox leftPicture;
        public static Label decodeError;

        public Diagnostics()
        {
            InitializeComponent();
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
    }
}
