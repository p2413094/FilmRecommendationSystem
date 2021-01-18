using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstFavouriteFilmCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFavouriteFilmCollection allFavouriteFilms = new clsFavouriteFilmCollection();
            Assert.IsNotNull(allFavouriteFilms);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsFavouriteFilmCollection allFavouriteFilms = new clsFavouriteFilmCollection();
            Int32 count = 1;
            allFavouriteFilms.Count = count;
            Assert.AreEqual(allFavouriteFilms.Count, count);
        }

        [TestMethod]
        public void AllFavouriteFilmsOk()
        {
            clsFavouriteFilmCollection favouriteFilms = new clsFavouriteFilmCollection();
            List<clsFavouriteFilm> testList = new List<clsFavouriteFilm>();
            clsFavouriteFilm testItem = new clsFavouriteFilm();
            testItem.UserId = 1;
            testItem.FilmId = 1;
            testList.Add(testItem);
            favouriteFilms.AllFavouriteFilms = testList;
            Assert.AreEqual(favouriteFilms.AllFavouriteFilms, testList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsFavouriteFilmCollection favouriteFilms = new clsFavouriteFilmCollection();
            List<clsFavouriteFilm> testList = new List<clsFavouriteFilm>();
            clsFavouriteFilm testItem = new clsFavouriteFilm();
            testItem.UserId = 1;
            testItem.FilmId = 1;
            testList.Add(testItem);
            favouriteFilms.AllFavouriteFilms = testList;
            Assert.AreEqual(favouriteFilms.Count, testList.Count);

        }
    }
}
