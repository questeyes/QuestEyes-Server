using System.Data.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace QuestEyes_Server
{
    class CamFeed
    {
        public static BitmapImage Decode(Binary data)
        {
            try
            {
                byte[] buffer = data.ToArray();
                MemoryStream stream = new MemoryStream(buffer);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
                return image;
            }
            catch
            {
                return null;
            }
        }

        /**private WriteableBitmap ChangeBrightness(WriteableBitmap source, byte change_value)
        {
            WriteableBitmap dest = new WriteableBitmap(source.PixelWidth, source.PixelHeight);

            byte[] color = new byte[4];

            using (Stream s = source.PixelBuffer.AsStream())
            {
                using (Stream d = dest.PixelBuffer.AsStream())
                {
                    // read the pixel color
                    while (s.Read(color, 0, 4) > 0)
                    {
                        // color[0] = b
                        // color[1] = g 
                        // color[2] = r
                        // color[3] = a

                        // do the adding algo per byte (skip the alpha)
                        for (int i = 0; i < 4; i++)
                        {
                            if ((int)color[i] + change_value > 255) color[i] = 255; else color[i] = (byte)(color[i] + change_value);
                        }

                        // write the new pixel color
                        d.Write(color, 0, 4);
                    }
                }
            }

            // return the new bitmap
            return dest;
        
        }**/
    }
}
