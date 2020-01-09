using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser1
{
    static class FileWorker
    {
        /// <summary>
        /// Записывает текст в файл
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="textToWrite"></param>
        public static async void WriteToFile(string filename, string textToWrite)
        {
            string path = Environment.CurrentDirectory;

            using (FileStream fstream = new FileStream($"{path}\\{filename}", FileMode.OpenOrCreate))
            {
                byte[] arrayToWrite = Encoding.Default.GetBytes(textToWrite);
                await fstream.WriteAsync(arrayToWrite, 0, arrayToWrite.Length);
            }
        }

        /// <summary>
        /// Возвращает текст из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static async Task<string> ReadFromFileAsync(string filename)
        {
            return await Task.Run(() => ReadFromFile(filename));
        }

        private static string ReadFromFile(string filename)
        {
            string path = Environment.CurrentDirectory;

            using (FileStream fstream = new FileStream($"{path}\\{filename}", FileMode.Open))
            {
                try
                {
                    byte[] dataArray = new byte[fstream.Length];
                    fstream.ReadAsync(dataArray, 0, dataArray.Length);
                    return Encoding.Default.GetString(dataArray);
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    return "";
                }
            }
        }
    }
}
