﻿using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstIMDBApi
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            Assert.IsNotNull(newReturnedFilm);
        }

        [TestMethod]
        public void DescriptionPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string description = "The plot of The Texas Chainsaw Massacre (1974)";
            newReturnedFilm.Description = description;
            Assert.AreEqual(newReturnedFilm.Description, description);
        }

        [TestMethod]
        public void GenrePropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string genre = "Horror";
            newReturnedFilm.Genre = genre;
            Assert.AreEqual(newReturnedFilm.Genre, genre);
        }

        [TestMethod]
        public void AgeRatingPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string ageRating = "R";
            newReturnedFilm.AgeRating = ageRating;
            Assert.AreEqual(newReturnedFilm.AgeRating, ageRating);
        }

        [TestMethod]
        public void DirectorPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string director = "Tobe Hoooper";
            newReturnedFilm.Director = director;
            Assert.AreEqual(newReturnedFilm.Director, director);
        }

        [TestMethod]
        public void RuntimePropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string runtime = "83 min";
            newReturnedFilm.Runtime = runtime;
            Assert.AreEqual(newReturnedFilm.Runtime, runtime);
        }

        [TestMethod]
        public void PosterUrlPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string posterUrl = "https://m.media-amazon.com/images/M/MV5BZDI3OWE0ZWMtNGJjOS00N2E4LWFiOTAtZjQ4OTNiNzIwN2NkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg";
            newReturnedFilm.PosterUrl = posterUrl;
            Assert.AreEqual(newReturnedFilm.PosterUrl, posterUrl);
        }

        [TestMethod]
        public void IMDBIdPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string imdbId = "tt0072271";
            newReturnedFilm.ImdbId = imdbId;
            Assert.AreEqual(newReturnedFilm.ImdbId, imdbId);
        }
    }
}
