using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FotkaNetApi
{
    static class FotkaApiHelper
    {
        public static string GetProfilesHtml(string url)
        {
            WebClient webClient = new WebClient();

            byte[] reqHTML;

            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            reqHTML = webClient.DownloadData(url);

            UTF8Encoding objUTF8 = new UTF8Encoding();

            return objUTF8.GetString(reqHTML);       
        }
    }
}
