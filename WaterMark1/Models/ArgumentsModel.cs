using System.IO;
using CommandLineParser.Arguments;

namespace WaterMark1.Models
{
    public class ArgumentsModel
    {
        [DirectoryArgument('d', "directory", DirectoryMustExist = true)]
        public DirectoryInfo InputDirectory;

        [FileArgument('m', "mark", FileMustExist = true)]
        public FileInfo InputMarkFile { get; set; }

        [ValueArgument(typeof(string), 'p', "place")]
        public string Place { get; set; }

        [ValueArgument(typeof(int), 'o', "opacity", DefaultValue = 100)]
        public int Opacity { get; set; }
    }
}