using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FotkaNetApi;
using System.Collections.Generic;
using System.Linq;

namespace FotkaNetApiTest
{
    [TestClass]
    public class FotkaNetApiTest
    {
        [TestMethod]
        public void GetProfiles()
        {
            var fotkaApi = new FotkaApi();

            var profiles = fotkaApi.GetOnLineProfiles();

            Assert.AreNotEqual(0, profiles.ToList().Count);

        }

        [TestMethod]
        public void GetProfile()
        {
            var fotkaApi = new FotkaApi();

            var profiles = fotkaApi.GetOnLineProfiles();

            var fullProfiles = new List<Profile>();


            profiles.ToList().ForEach(p =>
                {
                    fullProfiles.Add(fotkaApi.GetProfile(p.Name));
                });

            fullProfiles.ForEach(fp=>
                {
                      Assert.AreNotEqual(true, string.IsNullOrEmpty(fp.Name));
                      Assert.AreNotEqual(true, string.IsNullOrEmpty(fp.PhotoUrl));
                });
        }
    }
}
