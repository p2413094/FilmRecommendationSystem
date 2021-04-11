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
            clsWatchListCollection allFilmsInWatchList = new clsWatchListCollection();
            Assert.IsNotNull(allFilmsInWatchList);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsWatchListCollection allFilmsInWatchList = new clsWatchListCollection();
            Int32 count = 8;
            allFilmsInWatchList.Count = count;
            Assert.AreEqual(allFilmsInWatchList.Count, count);
        }

        [TestMethod]
        public void AllWatchListFilmsOk()
        {
            clsWatchListCollection allFilmsInWatchList = new clsWatchListCollection();
            List<clsWatchList> testList = new List<clsWatchList>();
            clsWatchList testItem = new clsWatchList();
            testItem.UserId = 1;
            testItem.FilmId = 1;
            testItem.DateAdded = DateTime.Now;
            testList.Add(testItem);
            allFilmsInWatchList.AllFilmsInWatchList = testList;
            Assert.AreEqual(allFilmsInWatchList.AllFilmsInWatchList, testList);
        }

        [TestMethod]
        public void ThisWatchListFilmPropertyOk()
        {
            clsWatchListCollection AllFilmsInWatchList = new clsWatchListCollection();
            clsWatchList aWatchList = new clsWatchList();
            aWatchList.UserId = 1;
            aWatchList.FilmId = 1;
            aWatchList.DateAdded = DateTime.Now;
            AllFilmsInWatchList.ThisWatchListFilm = aWatchList;
            Assert.AreEqual(AllFilmsInWatchList.ThisWatchListFilm, aWatchList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsWatchListCollection allFilmsInWatchList = new clsWatchListCollection();
            List<clsWatchList> testList = new List<clsWatchList>();
            clsWatchList testItem = new clsWatchList();
            testItem.UserId = 1;
            testItem.FilmId = 1;
            testItem.DateAdded = DateTime.Now;
            testList.Add(testItem);
            allFilmsInWatchList.AllFilmsInWatchList = testList;
            Assert.AreEqual(allFilmsInWatchList.Count, testList.Count);
        }

        [TestMethod]
        public void AddMethodOk()
        {
            clsWatchListCollection AllWatchListFilms = new clsWatchListCollection();
            clsWatchList TestItem = new clsWatchList();
            TestItem.UserId = 1;
            TestItem.FilmId = 6;
            AllWatchListFilms.ThisWatchListFilm = TestItem;
            AllWatchListFilms.Add();
            AllWatchListFilms.ThisWatchListFilm.Find(TestItem.UserId, TestItem.FilmId);
            Assert.AreEqual(AllWatchListFilms.ThisWatchListFilm, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOk()
        {
            clsWatchListCollection AllWatchListFilms = new clsWatchListCollection();
            clsWatchList TestItem = new clsWatchList();
            TestItem.UserId = 1;
            TestItem.FilmId = 7;
            AllWatchListFilms.ThisWatchListFilm = TestItem;
            AllWatchListFilms.Add();
            AllWatchListFilms.ThisWatchListFilm.Find(TestItem.UserId, TestItem.FilmId);
            AllWatchListFilms.Delete();
            Boolean found = AllWatchListFilms.ThisWatchListFilm.Find(TestItem.UserId, TestItem.FilmId);
            Assert.IsFalse(found);
        }
    }
}
