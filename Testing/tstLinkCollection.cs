﻿using Classes;
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
            Int32 someCount = 9742;
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
            //193615
            clsLinkCollection AllLinks = new clsLinkCollection();
            clsLink TestItem = new clsLink();
            Int32 primaryKey = 0;
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
        public void DeleteMethodOk()
        {
            clsLinkCollection AllLinks = new clsLinkCollection();
            clsLink TestItem = new clsLink();
            TestItem.FilmId = 193614;
            TestItem.ImdbId = 1630029;
            AllLinks.ThisLink = TestItem;
            AllLinks.Add();
            AllLinks.ThisLink.Find(TestItem.FilmId);
            AllLinks.Delete();
            Boolean found = AllLinks.ThisLink.Find(TestItem.FilmId);
            Assert.IsFalse(found);
        }


        [TestMethod]
        public void FindMethodOk()
        {
            clsLink aLink = new clsLink();
            Boolean found = false;
            Int32 filmId = 1;
            found = aLink.Find(filmId);
            Assert.IsTrue(found);
        }
    }
}
