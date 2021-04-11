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
            Int32 someCount = 9753;
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
            testItem.ImdbId = 000000;
            testList.Add(testItem);
            Links.AllLinks = testList;
            Assert.AreEqual(Links.AllLinks, testList);
        }

        [TestMethod]
        public void ThisLinkPropertyOk()
        {
            clsLinkCollection Links = new clsLinkCollection();
            clsLink aLink = new clsLink();
            aLink.FilmId = 1;
            aLink.ImdbId = 0114709;
            Links.ThisLink = aLink;
            Assert.AreEqual(Links.ThisLink, aLink);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsLinkCollection Links = new clsLinkCollection();
            List<clsLink> testList = new List<clsLink>();
            clsLink testItem = new clsLink();
            testItem.FilmId = 1;
            testItem.ImdbId = 00000;
            testList.Add(testItem);
            Links.AllLinks = testList;
            Assert.AreEqual(Links.Count, testList.Count);
        }

        [TestMethod]
        public void AddMethodOk()
        {
            clsLinkCollection AllLinks = new clsLinkCollection();
            clsLink TestItem = new clsLink();
            TestItem.FilmId = 193610;
            TestItem.ImdbId = 1160419;
            AllLinks.ThisLink = TestItem;
            AllLinks.Add();
            AllLinks.ThisLink.Find(TestItem.FilmId);
            Assert.AreEqual(AllLinks.ThisLink, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOk()
        {
            clsLinkCollection AllLinks = new clsLinkCollection();
            clsLink TestItem = new clsLink();
            TestItem.FilmId = 193615;
            TestItem.ImdbId = 1111111;
            AllLinks.ThisLink = TestItem;
            AllLinks.Add();

            TestItem.ImdbId = 5034838;
            AllLinks.ThisLink = TestItem;
            AllLinks.Update();
            AllLinks.ThisLink.Find(TestItem.FilmId);
            Assert.AreEqual(AllLinks.ThisLink, TestItem);
        }

        [TestMethod]
        public void ImdbIdAlreadyExistsCheckMethodOk()
        {
            clsLinkCollection AllLinks = new clsLinkCollection();
            bool exists;
            Int32 imdbId = 0114709;
            exists = AllLinks.ImdbIdAlreadyExistsCheck(imdbId);
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void GetLinkByFilmIdMethodOk()
        {
            bool imdbIdExists = false;
            clsLinkCollection AllLinks = new clsLinkCollection();
            AllLinks.ThisLink.FilmId = 256;
            AllLinks.GetLinkByFilmId();
            string imdbId = AllLinks.ThisLink.ImdbId.ToString();
            if (imdbId.Length != 0)
            {
                imdbIdExists = true;
            }
            else
            {
            }
            Assert.IsTrue(imdbIdExists);
        }
    }
}

