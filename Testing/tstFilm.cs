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
            Int32 errorCount = 0;
            string newFilmTitle = "Aliens (1986)";
            errorCount = aFilm.Valid(newFilmTitle).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void TitleMinLessOne()
        {
            clsFilm aFilm = new clsFilm();
            Int32 errorCount = 0;
            string newFilmTitle = "";
            errorCount = aFilm.Valid(newFilmTitle).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void TitleMinBoundary()
        {
            clsFilm aFilm = new clsFilm();
            Int32 errorCount = 0;
            string newFilmTitle = "A";
            errorCount = aFilm.Valid(newFilmTitle).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void TitleMinPlusOne()
        {
            clsFilm aFilm = new clsFilm();
            Int32 errorCount = 0;
            string newFilmTitle = "Al";
            errorCount = aFilm.Valid(newFilmTitle).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void TitleMid()
        {
            clsFilm aFilm = new clsFilm();
            Int32 errorCount = 0;
            string newFilmTitle = "";
            newFilmTitle = newFilmTitle.PadRight(90, 'a');
            errorCount = aFilm.Valid(newFilmTitle).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void TitleMaxMinusOne()
        {
            clsFilm aFilm = new clsFilm();
            Int32 errorCount = 0;
            string newFilmTitle = "";
            newFilmTitle = newFilmTitle.PadRight(179, 'a');
            errorCount = aFilm.Valid(newFilmTitle).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void TitleMaxBoundary()
        {
            clsFilm aFilm = new clsFilm();
            Int32 errorCount = 0;
            string newFilmTitle = "";
            newFilmTitle = newFilmTitle.PadRight(180, 'a');
            errorCount = aFilm.Valid(newFilmTitle).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void TitleMaxPlusOne()
        {
            clsFilm aFilm = new clsFilm();
            Int32 errorCount = 0;
            string newFilmTitle = "";
            newFilmTitle = newFilmTitle.PadRight(181, 'a');
            errorCount = aFilm.Valid(newFilmTitle).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void TitleExtremeMax()
        {
            clsFilm aFilm = new clsFilm();
            Int32 errorCount = 0;
            string newFilmTitle = "";
            newFilmTitle = newFilmTitle.PadRight(700, 'a');
            errorCount = aFilm.Valid(newFilmTitle).Count;
            Assert.AreEqual(errorCount, 0);
        }
    }
}
