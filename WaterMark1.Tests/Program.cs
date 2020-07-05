using System;
using System.Diagnostics;
using System.IO;

namespace WaterMark1.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string imagesPath = Path.Combine(desktopPath, "images");
            string exePath = 
                "C:\\Users\\ddeve\\RiderProjects\\WaterMark1\\WaterMark1\\bin\\Debug\\netcoreapp3.1\\WaterMark1.exe";
            string[] positions = new[] {"tl", "tr", "tc", "ml", "mr", "bl", "br", "bc", "cc"};
            foreach (var position in positions)
            {
                string arguments = $"-d \"{imagesPath}\" -m \"{Path.Combine(desktopPath, "watermark.png")}\" -p {position}";
                Process.Start(exePath,arguments);
            }
        }
    }
}