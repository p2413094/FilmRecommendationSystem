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
            Int32 count = 9755;
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
        public void ThisFilmPropertyOk()
        {
            clsFilmCollection AllFilms = new clsFilmCollection();
            clsFilm testFilm = new clsFilm();
            testFilm.FilmId = 1;
            testFilm.Title = "Midsommar(2019)";
            AllFilms.ThisFilm = testFilm;
            Assert.AreEqual(AllFilms.ThisFilm, testFilm);        
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

        [TestMethod]
        public void AddMethodOk()
        {
            clsFilmCollection AllFilms = new clsFilmCollection();
            clsFilm TestItem = new clsFilm();
            Int32 primaryKey = 0;
            TestItem.Title = "Top Gun: Maverick (2021)";
            AllFilms.ThisFilm = TestItem;
            primaryKey = AllFilms.Add();
            TestItem.FilmId = primaryKey;
            AllFilms.ThisFilm.Find(primaryKey);
            Assert.AreEqual(AllFilms.ThisFilm, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOk()
        {
            clsFilmCollection AllFilms = new clsFilmCollection();
            clsFilm TestItem = new clsFilm();
            Int32 primaryKey = 0;
            TestItem.Title = "No Time To Die (2020)";
            AllFilms.ThisFilm = TestItem;
            primaryKey = AllFilms.Add();
            TestItem.FilmId = primaryKey;

            TestItem.Title = "No Time To Die (2021)";
            AllFilms.ThisFilm = TestItem;
            AllFilms.Update();
            AllFilms.ThisFilm.Find(primaryKey);
            Assert.AreEqual(AllFilms.ThisFilm, TestItem);
        }

        [TestMethod]
        public void FilmAlreadyExistsMethodOk()
        {
            clsFilmCollection AllFilms = new clsFilmCollection();
            Boolean found = false;
            string title = "Dune (2021)";
            found = AllFilms.FilmAlreadyExistsCheck(title);
            Assert.IsTrue(found);
        }

        [TestMethod]
        public void SearchForFilmMethodOk()
        {
            clsFilmCollection AllFilms = new clsFilmCollection();
            string searchText = "Story";
            Assert.IsNotNull(AllFilms.SearchForFilm(searchText));
        }
    }
}