using System.Drawing;
 using WaterMark1.Controllers;
 using WaterMark1.Enums;
 using WaterMark1.Models;
 using CommandParser = CommandLineParser.CommandLineParser;

 namespace WaterMark1
 {
     class Program
     {
         public static void Main(string[] args)
         {
             ArgumentsModel argumentsModel = GetArguments(args);
             Bitmap watermark = new Bitmap(@"c:/watermark.png");
             Bitmap bitmap = new Bitmap(@"c:/image.png");
             bitmap = ImageController.AddWatermarkToImage(bitmap, watermark, PositionEnum.center);
             bitmap.Save(@"C:/watermarkedImage.png");
         }

         public static ArgumentsModel GetArguments(string[] args)
         {
             CommandParser parser = new CommandParser();
             ArgumentsModel argumentsModel = new ArgumentsModel();
             parser.ExtractArgumentAttributes(argumentsModel);
             parser.ParseCommandLine(args);
             return argumentsModel;
         }
     }
 }