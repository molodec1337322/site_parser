using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            string regexPattern = @"<[a-z A-Z 0-9]>(.*?)</[a-z A-Z 0-9]>";
            string target = "";
            Regex regex = new Regex(regexPattern);
            string result = regex.Replace(rawHTMLCode, target);
            return result;
        }
    }
}
