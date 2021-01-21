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
            clsFilmRecommendationCollection AllFilmRecommendations = new clsFilmRecommendationCollection();
            Assert.IsNotNull(AllFilmRecommendations);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsFilmRecommendationCollection AllFilmRecommendations = new clsFilmRecommendationCollection();
            Int32 count = 0;
            AllFilmRecommendations.Count = count;
            Assert.AreEqual(AllFilmRecommendations.Count, count);
        }

        [TestMethod]
        public void AllFilmRecommendationsOk()
        {
            clsFilmRecommendationCollection FilmRecommendations = new clsFilmRecommendationCollection();
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
            clsFilmRecommendationCollection FilmRecommendations = new clsFilmRecommendationCollection();
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
            clsFilmRecommendationCollection AllFilmRecommendations = new clsFilmRecommendationCollection();
            clsFilmRecommendation TestItem = new clsFilmRecommendation();
            TestItem.UserId = 1;
            TestItem.FilmId = 888;
            AllFilmRecommendations.ThisFilmRecommendation = TestItem;
            AllFilmRecommendations.Add();
            AllFilmRecommendations.ThisFilmRecommendation.Find(TestItem.UserId, TestItem.FilmId);
            Assert.AreEqual(AllFilmRecommendations.ThisFilmRecommendation, TestItem);
        }

        [TestMethod]
        public void DeleteMethod()
        {
            clsFilmRecommendationCollection AllFilmRecommendations = new clsFilmRecommendationCollection();
            clsFilmRecommendation TestItem = new clsFilmRecommendation();
            TestItem.UserId = 1;
            TestItem.FilmId = 444;
            AllFilmRecommendations.ThisFilmRecommendation = TestItem;
            AllFilmRecommendations.Add();
            AllFilmRecommendations.ThisFilmRecommendation.Find(TestItem.UserId, TestItem.FilmId);
            AllFilmRecommendations.Delete();
            Boolean found = AllFilmRecommendations.ThisFilmRecommendation.Find(TestItem.UserId, TestItem.FilmId);
            Assert.IsFalse(found);
        }
    }
}
