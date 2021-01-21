using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstWatchListCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            Int32 userId = 1;
            clsWatchListCollection allFilmsInWatchList = new clsWatchListCollection(userId);
            Assert.IsNotNull(allFilmsInWatchList);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            Int32 userId = 1;
            clsWatchListCollection allFilmsInWatchList = new clsWatchListCollection(userId);
            Int32 count = 1;
            allFilmsInWatchList.Count = count;
            Assert.AreEqual(allFilmsInWatchList.Count, count);
        }

        [TestMethod]
        public void AllWatchListFilmsOk()
        {
            Int32 userId = 1;
            clsWatchListCollection allFilmsInWatchList = new clsWatchListCollection(userId);
            List<clsWatchList> testList = new List<clsWatchList>();
            clsWatchList testItem = new clsWatchList();
            testItem.UserId = userId;
            testItem.FilmId = 1;
            testItem.DateAdded = DateTime.Now;
            testList.Add(testItem);
            allFilmsInWatchList.AllFilmsInWatchList = testList;
            Assert.AreEqual(allFilmsInWatchList.AllFilmsInWatchList, testList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            Int32 userId = 1;
            clsWatchListCollection allFilmsInWatchList = new clsWatchListCollection(userId);
            List<clsWatchList> testList = new List<clsWatchList>();
            clsWatchList testItem = new clsWatchList();
            testItem.UserId = userId;
            testItem.FilmId = 1;
            testItem.DateAdded = DateTime.Now;
            testList.Add(testItem);
            allFilmsInWatchList.AllFilmsInWatchList = testList;
            Assert.AreEqual(allFilmsInWatchList.Count, testList.Count);
        }

        [TestMethod]
        public void AddMethodOk()
        {
            Int32 userId = 1;
            clsWatchListCollection AllWatchListFilms = new clsWatchListCollection(userId);
            clsWatchList TestItem = new clsWatchList();
            Int32 testSucceeded = 0;
            TestItem.UserId = userId;
            TestItem.FilmId = 5;
            AllWatchListFilms.ThisWatchListFilm = TestItem;
            testSucceeded = AllWatchListFilms.Add();
            Assert.AreEqual(testSucceeded, 1);
        }

        [TestMethod]
        public void DeleteMethodOk()
        {
            Int32 userId = 1;
            clsWatchListCollection AllWatchListFilms = new clsWatchListCollection(userId);
            clsWatchList TestItem = new clsWatchList();
            Int32 testSucceeded = 0;
            TestItem.UserId = userId;
            TestItem.FilmId = 5;
            AllWatchListFilms.ThisWatchListFilm = TestItem;
            AllWatchListFilms.Add();
            testSucceeded = AllWatchListFilms.Delete();
            Assert.AreEqual(testSucceeded, 0);
        }
    }
}
