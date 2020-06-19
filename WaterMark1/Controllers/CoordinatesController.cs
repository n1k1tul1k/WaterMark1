using System;
using System.Drawing;
using WaterMark1.Enums;

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
            switch (line)
            {
                case "tl":
                    return PositionEnum.TopLeft;
                case "tr":
                    return PositionEnum.TopRight;
                case "tc":
                    return PositionEnum.TopCenter;
                case "bl":
                    return PositionEnum.BottomLeft;
                case "br":
                    return PositionEnum.BottomRight;
                case "bc":
                    return PositionEnum.BottomCenter;
                default:
                    return PositionEnum.Center;
            }
        }
        public Point GetPointFromPosition(PositionEnum position)
        {
            switch (position)
            {
                case PositionEnum.Center:
                    return new Point(GetCenterCoordinate(_image.Width, _watermark.Width),
                        GetCenterCoordinate(_image.Height, _watermark.Height));
                case PositionEnum.TopLeft:
                    return new Point(0, 0);
                case PositionEnum.TopRight:
                    return new Point(_image.Width - _watermark.Width, 0);
                default:
                    return Point.Empty;
            }
        }
    }
}