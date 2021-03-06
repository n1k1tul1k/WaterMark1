﻿using System;
using System.Drawing;
using System.IO;
using WaterMark1.Controllers;
using WaterMark1.Models;
using CommandParser = CommandLineParser.CommandLineParser;

namespace WaterMark1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var argumentsModel = GetArguments(args);
                var watermark = new Bitmap(argumentsModel.InputMarkFile.FullName);
                Console.WriteLine("Start image processing");
                foreach (var image in Directory.GetFiles(argumentsModel.InputDirectory.FullName))
                {
                    Console.WriteLine($"Process image:{image}");
                    var bitmapImage = new Bitmap(image);
                    ProcessImages(bitmapImage, watermark, argumentsModel, argumentsModel.InputMarkFile.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ProcessImages(Bitmap bitmap, Bitmap watermark, ArgumentsModel argumentsModel, string fileName)
        {
            var coordinatesController = new CoordinatesController(bitmap, watermark,argumentsModel.Position);
            var imageController = new ImageController(coordinatesController);
            var position = coordinatesController.GetPoint();
            var path = argumentsModel.ResultDirectory == null
                ? Environment.CurrentDirectory
                : argumentsModel.ResultDirectory.ToString();
            string fileExtension = new FileInfo(fileName).Extension;
            fileName = fileName.Replace(fileExtension, $"{fileExtension}");
            Console.WriteLine($"Save image at {fileName}");
            bitmap = imageController.AddWatermarkToImage(bitmap, watermark);
            bitmap.Save(Path.Combine(path,fileName));
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