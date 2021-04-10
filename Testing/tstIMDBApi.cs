using Classes;
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
        public void TitlePropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string title = "Aliens";
            newReturnedFilm.Title = title;
            Assert.AreEqual(newReturnedFilm.Title, title);
        }

        [TestMethod]
        public void YearPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string year = "1986";
            newReturnedFilm.Year = year;
            Assert.AreEqual(newReturnedFilm.Year, year);
        }

        [TestMethod]
        public void RatedPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string rated = "R";
            newReturnedFilm.Rated = rated;
            Assert.AreEqual(newReturnedFilm.Rated, rated);
        }

        [TestMethod]
        public void ReleasedPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string released = "18 July 1986";
            newReturnedFilm.Released = released;
            Assert.AreEqual(newReturnedFilm.Released, released);
        }

        [TestMethod]
        public void PlotPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string plot = "Fifty-seven years after surviving an apocalyptic attack ...";
            newReturnedFilm.Plot = plot;
            Assert.AreEqual(newReturnedFilm.Plot, plot);
        }

        [TestMethod]
        public void GenrePropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string genre = "Action";
            newReturnedFilm.Genre = genre;
            Assert.AreEqual(newReturnedFilm.Genre, genre);
        }

        [TestMethod]
        public void DirectorPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string director = "James Cameron";
            newReturnedFilm.Director = director;
            Assert.AreEqual(newReturnedFilm.Director, director);
        }

        [TestMethod]
        public void RuntimePropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string runtime = "137 min";
            newReturnedFilm.Runtime = runtime;
            Assert.AreEqual(newReturnedFilm.Runtime, runtime);
        }

        [TestMethod]
        public void PosterUrlPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string posterUrl = "https://m.media-amazon.com/images/M/MV5BZGU2OGY5ZTYtMWNhYy00NjZiLWI0NjUtZmNhY2JhNDRmODU3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._" +
                "V1_SX300.jpg";
            newReturnedFilm.Poster = posterUrl;
            Assert.AreEqual(newReturnedFilm.Poster, posterUrl);
        }

        [TestMethod]
        public void IMDBIdPropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            string imdbId = "tt0090605";
            newReturnedFilm.ImdbId = imdbId;
            Assert.AreEqual(newReturnedFilm.ImdbId, imdbId);
        }

        [TestMethod]
        public void ResponsePropertyOk()
        {
            clsIMDBApi newReturnedFilm = new clsIMDBApi();
            bool response = true;;
            newReturnedFilm.Response = response;
            Assert.AreEqual(newReturnedFilm.Response, response);
        }
    }
}
