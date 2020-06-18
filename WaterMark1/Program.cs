using System;
using System.Drawing;
using WaterMark1.Controllers;
using WaterMark1.Enums;
using WaterMark1.Helpers;
using WaterMark1.Models;
using CommandParser = CommandLineParser.CommandLineParser;

namespace WaterMark1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var argumentsModel = GetArguments(args);
            var value = TextHelper.ConvertPositionValue(argumentsModel.Place);
        }

        public static void ProcessImages(Bitmap bitmap,Bitmap watermark,ArgumentsModel argumentsModel)
        {
            var coordinatesController = new CoordinatesController(bitmap, watermark);
            var imageController = new ImageController(argumentsModel, coordinatesController);
            bitmap = imageController.AddWatermarkToImage(bitmap, watermark, PositionEnum.TopRight);
            bitmap.Save(@"watermarkedImage.png");
        }

        public static ArgumentsModel GetArguments(string[] args)
        {
            var parser = new CommandParser();
            var argumentsModel = new ArgumentsModel();
            parser.ExtractArgumentAttributes(argumentsModel);
            parser.ParseCommandLine(args);
            return argumentsModel;
        }
    }
}