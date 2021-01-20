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
    }
}
