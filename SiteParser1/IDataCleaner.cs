using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    interface IDataCleaner
    {
        Task<string> CleanDataAsync(string rawHTMLCode);

        string CleanData(string rawHTMLCode);
    }
}
