using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstMostRecommendedFilmsCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsMostRecommendedFilmsCollection AllMostRecommendedFilms = new 
                clsMostRecommendedFilmsCollection();
            Assert.IsNotNull(AllMostRecommendedFilms);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsMostRecommendedFilmsCollection AllMostRecommendedFilms = new 
                clsMostRecommendedFilmsCollection();
            Int32 count = 10;
            AllMostRecommendedFilms.Count = count;
            Assert.AreEqual(AllMostRecommendedFilms.Count, count);
        }

        [TestMethod]
        public void AllMostRecommendedFilmsOk()
        {
            clsMostRecommendedFilmsCollection AllMostRecommendedFilms = new 
                clsMostRecommendedFilmsCollection();
            List<clsMostRecommendedFilms> TestList = new List<clsMostRecommendedFilms>();
            clsMostRecommendedFilms TestItem = new clsMostRecommendedFilms();
            TestItem.FilmId = 1200;
            TestItem.TimesRecommended = 1986;
            TestList.Add(TestItem);
            AllMostRecommendedFilms.AllMostRecommendedFilms = TestList;
            Assert.AreEqual(AllMostRecommendedFilms.AllMostRecommendedFilms, TestList);
        }

        [TestMethod]
        public void ThisMostRecommendedFilmOk()
        {
            clsMostRecommendedFilmsCollection AllMostRecommendedFilms = new 
                clsMostRecommendedFilmsCollection();
            clsMostRecommendedFilms TestItem = new clsMostRecommendedFilms();
            TestItem.FilmId = 41569;
            TestItem.TimesRecommended = 2005;
            AllMostRecommendedFilms.ThisMostRecommendedFilm = TestItem;
            Assert.AreEqual(AllMostRecommendedFilms.ThisMostRecommendedFilm, TestItem);
        }

        [TestMethod]
        public void AddMethodOk()
        {
            clsMostRecommendedFilmsCollection AllMostRecommendedFilms = new 
                clsMostRecommendedFilmsCollection();
            clsMostRecommendedFilms TestItem = new clsMostRecommendedFilms();
            TestItem.FilmId = 174055;
            TestItem.TimesRecommended = 2017;
            AllMostRecommendedFilms.ThisMostRecommendedFilm = TestItem;
            AllMostRecommendedFilms.Add();
            AllMostRecommendedFilms.ThisMostRecommendedFilm.Find(TestItem.FilmId);
            Assert.AreEqual(AllMostRecommendedFilms.ThisMostRecommendedFilm, TestItem);
        }

        [TestMethod]
        public void IncreaseTimesRecommendedOk()
        {
            clsMostRecommendedFilmsCollection AllMostRecommendedFilms = new 
                clsMostRecommendedFilmsCollection();
            clsMostRecommendedFilms TestItem = new clsMostRecommendedFilms();
            TestItem.FilmId = 41569;
            AllMostRecommendedFilms.ThisMostRecommendedFilm = TestItem;
            AllMostRecommendedFilms.IncreaseTimesRecommended();
            AllMostRecommendedFilms.ThisMostRecommendedFilm.Find(TestItem.FilmId);
            Int32 count = 0;
            Assert.AreEqual(AllMostRecommendedFilms.ThisMostRecommendedFilm.TimesRecommended, count);
        }
        
    }
}
