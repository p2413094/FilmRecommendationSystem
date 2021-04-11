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
            Int32 count = 13;
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
        public void ThisFavouriteFilmPropertyOk()
        {
            clsFavouriteFilmCollection favouriteFilms = new clsFavouriteFilmCollection();
            clsFavouriteFilm testFavouriteFilm = new clsFavouriteFilm();
            testFavouriteFilm.UserId = 1;
            testFavouriteFilm.FilmId = 1;
            favouriteFilms.ThisFavouriteFilm = testFavouriteFilm;
            Assert.AreEqual(favouriteFilms.ThisFavouriteFilm, testFavouriteFilm);
        }

        [TestMethod]
        public void TopFavouritesPropertyOk()
        {
            clsFavouriteFilmCollection favouriteFilms = new clsFavouriteFilmCollection();
            List<clsFavouriteFilm> testList = new List<clsFavouriteFilm>();
            clsFavouriteFilm testItem = new clsFavouriteFilm();
            testItem.FilmId = 2459;
            testList.Add(testItem);
            favouriteFilms.TopFavourites = testList;
            Assert.AreEqual(favouriteFilms.TopFavourites, testList);
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

        [TestMethod]
        public void AddMethodOk()
        {
            clsFavouriteFilmCollection AllFavouriteFilms = new clsFavouriteFilmCollection();
            clsFavouriteFilm testItem = new clsFavouriteFilm();
            testItem.UserId = 1;
            testItem.FilmId = 14;
            AllFavouriteFilms.ThisFavouriteFilm = testItem;
            AllFavouriteFilms.Add();
            AllFavouriteFilms.ThisFavouriteFilm.Find(testItem.UserId, testItem.FilmId);
            Assert.AreEqual(AllFavouriteFilms.ThisFavouriteFilm, testItem);
        }

        [TestMethod]
        public void DeleteMethodOk()
        {
            clsFavouriteFilmCollection AllFavouriteFilms = new clsFavouriteFilmCollection();
            clsFavouriteFilm testItem = new clsFavouriteFilm();
            testItem.UserId = 1;
            testItem.FilmId = 15;
            AllFavouriteFilms.ThisFavouriteFilm = testItem;
            AllFavouriteFilms.Add();
            AllFavouriteFilms.ThisFavouriteFilm.Find(testItem.UserId, testItem.FilmId);
            AllFavouriteFilms.Delete();
            Boolean found = AllFavouriteFilms.ThisFavouriteFilm.Find(testItem.UserId, testItem.FilmId);
            Assert.IsFalse(found); 
        }

        [TestMethod]
        public void GetTopFavouritesMethodOk()
        {
            clsFavouriteFilmCollection AllFavouriteFilms = new clsFavouriteFilmCollection();
            AllFavouriteFilms.GetTopFavourites();
            Int32 topTenFilmsCount = 10;
            Assert.AreEqual(AllFavouriteFilms.TopFavourites.Count, topTenFilmsCount);
        }
    }
}
