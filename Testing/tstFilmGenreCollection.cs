using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstFilmGenreCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFilmGenreCollection AllFilmGenres = new clsFilmGenreCollection();
            Assert.IsNotNull(AllFilmGenres);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsFilmGenreCollection AllFilmGenres = new clsFilmGenreCollection();
            Int32 count = 9744;
            AllFilmGenres.Count = count;
            Assert.AreEqual(AllFilmGenres.Count, count);
        }

        [TestMethod]
        public void AllFilmGenresOk()
        {
            clsFilmGenreCollection FilmGenres = new clsFilmGenreCollection();
            List<clsFilmGenre> testList = new List<clsFilmGenre>();
            clsFilmGenre testItem = new clsFilmGenre();
            testItem.FilmId = 1;
            testItem.GenreId = 1;
            testList.Add(testItem);
            FilmGenres.AllFilmGenres = testList;
            Assert.AreEqual(FilmGenres.AllFilmGenres, testList);
        }

        [TestMethod]
        public void ThisFilmGenrePropertyOk()
        {
            clsFilmGenreCollection FilmGenres = new clsFilmGenreCollection();
            clsFilmGenre aFilmGenre = new clsFilmGenre();
            aFilmGenre.FilmId = 45517;
            aFilmGenre.GenreId = 3;
            FilmGenres.ThisFilmGenre = aFilmGenre;
            Assert.AreEqual(FilmGenres.ThisFilmGenre, aFilmGenre);
        }

        [TestMethod]
        public void AllFilmsByGenrePropertyOk()
        {
            clsFilmGenreCollection FilmGenres = new clsFilmGenreCollection();
            List<clsFilmGenre> testList = new List<clsFilmGenre>();
            clsFilmGenre testItem = new clsFilmGenre();
            testItem.FilmId = 1;
            testItem.GenreId = 1;
            testList.Add(testItem);
            FilmGenres.AllFilmsByGenre = testList;
            Assert.AreEqual(FilmGenres.AllFilmsByGenre, testList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsFilmGenreCollection FilmGenres = new clsFilmGenreCollection();
            List<clsFilmGenre> testList = new List<clsFilmGenre>();
            clsFilmGenre testItem = new clsFilmGenre();
            testItem.FilmId = 1;
            testItem.GenreId = 1;
            testList.Add(testItem);
            FilmGenres.AllFilmGenres = testList;
            Assert.AreEqual(FilmGenres.Count, testList.Count);
        }

        [TestMethod]
        public void AddMethodOk()
        {
            clsFilmGenreCollection AllFilmGenres = new clsFilmGenreCollection();
            clsFilmGenre TestItem = new clsFilmGenre();
            TestItem.FilmId = 1;
            TestItem.GenreId = 5;
            AllFilmGenres.ThisFilmGenre = TestItem;
            AllFilmGenres.Add();
            AllFilmGenres.ThisFilmGenre.Find(TestItem.FilmId, TestItem.GenreId);
            Assert.AreEqual(AllFilmGenres.ThisFilmGenre, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOk()
        {
            clsFilmGenreCollection AllFilmGenres = new clsFilmGenreCollection();
            clsFilmGenre TestItem = new clsFilmGenre();
            TestItem.FilmId = 1;
            TestItem.GenreId = 5;
            AllFilmGenres.ThisFilmGenre = TestItem;
            AllFilmGenres.Add();
            AllFilmGenres.Delete();
            Boolean found = AllFilmGenres.ThisFilmGenre.Find(TestItem.FilmId, TestItem.GenreId);
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void DeleteByFilmIdMethodOk()
        {
            bool found;
            clsFilmGenreCollection AllFilmGenres = new clsFilmGenreCollection();
            clsFilmCollection AllFilms = new clsFilmCollection();
            AllFilms.ThisFilm.Title = "test";
            Int32 primaryKey = AllFilms.Add();
            Int32 genreId = 1;
            AllFilmGenres.ThisFilmGenre.FilmId = primaryKey;
            AllFilmGenres.ThisFilmGenre.GenreId = genreId;
            AllFilmGenres.Add();
            AllFilmGenres.DeleteByFilmId();
            found = AllFilmGenres.ThisFilmGenre.Find(primaryKey, genreId);
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void GetAllFilmsByGenreMethodOk()
        {
            clsFilmGenreCollection AllFilmGenres = new clsFilmGenreCollection();
            Int32 numberofFilmsByGenre = 1830;
            Int32 genreId = 1;
            AllFilmGenres.GetAllFilmsByGenre(genreId);
            Assert.AreEqual(AllFilmGenres.AllFilmsByGenre.Count, numberofFilmsByGenre);
        }
    }
}