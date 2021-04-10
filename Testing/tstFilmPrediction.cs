using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Classes;
using FilmRecommendationSystem;

namespace Testing
{
    [TestClass]
    public class tstFilmPrediction
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsFilmPrediction aFilmPrediction = new clsFilmPrediction();
            Assert.IsNotNull(aFilmPrediction);
        }

        [TestMethod]
        public void FilmIdPropertyOk()
        {
            clsFilmPrediction aFilmPrediction = new clsFilmPrediction();
            Int32 filmId = 1;
            aFilmPrediction.FilmId = filmId;
            Assert.AreEqual(aFilmPrediction.FilmId, filmId);
        }

        [TestMethod]
        public void ScorePropertyOk()
        {
            clsFilmPrediction aFilmPrediction = new clsFilmPrediction();
            float score = 4.5f;
            aFilmPrediction.Score = 4.5f;
            Assert.AreEqual(aFilmPrediction.Score, score);
        }

        [TestMethod]
        public void CompareToMethodNewScoreHigherOk()
        {
            clsFilmPrediction aFilmPrediction = new clsFilmPrediction();
            aFilmPrediction.Score = 2f;

            clsFilmPrediction aSecondFilmPrediction = new clsFilmPrediction();
            float newScore = 3f;
            aSecondFilmPrediction.Score = newScore;
            Int32 result = aFilmPrediction.CompareTo(aSecondFilmPrediction);
            Assert.AreEqual(result, 1);
        }

        public void CompareToMethodNewScoreLowerOk()
        {
            clsFilmPrediction aFilmPrediction = new clsFilmPrediction();
            aFilmPrediction.Score = 3f;

            clsFilmPrediction aSecondFilmPrediction = new clsFilmPrediction();
            float newScore = 2f;
            aSecondFilmPrediction.Score = newScore;
            Int32 result = aFilmPrediction.CompareTo(aSecondFilmPrediction);
            Assert.AreEqual(result, -11);

        }
    }
}
