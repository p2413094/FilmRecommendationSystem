﻿using Classes;
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
            Int32 count = 3685;
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

        [TestMethod]
        public void ThisFilmMoodPropertyOk()
        {
            clsFilmMoodCollection AllFilmMoods = new clsFilmMoodCollection();
            clsFilmMood aFilmMood = new clsFilmMood();
            aFilmMood.FilmId = 1;
            aFilmMood.UserId = 1;
            aFilmMood.MoodId = 1;
            AllFilmMoods.ThisFilmMood = aFilmMood;
            Assert.AreEqual(AllFilmMoods.ThisFilmMood, aFilmMood);
        }

        [TestMethod]
        public void AddMethodOk()
        {
            clsFilmMoodCollection AllFilmMoods = new clsFilmMoodCollection();
            clsFilmMood TestItem = new clsFilmMood();
            TestItem.FilmId = 2;
            TestItem.UserId = 1;
            TestItem.MoodId = 2;
            AllFilmMoods.ThisFilmMood = TestItem;
            AllFilmMoods.Add();
            AllFilmMoods.ThisFilmMood.Find(TestItem.FilmId, TestItem.UserId, TestItem.MoodId);
        }

        [TestMethod]
        public void Delete()
        {
            clsFilmMoodCollection AllFilmMoods = new clsFilmMoodCollection();
            clsFilmMood TestItem = new clsFilmMood();
            TestItem.FilmId = 1;
            TestItem.UserId = 1;
            TestItem.MoodId = 3;
            AllFilmMoods.ThisFilmMood = TestItem;
            AllFilmMoods.Add();

            AllFilmMoods.ThisFilmMood.Find(TestItem.FilmId, TestItem.UserId, TestItem.MoodId);
            AllFilmMoods.Delete();
            Boolean found = AllFilmMoods.ThisFilmMood.Find(TestItem.FilmId, TestItem.UserId, TestItem.MoodId);
            Assert.IsFalse(found);
        }
    }
}