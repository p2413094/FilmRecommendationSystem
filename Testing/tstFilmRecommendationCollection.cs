using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstFilmRecommendationCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            Int32 userId = 1;
            clsFilmRecommendationCollection AllFilmRecommendations = new clsFilmRecommendationCollection(userId);
            Assert.IsNotNull(AllFilmRecommendations);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            Int32 userId = 1;
            clsFilmRecommendationCollection AllFilmRecommendations = new clsFilmRecommendationCollection(userId);
            Int32 count = 0;
            AllFilmRecommendations.Count = count;
            Assert.AreEqual(AllFilmRecommendations.Count, count);
        }

        [TestMethod]
        public void AllFilmRecommendationsOk()
        {
            Int32 userId = 1;
            clsFilmRecommendationCollection FilmRecommendations = new clsFilmRecommendationCollection(userId);
            List<clsFilmRecommendation> TestList = new List<clsFilmRecommendation>();
            clsFilmRecommendation TestItem = new clsFilmRecommendation();
            TestItem.UserId = 1;
            TestItem.FilmId = 1;
            TestList.Add(TestItem);
            FilmRecommendations.AllFilmRecommendations = TestList;
            Assert.AreEqual(FilmRecommendations.AllFilmRecommendations, TestList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            Int32 userId = 1;
            clsFilmRecommendationCollection FilmRecommendations = new clsFilmRecommendationCollection(userId);
            List<clsFilmRecommendation> TestList = new List<clsFilmRecommendation>();
            clsFilmRecommendation TestItem = new clsFilmRecommendation();
            TestItem.UserId = 1;
            TestItem.FilmId = 1;
            TestList.Add(TestItem);
            FilmRecommendations.AllFilmRecommendations = TestList;
            Assert.AreEqual(FilmRecommendations.Count, TestList.Count);
        }

        [TestMethod]
        public void AddMethodOk()
        {
            Int32 userId = 1;
            clsFilmRecommendationCollection AllFilmRecommendations = new clsFilmRecommendationCollection(userId);
            clsFilmRecommendation TestItem = new clsFilmRecommendation();
            Int32 testSucceeded = 0;
            TestItem.UserId = 1;
            TestItem.FilmId = 888;
            AllFilmRecommendations.ThisFilmRecommendation = TestItem;
            testSucceeded = AllFilmRecommendations.Add();
            Assert.AreEqual(testSucceeded, 1);
        }

        [TestMethod]
        public void DeleteMethod()
        {
            Int32 userId = 4;
            clsFilmRecommendationCollection AllFilmRecommendations = new clsFilmRecommendationCollection(userId);
            clsFilmRecommendation TestItem = new clsFilmRecommendation();
            Int32 testSucceeded = 0;
            TestItem.UserId = userId;
            TestItem.FilmId = 444;
            AllFilmRecommendations.ThisFilmRecommendation = TestItem;
            AllFilmRecommendations.Add();
            testSucceeded = AllFilmRecommendations.Delete();
            Assert.AreEqual(testSucceeded, 0);
        }
    }
}
