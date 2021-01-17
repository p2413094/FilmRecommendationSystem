using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstLinkCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsLinkCollection AllLinks = new clsLinkCollection();
            Assert.IsNotNull(AllLinks);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsLinkCollection AllLinks = new clsLinkCollection();
            Int32 someCount = 193609;
            AllLinks.Count = someCount;
            Assert.AreEqual(AllLinks.Count, someCount);
        }

        [TestMethod]
        public void AllLinksOk()
        {
            clsLinkCollection Links = new clsLinkCollection();
            List<clsLink> testList = new List<clsLink>();
            clsLink testItem = new clsLink();
            testItem.FilmId = 1;
            testItem.ImdbId = "000000";
            testList.Add(testItem);
            Links.AllLinks = testList;
            Assert.AreEqual(Links.AllLinks, testList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsLinkCollection Links = new clsLinkCollection();
            List<clsLink> testList = new List<clsLink>();
            clsLink testItem = new clsLink();
            testItem.FilmId = 1;
            testItem.ImdbId = "00000";
            testList.Add(testItem);
            Links.AllLinks = testList;
            Assert.AreEqual(Links.Count, testList.Count);
        }

        
    }
}
