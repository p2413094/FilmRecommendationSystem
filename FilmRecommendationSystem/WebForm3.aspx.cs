using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ML;
using Microsoft.ML.Data;
using Classes;

namespace FilmRecommendationSystem
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataViewSchema modelSchema;
            MLContext mlContext = new MLContext();
            ITransformer trainedModel = mlContext.Model.Load(@"C:\Users\rajeshdhooper\source\repos\FilmRecommendationSystem\FilmRecommendationSystem\Model.zip", 
                out modelSchema);

            var predictionEngine = mlContext.Model.CreatePredictionEngine<clsFilmRating, MovieRatingPrediction>(trainedModel);
            
            var testInput = new clsFilmRating { UserId = 6, FilmId = 10 };

            var movieRatingPrediction = predictionEngine.Predict(testInput);

            Label lbl1 = new Label();

            Int32 dummyUserId = 1;
            Int32 dummyGenreId = 1;
            clsFilmGenreCollection AllFilms = new clsFilmGenreCollection();
            AllFilms.GetAllFilmsByGenre(dummyGenreId);

            List<clsFilmPrediction> AllPredictions = new List<clsFilmPrediction>();
            clsFilmPrediction aFilmPrediction = new clsFilmPrediction();
                        
            foreach (clsFilmGenre aFilm in AllFilms.AllFilmsByGenre)
            {
                var potentialRecommendation = new clsFilmRating { UserId = dummyUserId, FilmId = aFilm.FilmId};
                movieRatingPrediction = predictionEngine.Predict(potentialRecommendation);
                if (Math.Round(movieRatingPrediction.Score, 1) > 4.4)
                {
                    aFilmPrediction = new clsFilmPrediction();
                    aFilmPrediction.FilmId = aFilm.FilmId;
                    aFilmPrediction.Score = movieRatingPrediction.Score;

                    AllPredictions.Add(aFilmPrediction);
                }
            }
            
            AllPredictions.Sort();

            var topTenPredictions = AllPredictions.Take(10);
            Label lblFilmRecommendationText = new Label();

            clsFilmRecommendationCollection FilmRecommendations = new clsFilmRecommendationCollection();
            clsFilmRecommendation aRecommendationToAdd = new clsFilmRecommendation();

            foreach (clsFilmPrediction aTopTenPrediction in topTenPredictions)
            {
                lblFilmRecommendationText = new Label();
                lblFilmRecommendationText.Text = "FilmId is " + aTopTenPrediction.FilmId + " and the score is: " + aTopTenPrediction.Score;
                Panel1.Controls.Add(lblFilmRecommendationText);
                Panel1.Controls.Add(new LiteralControl("<br />"));

                //aRecommendationToAdd = new clsFilmRecommendation();
                //aRecommendationToAdd.FilmId = aTopTenPrediction.FilmId;
                //aRecommendationToAdd.UserId = dummyUserId;
                //FilmRecommendations.ThisFilmRecommendation = aRecommendationToAdd;
                //FilmRecommendations.Add();
            }
        }
    }
}