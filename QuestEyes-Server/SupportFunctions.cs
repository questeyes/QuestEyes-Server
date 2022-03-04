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
                    DiagnosticsPanel.truePicture.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.truePicture.Image = truePic;
                    });
                    DiagnosticsPanel.decodeError.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.decodeError.Visible = false;
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
                    DiagnosticsPanel.leftPicture.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.leftPicture.Image = left;
                    });
                    DiagnosticsPanel.decodeError.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.decodeError.Visible = false;
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
                    DiagnosticsPanel.rightPicture.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.rightPicture.Image = right;
                    });
                    DiagnosticsPanel.decodeError.Invoke((MethodInvoker)delegate
                    {
                        DiagnosticsPanel.decodeError.Visible = false;
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
