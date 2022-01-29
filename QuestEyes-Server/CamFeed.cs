using System.Data.Linq;
using System.IO;
using System.Windows.Media.Imaging;

namespace QuestEyes_Server
{
    class CamFeed
    {
        public static BitmapImage Decode(Binary data)
        {
            byte[] buffer = data.ToArray();
            MemoryStream stream = new MemoryStream(buffer);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
    }
}
