using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstFilm
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFilm aFilm = new clsFilm();
            Assert.IsNotNull(aFilm);
        }

        [TestMethod]
        public void FilmIdPropertyOk()
        {
            clsFilm aFilm = new clsFilm();
            Int32 filmId = 1;
            aFilm.FilmId = filmId;
            Assert.AreEqual(aFilm.FilmId, filmId);
        }

        [TestMethod]
        public void TitlePropertyOk()
        {
            clsFilm aFilm = new clsFilm();
            string title = "The Texas Chainsaw Massacre (1974)";
            aFilm.Title = title;
            Assert.AreEqual(aFilm.Title, title);
        }

        [TestMethod]
        public void ValidMethodOk()
        {
            clsFilm aFilm = new clsFilm();
            string error = "";
            string newFilmTitle = "Aliens (1986)";
            error = aFilm.Valid(newFilmTitle);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void TitleMinLessOne()
        {
            clsFilm aFilm = new clsFilm();
            string error = "";
            string newFilmTitle = "";
            error = aFilm.Valid(newFilmTitle);
            Assert.AreNotEqual(error, "");
        }

        [TestMethod]
        public void TitleMinBoundary()
        {
            clsFilm aFilm = new clsFilm();
            string error = "";
            string newFilmTitle = "a";
            error = aFilm.Valid(newFilmTitle);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void TitleMinPlusOne()
        {
            clsFilm aFilm = new clsFilm();
            string error = "";
            string newFilmTitle = "aa";
            error = aFilm.Valid(newFilmTitle);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void TitleMid()
        {
            clsFilm aFilm = new clsFilm();
            string error = "";
            string newFilmTitle = "";
            newFilmTitle = newFilmTitle.PadRight(90, 'a');
            error = aFilm.Valid(newFilmTitle);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void TitleMaxMinusOne()
        {
            clsFilm aFilm = new clsFilm();
            string error = "";
            string newFilmTitle = "";
            newFilmTitle = newFilmTitle.PadRight(179, 'a');
            error = aFilm.Valid(newFilmTitle);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void TitleMaxBoundary()
        {
            clsFilm aFilm = new clsFilm();
            string error = "";
            string newFilmTitle = "";
            newFilmTitle = newFilmTitle.PadRight(180, 'a');
            error = aFilm.Valid(newFilmTitle);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void TitleMaxPlusOne()
        {
            clsFilm aFilm = new clsFilm();
            string error = "";
            string newFilmTitle = "";
            newFilmTitle = newFilmTitle.PadRight(181, 'a');
            error = aFilm.Valid(newFilmTitle);
            Assert.AreNotEqual(error, "");
        }

        [TestMethod]
        public void TitleExtremeMax()
        {
            clsFilm aFilm = new clsFilm();
            string error = "";
            string newFilmTitle = "";
            newFilmTitle = newFilmTitle.PadRight(700, 'a');
            error = aFilm.Valid(newFilmTitle);
            Assert.AreNotEqual(error, "");
        }
    }
}
