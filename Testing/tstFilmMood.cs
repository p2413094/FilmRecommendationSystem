using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstFilmMood
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFilmMood aFilmMood = new clsFilmMood();
            Assert.IsNotNull(aFilmMood);
        }

        [TestMethod]
        public void FilmIdPropertyOk()
        {
            clsFilmMood aFilmMood = new clsFilmMood();
            Int32 filmId = 1;
            aFilmMood.FilmId = filmId;
            Assert.AreEqual(aFilmMood.FilmId, filmId);
        }

        [TestMethod]
        public void MoodIdPropertyOk()
        {
            clsFilmMood aFilmMood = new clsFilmMood();
            Int32 moodId = 1;
            aFilmMood.MoodId = moodId;
            Assert.AreEqual(aFilmMood.MoodId, moodId);
        }

        [TestMethod]
        public void UserIdPropertyOk()
        {
            clsFilmMood aFilmMood = new clsFilmMood();
            Int32 userId = 1;
            aFilmMood.UserId = userId;
            Assert.AreEqual(aFilmMood.UserId, userId);
        }
    }
}
