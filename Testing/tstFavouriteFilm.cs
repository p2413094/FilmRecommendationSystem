using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstFavouriteFilm
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFavouriteFilm aFavouriteFilm = new clsFavouriteFilm();
            Assert.IsNotNull(aFavouriteFilm);
        }

        [TestMethod]
        public void UserIdPropertyOk()
        {
            clsFavouriteFilm aFavouriteFilm = new clsFavouriteFilm();
            Int32 userId = 1;
            aFavouriteFilm.UserId = userId;
            Assert.AreEqual(aFavouriteFilm.UserId, userId);
        }

        [TestMethod]
        public void FilmIdPropertyOk()
        {
            clsFavouriteFilm aFavouriteFilm = new clsFavouriteFilm();
            Int32 filmId = 1;
            aFavouriteFilm.FilmId = filmId;
            Assert.AreEqual(aFavouriteFilm.FilmId, filmId);
        }
    }
}
