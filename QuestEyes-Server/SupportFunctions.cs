using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestEyes_Server
{
    public static class SupportFunctions
    {
        public static void outConsole(string msg)
        {
            Main.Console.Invoke((MethodInvoker)delegate
            {
                if (!string.IsNullOrWhiteSpace(Main.Console.Text))
                {
                    Main.Console.AppendText("\r\n" + msg);
                }
                else
                {
                    Main.Console.AppendText(msg);
                }
                Main.Console.ScrollToCaret();
            });
        }

        public static void DiagnosticsUpdateTrue(Bitmap truePic)
        {
            Task.Run(() =>
            { //decode the binary and display the image in diagnostics
                try
                {
                    DiagnosticsPanel.TruePicture.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.TruePicture.Image = truePic;
                    });
                    DiagnosticsPanel.DecodeError.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.DecodeError.Visible = false;
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
                    DiagnosticsPanel.LeftPicture.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.LeftPicture.Image = left;
                    });
                    DiagnosticsPanel.DecodeError.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.DecodeError.Visible = false;
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
                    DiagnosticsPanel.RightPicture.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.RightPicture.Image = right;
                    });
                    DiagnosticsPanel.DecodeError.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.DecodeError.Visible = false;
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
