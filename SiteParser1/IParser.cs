using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser1
{
    interface IParser
    {
        Task<string> GetHTMLCode(string webPage);
    }
}
