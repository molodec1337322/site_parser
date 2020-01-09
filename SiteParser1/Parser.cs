using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SiteParser1
{
    class Parser : IParser
    {
        /// <summary>
        /// Считывает HTML код с веб страницы в асинхронном режиме
        /// </summary>
        /// <param name="webPage"></param>
        /// <returns></returns>
        public async Task<string> GetHTMLCodeAsync(string webPage)
        {
            return await Task.Run(() => GetHTMLCode(webPage));
        }

        /// <summary>
        /// Считывает html код со страницы
        /// </summary>
        /// <param name="webPage"></param>
        /// <returns></returns>
        public string GetHTMLCode(string webPage)
        {
            string data = "";
            //запрос на веб страницу
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webPage);

            //установка куки перед http запросом
            Cookie cookie = new Cookie
            {
                Name = "beget",
                Value = "begetok"
            };

            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Uri(webPage), cookie);

            //возвращает ответ с сервера
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream reciveStream = response.GetResponseStream();
                StreamReader sr = null;
                if (response.CharacterSet == null)
                {
                    sr = new StreamReader(reciveStream);
                }
                else
                {
                    sr = new StreamReader(reciveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                data = sr.ReadToEnd();
                response.Close();
                sr.Close();
            }

            return data;
        }
    }
}
