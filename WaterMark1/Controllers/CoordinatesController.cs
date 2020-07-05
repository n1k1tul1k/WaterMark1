using System;
using System.Collections.Generic;
using System.Drawing;
using WaterMark1.Enums;
using WaterMark1.Helpers;

namespace WaterMark1.Controllers
{
    public class CoordinatesController
    {
        private string _position;
        private PositionTypeEnum _positionType;
        private readonly Bitmap _image;
        private readonly Bitmap _watermark;
        public CoordinatesController(Bitmap image, Bitmap watermark, string position)
        {
            _image = image;
            _watermark = watermark;
            _position = position;
            _positionType = GetPositionType(position);
        }

        public Point GetPoint()
        {
            return _positionType switch
            {
                PositionTypeEnum.ReservedPositionType => GetPointFromReservePosition(),
            };
        }
        private PositionTypeEnum GetPositionType(string position)
        {
            if (position.Contains(":"))
                return PositionTypeEnum.PixelsType;
            if (position.Contains(":") && position.Contains("%"))
                return PositionTypeEnum.PercentType;
            if (position.GetShortPosition().Length > 2)
                return PositionTypeEnum.ReservedPositionType;
            throw new Exception("Unreserved Type");
        }
        private PositionEnum GetReservePositionFromArgument(string argument)
        {
            Dictionary<string, PositionEnum> positions = new Dictionary<string, PositionEnum>()
            {
                {"tl", PositionEnum.TopLeft},
                {"tr", PositionEnum.TopRight},
                {"tc", PositionEnum.TopCenter},
                {"ml", PositionEnum.MiddleLeft},
                {"mr", PositionEnum.MiddleRight},
                {"bl", PositionEnum.BottomLeft},
                {"br", PositionEnum.BottomRight},
                {"bc", PositionEnum.BottomCenter},
                {"cc", PositionEnum.Center},
            };
            return positions[argument.GetShortPosition()];
        }
        private Point GetPointFromReservePosition()
        {
            var position = GetReservePositionFromArgument(_position);
            return position switch
            {
                PositionEnum.Center => new Point((_image.Width - _watermark.Width) / 2, 
                    (_image.Height - _watermark.Height) / 2),
                PositionEnum.TopLeft => new Point(0, 0),
                PositionEnum.TopRight => new Point(_image.Width - _watermark.Width, 0),
                PositionEnum.MiddleLeft => new Point(0,(_image.Height - _watermark.Height) / 2),
                PositionEnum.MiddleRight => new Point(_image.Width-_watermark.Width,(_image.Width - _watermark.Width)/2),
                PositionEnum.BottomCenter => new Point((_image.Width - _watermark.Width) / 2,_image.Height - _watermark.Height),
                //PositionEnum.BottomLeft => new Point((_image.Width - _watermark.Width) / 2,_image.Height - _watermark.Height),

                _ => Point.Empty,
            };
        }
    }
}