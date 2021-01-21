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
            Int32 count = 5;
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

        [TestMethod]
        public void AddMethodOk()
        {
            clsFavouriteFilmCollection AllFavouriteFilms = new clsFavouriteFilmCollection();
            clsFavouriteFilm testItem = new clsFavouriteFilm();
            testItem.UserId = 1;
            testItem.FilmId = 12;
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
            testItem.FilmId = 8;
            AllFavouriteFilms.ThisFavouriteFilm = testItem;
            AllFavouriteFilms.Add();
            AllFavouriteFilms.Delete();
            Boolean found = AllFavouriteFilms.ThisFavouriteFilm.Find(testItem.UserId, testItem.FilmId);
            Assert.IsFalse(found); 
        }

        [TestMethod]
        public void FindMethodOk()
        {
            clsFavouriteFilm aFavouriteFilm = new clsFavouriteFilm();
            Boolean found = false;
            Int32 userId = 1;
            Int32 filmId = 2;
            found = aFavouriteFilm.Find(userId, filmId);
            Assert.IsTrue(found);
        }
    }
}
