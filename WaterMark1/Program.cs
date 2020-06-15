using System.Threading.Tasks;
using ConsoleAppFramework;
using Microsoft.Extensions.Hosting;

namespace WaterMark1
{
    class Program : ConsoleAppBase
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder().RunConsoleAppFrameworkAsync(args);
        }
    }
}