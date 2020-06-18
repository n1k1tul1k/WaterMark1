using System;
using System.Drawing;
using WaterMark1.Enums;

namespace WaterMark1.Controllers
{
    public class ImageController
    {
        public static Bitmap AddWatermarkToImage(Bitmap image,Bitmap watermark,PositionEnum position)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                int x = (image.Width - watermark.Width) / 2;
                int y = (image.Height - watermark.Height) / 2;
                g.DrawImage(watermark,x,y,watermark.Width,watermark.Height);
            }

            return image;
        }

    }
}