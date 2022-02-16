using System.Windows.Forms;

namespace QuestEyes_Server
{
    public partial class Diagnostics : Form
    {
        public static bool diagnosticsOpen;
        public static PictureBox pictureBox;
        public static Label decodeError;

        public Diagnostics()
        {
            InitializeComponent();
            pictureBox = pictureBox1;
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
