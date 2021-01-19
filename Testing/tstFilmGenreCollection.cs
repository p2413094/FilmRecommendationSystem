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
    }
}
