using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstFilmRatingCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFilmRatingCollection AllFilmRatings = new clsFilmRatingCollection();
            Assert.IsNotNull(AllFilmRatings);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsFilmRatingCollection AllFilmRatings = new clsFilmRatingCollection();
            Int32 count = 100836;
            AllFilmRatings.Count = count;
            Assert.AreEqual(AllFilmRatings.Count, count);
        }

        [TestMethod]
        public void AllFilmRatingsOk()
        {
            clsFilmRatingCollection FilmRatings = new clsFilmRatingCollection();
            List<clsFilmRating> TestList = new List<clsFilmRating>();
            clsFilmRating TestItem = new clsFilmRating();
            TestItem.FilmId = 1;
            TestItem.UserId = 1;
            TestItem.Rating = 5;
            TestList.Add(TestItem);
            FilmRatings.AllFilmRatings = TestList;
            Assert.AreEqual(FilmRatings.AllFilmRatings, TestList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsFilmRatingCollection FilmRatings = new clsFilmRatingCollection();
            List<clsFilmRating> TestList = new List<clsFilmRating>();
            clsFilmRating TestItem = new clsFilmRating();
            TestItem.FilmId = 1;
            TestItem.UserId = 1;
            TestItem.Rating = 5;
            TestList.Add(TestItem);
            FilmRatings.AllFilmRatings = TestList;
            Assert.AreEqual(FilmRatings.Count, TestList.Count);
        }

        [TestMethod]
        public void ThisFilmRatingPropertyOk()
        {
            clsFilmRatingCollection AllFilmRatings = new clsFilmRatingCollection();
            clsFilmRating TestFilmRating = new clsFilmRating();
            TestFilmRating.FilmId = 2459;
            TestFilmRating.UserId = 4;
            TestFilmRating.Rating = 5;
            AllFilmRatings.ThisFilmRating = TestFilmRating;
            Assert.AreEqual(AllFilmRatings.ThisFilmRating, TestFilmRating);
        }

        [TestMethod]
        public void AddMethodOk()
        {
            clsFilmRatingCollection AllFilmRatings = new clsFilmRatingCollection();
            clsFilmRating TestItem = new clsFilmRating();
            TestItem.FilmId = 5;
            TestItem.UserId = 1;
            TestItem.Rating = 4.5F;
            AllFilmRatings.ThisFilmRating = TestItem;
            AllFilmRatings.Add();
            AllFilmRatings.ThisFilmRating.Find(TestItem.FilmId, TestItem.UserId);
            Assert.AreEqual(AllFilmRatings.ThisFilmRating, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOk()
        {
            clsFilmRatingCollection AllFilmRatings = new clsFilmRatingCollection();
            clsFilmRating TestItem = new clsFilmRating();
            TestItem.FilmId = 2459;
            TestItem.UserId = 1;
            TestItem.Rating = 5;
            AllFilmRatings.ThisFilmRating = TestItem;
            AllFilmRatings.Add();
            AllFilmRatings.ThisFilmRating.Find(TestItem.FilmId, TestItem.UserId);
            AllFilmRatings.Delete();
            Boolean found = AllFilmRatings.ThisFilmRating.Find(TestItem.FilmId, TestItem.UserId);
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void FindMethodOk()
        {
            clsFilmRating aFilmRating = new clsFilmRating();
            Boolean found = false;
            Int32 filmId = 1;
            Int32 userId = 1;
            found = aFilmRating.Find(filmId, userId);
            Assert.IsTrue(found);
        }


    }
}
