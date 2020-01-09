using Parser;
using System;
using System.Threading.Tasks;

namespace SiteParser1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Parser parser = new Parser();
            DataCleaner dc = new DataCleaner();

            Console.WriteLine("Enter URL of web page:");
            string url = Console.ReadLine();
            string rawHTMLData = parser.GetHTMLCode(url);
            string cleanData = dc.CleanData(rawHTMLData);

            FileWorker.WriteToFile("raw_parsed_data.txt", rawHTMLData);
            FileWorker.WriteToFile("clean_parsed_data.txt", cleanData);
            Console.WriteLine("Done!");

            string pathToDataFile = Environment.CurrentDirectory;
            Console.WriteLine($"Parsed data there: {pathToDataFile}");

            Console.ReadKey();
        }
    }
}
