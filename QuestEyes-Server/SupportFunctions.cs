using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    class SupportFunctions
    {
        public static void outConn(string msg)
        {
            Main.console.Invoke((MethodInvoker)delegate
            {
                if (!string.IsNullOrWhiteSpace(Main.console.Text))
                {
                    Main.console.AppendText("\r\n" + msg);
                }
                else
                {
                    Main.console.AppendText(msg);
                }
                Main.console.ScrollToCaret();
            });
        }

        public static void DiagnosticsUpdateTrue(Bitmap truePic)
        {
            Task.Run(() =>
            { //decode the binary and display the image in diagnostics
                try
                {
                    Diagnostics.truePicture.Invoke((MethodInvoker)delegate
                    {
                        Diagnostics.truePicture.Image = truePic;
                    });
                    Diagnostics.decodeError.Invoke((MethodInvoker)delegate
                    {
                        Diagnostics.decodeError.Visible = false;
                    });
                }
                catch
                {
                    //ignore error, form is likely closed
                }
            });
        }

        public static void DiagnosticsUpdateLeft(Bitmap left)
        {
            Task.Run(() =>
            { //decode the binary and display the image in diagnostics
                try
                {
                    Diagnostics.leftPicture.Invoke((MethodInvoker)delegate
                    {
                        Diagnostics.leftPicture.Image = left;
                    });
                    Diagnostics.decodeError.Invoke((MethodInvoker)delegate
                    {
                        Diagnostics.decodeError.Visible = false;
                    });
                }
                catch
                {
                    //ignore error, form is likely closed
                }
            });
        }

        public static void DiagnosticsUpdateRight(Bitmap right)
        {
            Task.Run(() =>
            { //decode the binary and display the image in diagnostics
                try
                {
                    Diagnostics.rightPicture.Invoke((MethodInvoker)delegate
                    {
                        Diagnostics.rightPicture.Image = right;
                    });
                    Diagnostics.decodeError.Invoke((MethodInvoker)delegate
                    {
                        Diagnostics.decodeError.Visible = false;
                    });
                }
                catch
                {
                    //ignore error, form is likely closed
                }
            });
        }
    }
}
