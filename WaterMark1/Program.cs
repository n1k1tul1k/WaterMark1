using System;
using WaterMark1.Models;
using CommandParser = CommandLineParser.CommandLineParser;
namespace WaterMark1
{
    class Program 
    {
        public static void Main(string[] args)
        {
            CommandParser parser = new CommandParser();
            ArgumentsModel model = new ArgumentsModel();
            parser.ExtractArgumentAttributes(model);
            parser.ParseCommandLine(args);
            Console.WriteLine(model.Place);
        }
    }
}