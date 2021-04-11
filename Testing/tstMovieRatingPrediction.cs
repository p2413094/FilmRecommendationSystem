using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FilmRecommendationSystem;

namespace Testing
{
    [TestClass]
    public class tstMovieRatingPrediction
    {
        [TestMethod]
        public void InstanceOk()
        {
           MovieRatingPrediction aMovieRatingPrediction = new MovieRatingPrediction();
           Assert.IsNotNull(aMovieRatingPrediction);
        }

        [TestMethod]
        public void LabelPropertyOk()
        {
            MovieRatingPrediction aMovieRatingPrediction = new MovieRatingPrediction();
            float label = 1;
            aMovieRatingPrediction.Label = label;
            Assert.AreEqual(aMovieRatingPrediction.Label, label);
        }

        [TestMethod]
        public void ScorePropertyOk()
        {
            MovieRatingPrediction aMovieRatingPrediction = new MovieRatingPrediction();
            float score = 4.5f;
            aMovieRatingPrediction.Score = score;
            Assert.AreEqual(aMovieRatingPrediction.Score, score);

        }
    }
}