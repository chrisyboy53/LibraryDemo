using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Homemade
{
    public class Program
    {
        public static void Main(string[] args) {
            System.Console.WriteLine("Starting up Application");

            var host = new WebHostBuilder()
                                .UseKestrel()
                                .UseContentRoot(Directory.GetCurrentDirectory())
                                .UseStartup<Startup>()
                                .Build();

            host.Run();
            
            System.Console.WriteLine("Thanks for using the Library Application");
        }
    }
}