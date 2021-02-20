using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstMostRecommendedFilms
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsMostRecommendedFilms aMostRecommendedFilm = new clsMostRecommendedFilms();
            Assert.IsNotNull(aMostRecommendedFilm);
        }

        [TestMethod]
        public void FilmIdPropertyOk()
        {
            clsMostRecommendedFilms aMostRecommendedFilm = new clsMostRecommendedFilms();
            Int32 filmId = 2459;
            aMostRecommendedFilm.FilmId = filmId;
            Assert.AreEqual(aMostRecommendedFilm.FilmId, filmId);
        }

        [TestMethod]
        public void TimesRecommendedPropertyOk()
        {
            clsMostRecommendedFilms aMostRecommendedFilm = new clsMostRecommendedFilms();
            Int32 timesRecommended = 1974;
            aMostRecommendedFilm.TimesRecommended = timesRecommended;
            Assert.AreEqual(aMostRecommendedFilm.TimesRecommended, timesRecommended);
        }
    }
}
