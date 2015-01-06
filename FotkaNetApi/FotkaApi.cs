using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FotkaNetApi
{
    public class FotkaApi
    {
        const string OnLineUrl = "http://www.fotka.pl/online/kobiety,1-30,wszystkie/1";

        public IList<Profile> GetOnLineProfiles()
        {
                var profileData = FotkaApiHelper.GetProfilesData(OnLineUrl);

                var linie = profileData.Split(new string[] { "\n" }, StringSplitOptions.None);

                var profiles = from l in linie
                            let profileName = Regex.Match(l, "shadowed-avatar av-96\" href=\"/profil/[a-zA-z0-9]*\"")
                            where profileName.Success
                            select new Profile
                            {
                                Name = profileName.Groups[0].Value.Substring(37, (profileName.Groups[0].Value.Length - 37 - 1))
                            };

                var rezult = new List<Profile>();

                var profileBuldier = new ProfileBuldier();

                foreach (var profil in profiles)
                {
                    rezult.Add(profileBuldier.Build(profil));
                }

                return rezult;
        }

        public Profile GetProfile(string name)
        {
            return new Profile();
        }
    }
}
