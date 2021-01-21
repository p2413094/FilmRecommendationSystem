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
            Int32 count = 9742;
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
            TestItem.GenreId = 4;
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
        public void FindMethodOk()
        {
            clsFilmGenre aFilmGenre = new clsFilmGenre();
            Boolean found = false;
            Int32 filmId = 1;
            Int32 genreId = 2;
            found = aFilmGenre.Find(filmId, genreId);
            Assert.IsTrue(found);
        }
    }
}
