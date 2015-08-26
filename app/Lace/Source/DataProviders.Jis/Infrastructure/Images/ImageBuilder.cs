using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Lace.Domain.DataProviders.Jis.Infrastructure.Images
{
    public class ImageBuilder
    {
        public byte[] BinaryImage { get; private set; }
        public Image OriginalImage { get; private set; }
        public Image NewImage { get; private set; }

        public ImageBuilder SetBinaryImage(string image)
        {
            BinaryImage = Convert.FromBase64String(image);
            return this;
        }

        public ImageBuilder SetOrignalImage()
        {
            OriginalImage = (Image) new ImageConverter().ConvertFrom(BinaryImage);
            return this;
        }

        public ImageBuilder ScaleNewImage(int maxWidth, int maxHeight)
        {
            var x = (double) maxWidth/OriginalImage.Width;
            var y = (double) maxHeight/OriginalImage.Height;
            var ratio = Math.Min(x, y);

            var newWidth = (int) (OriginalImage.Width*ratio);
            var newHeight = (int) (OriginalImage.Height*ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(OriginalImage, 0, 0, newWidth, newHeight);
            }

            NewImage = newImage;

            return this;
        }

        public ImageBuilder ConvertToBinary()
        {
            BinaryImage = (byte[]) new ImageConverter().ConvertTo(NewImage, typeof (byte[]));
            return this;
        }

        public ImageBuilder ConvertToJpg()
        {
            using (var stream = new MemoryStream())
            {
                NewImage.Save(stream,ImageFormat.Jpeg);
                BinaryImage = stream.ToArray();
            }

            return this;
        }
    }
}
