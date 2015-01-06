using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotkaNetApi
{
    public class FotkaApi
    {
        const string OnLineUrl = "http://www.fotka.pl/online/kobiety,1-30/1";

        public IList<Profile> GetOnLineProfiles()
        {
            var profileData = FotkaApiHelper.GetProfilesData(OnLineUrl);

            var profileBuldier = new ProfileBuldier();

            

            return new List<Profile>();
        }

        public Profile GetProfile(string name)
        {
            return new Profile();
        }
    }
}
