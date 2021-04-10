using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstFilmGenre
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFilmGenre aFilmGenre = new clsFilmGenre();
            Assert.IsNotNull(aFilmGenre);
        }

        [TestMethod]
        public void FilmIdPropertyOk()
        {
            clsFilmGenre aFilmGenre = new clsFilmGenre();
            Int32 filmId = 1;
            aFilmGenre.FilmId = filmId;
            Assert.AreEqual(aFilmGenre.FilmId, filmId);
        }

        [TestMethod]
        public void GenreIdPropertyOk()
        {
            clsFilmGenre aFilmGenre = new clsFilmGenre();
            Int32 genreId = 1;
            aFilmGenre.GenreId = genreId;
            Assert.AreEqual(aFilmGenre.GenreId, genreId);
        }

        [TestMethod]
        public void FindMethodOk()
        {
            bool found;
            clsFilmGenre aFilmGenre = new clsFilmGenre();
            Int32 filmId = 1;
            Int32 genreId = 2;
            found = aFilmGenre.Find(filmId, genreId);
            Assert.IsTrue(found);
        }
    }
}
