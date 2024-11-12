using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AOA.Actions
{
    public class ImageConverter
    {
        public static BitmapImage ConvertPhoto(byte[] arra)
        { 
            using(var i = new MemoryStream(arra))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = i;
                image.EndInit();
                return image;
            }
        }
    }
}
