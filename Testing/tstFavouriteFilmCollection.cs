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
            Int32 userId = 1;
            clsFavouriteFilmCollection allFavouriteFilms = new clsFavouriteFilmCollection(userId);
            Assert.IsNotNull(allFavouriteFilms);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            Int32 userId = 1;
            clsFavouriteFilmCollection allFavouriteFilms = new clsFavouriteFilmCollection(userId);
            Int32 count = 5;
            allFavouriteFilms.Count = count;
            Assert.AreEqual(allFavouriteFilms.Count, count);
        }

        [TestMethod]
        public void AllFavouriteFilmsOk()
        {
            Int32 userId = 1;
            clsFavouriteFilmCollection favouriteFilms = new clsFavouriteFilmCollection(userId);
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
            Int32 userId = 1;
            clsFavouriteFilmCollection favouriteFilms = new clsFavouriteFilmCollection(userId);
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
            Int32 userId = 1;
            clsFavouriteFilmCollection AllFavouriteFilms = new clsFavouriteFilmCollection(userId);
            clsFavouriteFilm testItem = new clsFavouriteFilm();
            Int32 testSucceeded = 0;
            testItem.UserId = 1;
            testItem.FilmId = 6;
            AllFavouriteFilms.ThisFavouriteFilm = testItem;
            testSucceeded = AllFavouriteFilms.Add();
            //where 1 is the row count; 1 row should be returned and that should be the newly-inserted record
            Assert.AreEqual(testSucceeded, 1);
        }

        [TestMethod]
        public void DeleteMethodOk()
        {
            Int32 userId = 1;
            clsFavouriteFilmCollection AllFavouriteFilms = new clsFavouriteFilmCollection(userId);
            clsFavouriteFilm testItem = new clsFavouriteFilm();
            Int32 testSucceeded = 0;
            testItem.UserId = 1;
            testItem.FilmId = 8;
            AllFavouriteFilms.ThisFavouriteFilm = testItem;
            AllFavouriteFilms.Add();
            testSucceeded = AllFavouriteFilms.Delete();
            //where 1 is the row count; 1 row should be returned and that should be the newly-inserted record
            Assert.AreEqual(testSucceeded, 0);
        }
    }
}
