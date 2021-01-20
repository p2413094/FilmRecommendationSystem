﻿using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstFilmRating
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFilmRating aFilmRating = new clsFilmRating();
            Assert.IsNotNull(aFilmRating);
        }

        [TestMethod]
        public void FilmIdPropertyOk()
        {
            clsFilmRating aFilmRating = new clsFilmRating();
            Int32 filmId = 1;
            aFilmRating.FilmId = filmId;
            Assert.AreEqual(aFilmRating.FilmId, filmId);
        }

        [TestMethod]
        public void UserIdPropertyOk()
        {
            clsFilmRating aFilmRating = new clsFilmRating();
            Int32 userId = 1;
            aFilmRating.UserId = userId;
            Assert.AreEqual(aFilmRating.UserId, userId);
        }

        [TestMethod]
        public void RatingPropertyOk()
        {
            clsFilmRating aFilmRating = new clsFilmRating();
            double rating = 4.5;
            aFilmRating.Rating = rating;
            Assert.AreEqual(aFilmRating.Rating, rating);
        }
    }
}
