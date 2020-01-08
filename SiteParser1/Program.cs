using System;
using System.Threading.Tasks;

namespace SiteParser1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Parser parser = new Parser();
            Console.WriteLine("Enter URL of web page:");
            string url = Console.ReadLine();
            string data = await parser.GetHTMLCode(url);
            FileWorker.WriteToFile("parsed_data.txt", data);
            Console.WriteLine("Done!");
            string pathToDataFile = Environment.CurrentDirectory;
            Console.WriteLine($"Parsed data there: {pathToDataFile}");
            Console.ReadKey();
        }
    }
}
