using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstFilmMoodCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFilmMoodCollection allFilmMoods = new clsFilmMoodCollection();
            Assert.IsNotNull(allFilmMoods);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsFilmMoodCollection allFilmMoods = new clsFilmMoodCollection();
            Int32 count = 3683;
            allFilmMoods.Count = count;
            Assert.AreEqual(allFilmMoods.Count, count);
        }

        [TestMethod]
        public void AllFilmMoodsOk()
        {
            clsFilmMoodCollection filmMoods = new clsFilmMoodCollection();
            List<clsFilmMood> testList = new List<clsFilmMood>();
            clsFilmMood testItem = new clsFilmMood();
            testItem.FilmId = 1;
            testItem.MoodId = 1;
            testItem.UserId = 1;
            testList.Add(testItem);
            filmMoods.AllFilmMoods = testList;
            Assert.AreEqual(filmMoods.AllFilmMoods, testList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsFilmMoodCollection filmMoods = new clsFilmMoodCollection();
            List<clsFilmMood> testList = new List<clsFilmMood>();
            clsFilmMood testItem = new clsFilmMood();
            testItem.FilmId = 1;
            testItem.MoodId = 1;
            testItem.UserId = 1;
            testList.Add(testItem);
            filmMoods.AllFilmMoods = testList;
            Assert.AreEqual(filmMoods.Count, testList.Count);
        }
    }
}
