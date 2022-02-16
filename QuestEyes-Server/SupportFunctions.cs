using System;
using System.Drawing;
using System.Windows.Media.Imaging;
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

        public static void DiagnosticsUpdate(BitmapSource receivedFrame)
        {
            Task.Run(() =>
            { //decode the binary and display the image in diagnostics
                try
                {
                    Diagnostics.pictureBox.Invoke((MethodInvoker)delegate
                    {
                        Diagnostics.pictureBox.Image = MakeNet2BitmapFromWPFBitmapSource(receivedFrame);
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

        public static Bitmap MakeNet2BitmapFromWPFBitmapSource(BitmapSource src)
        {
             try
             {
                 System.IO.MemoryStream TransportStream = new System.IO.MemoryStream();
                 BitmapEncoder enc = new BmpBitmapEncoder();
                 enc.Frames.Add(BitmapFrame.Create(src));
                 enc.Save(TransportStream);
                 return new Bitmap(TransportStream);
             }
             catch { SupportFunctions.outConn("Could not decode image"); return null; }
        }
    }
}
