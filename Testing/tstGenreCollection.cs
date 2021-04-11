using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstGenreCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsGenreCollection allGenres = new clsGenreCollection();
            Assert.IsNotNull(allGenres);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsGenreCollection allGenres = new clsGenreCollection();
            Int32 count = 19;
            allGenres.Count = count;
            Assert.AreEqual(allGenres.Count, count);
        }

        [TestMethod]
        public void AllGenresOk()
        {
            clsGenreCollection genres = new clsGenreCollection();
            List<clsGenre> testList = new List<clsGenre>();
            clsGenre testItem = new clsGenre();
            testItem.GenreId = 1;
            testItem.GenreDesc = "Sci-Fi";
            testList.Add(testItem);
            genres.AllGenres = testList;
            Assert.AreEqual(genres.AllGenres, testList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsGenreCollection genres = new clsGenreCollection();
            List<clsGenre> testList = new List<clsGenre>();
            clsGenre testItem = new clsGenre();
            testItem.GenreId = 1;
            testItem.GenreDesc = "Sci-Fi";
            testList.Add(testItem);
            genres.AllGenres = testList;
            Assert.AreEqual(genres.Count, testList.Count);
        }
    }
}

