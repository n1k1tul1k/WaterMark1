using System;
using System.Drawing;
using System.IO;
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
            var watermark = new Bitmap(argumentsModel.InputMarkFile.FullName);
            foreach (var image in Directory.GetFiles(argumentsModel.InputDirectory.FullName))
            {
                var bitmapImage = new Bitmap(image);
                ProcessImages(bitmapImage, watermark, argumentsModel,argumentsModel.InputMarkFile.Name,argumentsModel.Place);
            }
        }

        public static void ProcessImages(Bitmap bitmap, Bitmap watermark, ArgumentsModel argumentsModel, string fileName,string pos)
        {
            var coordinatesController = new CoordinatesController(bitmap, watermark);
            var imageController = new ImageController(argumentsModel, coordinatesController);
            var position = coordinatesController.GetPositionFromLine(pos);
            bitmap = imageController.AddWatermarkToImage(bitmap, watermark, position);
            bitmap.Save($"{fileName}.png");
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