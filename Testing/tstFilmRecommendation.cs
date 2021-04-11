using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstFilmRecommendation
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFilmRecommendation aFilmRecommendation = new clsFilmRecommendation();
            Assert.IsNotNull(aFilmRecommendation);
        }

        [TestMethod]
        public void UserIdPropertyOk()
        {
            clsFilmRecommendation aFilmRecommendation = new clsFilmRecommendation();
            Int32 userId = 1;
            aFilmRecommendation.UserId = userId;
            Assert.AreEqual(aFilmRecommendation.UserId, userId);
        }

        [TestMethod]
        public void FilmIdPropertyOk()
        {
            clsFilmRecommendation aFilmRecommendation = new clsFilmRecommendation();
            Int32 filmId = 1;
            aFilmRecommendation.FilmId = filmId;
            Assert.AreEqual(aFilmRecommendation.FilmId, filmId);
        }

        [TestMethod]
        public void FindMethodOk()
        {
            bool found;
            clsFilmRecommendation aFilmRecommendation = new clsFilmRecommendation();
            Int32 userId = 1;
            Int32 filmId = 53996;
            found = aFilmRecommendation.Find(userId, filmId);
            Assert.IsTrue(found);
        }
    }
}