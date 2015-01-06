using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FotkaNetApi;

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

            Assert.AreNotEqual(0, profiles.Count);

        }

        [TestMethod]
        public void GetProfile()
        {
            var fotkaApi = new FotkaApi();

            var profile = fotkaApi.GetProfile("ktos");

            Assert.AreNotEqual(true, string.IsNullOrEmpty(profile.Name));
            Assert.AreNotEqual(true, string.IsNullOrEmpty(profile.PhotoUrl));

        }
    }
}
