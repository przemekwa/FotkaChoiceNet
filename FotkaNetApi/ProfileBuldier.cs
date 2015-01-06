using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FotkaNetApi
{
    class ProfileBuldier : IProfileBuldier
    {
        private Profile profile;
        private const string ProfileUrl = "http://fotka.pl/profil/";


        public Profile Build(Profile profile)
        {
            this.profile = profile;

            var cos = this.GetHtml();



            return profile;

        }

        private string GetHtml()
        {
            WebClient webClient = new WebClient();

            byte[] reqHTML;

            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            reqHTML = webClient.DownloadData(ProfileUrl + profile.Name);

            UTF8Encoding objUTF8 = new UTF8Encoding();

            return objUTF8.GetString(reqHTML);  
        }
    }
}
