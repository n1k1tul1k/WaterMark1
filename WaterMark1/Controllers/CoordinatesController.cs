using System.Drawing;
using WaterMark1.Enums;
using WaterMark1.Helpers;

namespace WaterMark1.Controllers
{
    public class CoordinatesController
    {
        private readonly Bitmap _image;
        private readonly Bitmap _watermark;

        public CoordinatesController(Bitmap image, Bitmap watermark)
        {
            _image = image;
            _watermark = watermark;
        }

        private int GetCenterCoordinate(int coordinate1, int coordinate2)
        {
            return (coordinate1 - coordinate2) / 2;
        }

        public PositionEnum GetPositionFromLine(string line)
        {
            string validatedData = line.ConvertPositionValue();
            return validatedData switch
            {
                "tl" => PositionEnum.TopLeft,
                "tr" => PositionEnum.TopRight,
                "tc" => PositionEnum.TopCenter,
                "bl" => PositionEnum.BottomLeft,
                "br" => PositionEnum.BottomRight,
                "bc" => PositionEnum.BottomCenter,
                _ => PositionEnum.Center,
            };
        }
        public Point GetPointFromPosition(PositionEnum position)
        {
            return position switch
            {
                PositionEnum.Center => new Point(GetCenterCoordinate(_image.Width, _watermark.Width),
                    GetCenterCoordinate(_image.Height, _watermark.Height)),
                PositionEnum.TopLeft => new Point(0, 0),
                PositionEnum.TopRight => new Point(_image.Width - _watermark.Width, 0),
                _ => Point.Empty,
            };
        }
    }
}