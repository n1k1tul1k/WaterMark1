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
                "cc" => PositionEnum.Center,
                _ => PositionEnum.Center,
            };
        }
        public Point GetPointFromPosition(PositionEnum position)
        {
            int GetCenterCoordinate(int coordinate1, int coordinate2)
            {
                return (coordinate1 - coordinate2) / 2;
            }
            
            return position switch
            {
                PositionEnum.Center => new Point((_image.Width - _watermark.Width) / 2, 
                    (_image.Height - _watermark.Height) / 2),
                PositionEnum.TopLeft => new Point(0, 0),
                PositionEnum.TopRight => new Point(_image.Width - _watermark.Width, 0),
                _ => Point.Empty,
            };
        }
    }
}