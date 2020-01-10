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
            string regexPattern = @"<[^>]*>";
            string target = String.Empty;
            string result = Regex.Replace(rawHTMLCode, regexPattern, target);
            return result;
        }
    }
}
