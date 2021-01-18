﻿using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstFilmCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFilmCollection AllFilms = new clsFilmCollection();
            Assert.IsNotNull(AllFilms);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsFilmCollection AllFilms = new clsFilmCollection();
            Int32 count = 9742;
            AllFilms.Count = count;
            Assert.AreEqual(AllFilms.Count, count);
        }

        [TestMethod]
        public void AllFilmsOk()
        {
            clsFilmCollection Films = new clsFilmCollection();
            List<clsFilm> testList = new List<clsFilm>();
            clsFilm testItem = new clsFilm();
            testItem.FilmId = 1;
            testItem.Title = "King Kong (2005)";
            testList.Add(testItem);
            Films.AllFilms = testList;
            Assert.AreEqual(Films.AllFilms, testList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsFilmCollection Films = new clsFilmCollection();
            List<clsFilm> testList = new List<clsFilm>();
            clsFilm testItem = new clsFilm();
            testItem.FilmId = 1;
            testItem.Title = "King Kong (2005)";
            testList.Add(testItem);
            Films.AllFilms = testList;
            Assert.AreEqual(Films.Count, testList.Count);
        }
    }
}
