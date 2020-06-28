using System.Drawing;
using WaterMark1.Enums;
using WaterMark1.Models;

namespace WaterMark1.Controllers
{
    public class ImageController
    {
        private readonly CoordinatesController _controller;

        public ImageController(CoordinatesController controller)
        {
            _controller = controller;
        }

        public Bitmap ChangeImageTransparent(Bitmap image, byte alpha)
        {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color imageColor = image.GetPixel(x, y);
                    Color transparentColor = Color.FromArgb(alpha,imageColor);
                    image.SetPixel(x,y,transparentColor);
                }
            }

            return resultImage;
        }

        public Bitmap AddWatermarkToImage(Bitmap image, Bitmap watermark, PositionEnum position)
        {
            using (var g = Graphics.FromImage(image))
            {
                var point = _controller.GetPointFromPosition(position);
                g.DrawImage(watermark, point.X, point.Y, watermark.Width, watermark.Height);
            }
            return image;
        }
    }
}