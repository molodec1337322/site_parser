using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Parser
{
    class DataCleaner : IDataCleaner
    {
        /// <summary>
        /// Очищает данные от html кода в другом потоке в другом потоке
        /// </summary>
        /// <param name="rawHTMLCode"></param>
        /// <returns></returns>
        public async Task<string> CleanDataAsync(string rawHTMLCode)
        {
            return await Task.Run(() => CleanData(rawHTMLCode));
        }

        /// <summary>
        /// очищает данные от html кода
        /// </summary>
        /// <param name="rawHTMLCode"></param>
        /// <returns></returns>
        public string CleanData(string rawHTMLCode)
        {
            /*
            string regexPatternHTML = @"<[^>]*>";
            string regexPatternSpaces = @"\s+";
            string targetHTML = String.Empty;
            string targetSpaces = "\n";

            string withoutHTML = Regex.Replace(rawHTMLCode, regexPatternHTML, targetHTML);
            string result = Regex.Replace(withoutHTML, regexPatternSpaces, targetSpaces);
            return withoutHTML;
            */

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(rawHTMLCode);
            var text = doc.DocumentNode.SelectNodes("//body//text()").Select(node => node.InnerText);
            StringBuilder output = new StringBuilder();
            foreach (string line in text)
            {
                output.AppendLine(line);
            }
            string onlyText = HttpUtility.HtmlDecode(output.ToString());

            return onlyText;
        }
    }
}
