using System.Drawing;
using WaterMark1.Enums;
using WaterMark1.Models;

namespace WaterMark1.Controllers
{
    public class ImageController
    {
        private readonly ArgumentsModel _arguments;
        private readonly CoordinatesController _controller;

        public ImageController(ArgumentsModel arguments, CoordinatesController controller)
        {
            _arguments = arguments;
            _controller = controller;
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