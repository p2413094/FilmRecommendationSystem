using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using Microsoft.ML;
using Newtonsoft.Json;
using RestSharp;

namespace FilmRecommendationSystem
{
    public partial class Homepage : System.Web.UI.Page
    {
        clsFilmCollection AllFilms = new clsFilmCollection();
        clsImdbAPI anImdbApi = new clsImdbAPI();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LoadGenres();
                LoadMoods();

                pnlSearchBy.Visible = false;
                pnlGetRecommendationsContainer.Visible = false;
                pnlRecommendations.Visible = false;

                GetMostRecommendedFilms();
                GetUserFavouriteFilms();
                //GenerateTemporaryRecommendations();

                CheckIfUserIsLoggedIn();
            }
        }

        void CheckIfUserIsLoggedIn()
        {
            bool userLoggedIn = HttpContext.Current.User.Identity.IsAuthenticated;
            if (userLoggedIn)
            {
                clsDynamicPanel aDynamicPanel = new clsDynamicPanel();
                pnlNavBar.Controls.Clear();
                pnlNavBar.CssClass = "navbar";
                pnlNavBar.Controls.Add(aDynamicPanel.GenerateMyAccountDropDown());
            }
        }

        public static List<string> SearchFilms(string prefixTest, int count)
        {
            clsFilmCollection AllFilms = new clsFilmCollection();
            List<string> filmTitles = new List<string>();
            foreach (clsFilm aFilm in AllFilms.AllFilms)
            {
                if (aFilm.Title.Contains(prefixTest))
                {
                    filmTitles.Add(aFilm.Title);
                }
            }
            return filmTitles;
        }
               
        protected void btnGetRecommendations_Click(object sender, EventArgs e)
        {
            Int32 genreId = Convert.ToInt32(ddlGenres.SelectedValue);
            GenerateRecommendations(genreId);
        }
        void LoadGenres()
        {
            clsGenreCollection AllGenres = new clsGenreCollection();
            ddlGenres.DataSource = AllGenres.AllGenres;
            ddlGenres.DataValueField = "GenreId";
            ddlGenres.DataTextField = "GenreDesc";
            ddlGenres.DataBind();
        }

        void LoadMoods()
        {
            clsMoodCollection AllMoods = new clsMoodCollection();
            ddlMoods.CssClass = "slctGenreMood";
            ddlMoods.DataSource = AllMoods.AllMoods;
            ddlMoods.DataValueField = "MoodId";
            ddlMoods.DataTextField = "MoodDesc";
            ddlMoods.DataBind();

            ddlMoods.Visible = true;
        }

        void GetMostRecommendedFilms()
        {
            clsMostRecommendedFilmsCollection AllMostRecommendedFilms = new clsMostRecommendedFilmsCollection();            
            foreach (clsMostRecommendedFilms aMostRecommendedFilm in AllMostRecommendedFilms.AllMostRecommendedFilms)
            {
                pnlMostRecommendedFilms.Controls.Add(anImdbApi.GetImdbInformation(aMostRecommendedFilm.FilmId));
            }
            pnlMostRecommendedFilms.Visible = true;
        }

        void GetUserFavouriteFilms()
        {
            clsFavouriteFilmCollection AllFavouriteFilms = new clsFavouriteFilmCollection();
            AllFavouriteFilms.GetTopFavourites();
            foreach (clsFavouriteFilm aFavouriteFilm in AllFavouriteFilms.TopFavourites)
            {
                pnlUserFavouriteFilms.Controls.Add(anImdbApi.GetImdbInformation(aFavouriteFilm.FilmId));
            }
            pnlUserFavouriteFilms.Visible = true;
        }

        void GenerateTemporaryRecommendations()
        {
            Int32 index = 0;
            Int32 timesToIterate = 6;

            while (index < timesToIterate)
            {
                Panel pnlFilm = new Panel();
                pnlFilm.CssClass = "filmWithTextContainer";

                ImageButton imgbtnFilmPoster = new ImageButton();
                imgbtnFilmPoster.CssClass = "image";
                imgbtnFilmPoster.ImageUrl = "Images/King Kong.jpg";

                pnlFilm.Controls.Add(imgbtnFilmPoster);

                Panel pnlFilmTitle = new Panel();
                pnlFilmTitle.CssClass = "titleContainer";
                Label lblFilmTitle = new Label();
                lblFilmTitle.Text = "empty";
                pnlFilmTitle.Controls.Add(lblFilmTitle);
                pnlFilm.Controls.Add(pnlFilmTitle);

                pnlRecommendations.Controls.Add(pnlFilm);

                index++;
            }

            pnlRecommendations.Visible = true;
        }

        void GenerateRecommendations(int genreId)
        {
            DataViewSchema modelSchema;
            MLContext mlContext = new MLContext();
            ITransformer trainedModel = mlContext.Model.Load(@"C:\Users\rajeshdhooper\source\repos\FilmRecommendationSystem\FilmRecommendationSystem\Model.zip", 
                out modelSchema);

            var predictionEngine = mlContext.Model.CreatePredictionEngine<clsFilmRating, MovieRatingPrediction>(trainedModel);
            
            //var testInput = new clsFilmRating { UserId = 6, FilmId = 10 };

            //var movieRatingPrediction = predictionEngine.Predict(testInput);

            Int32 dummyUserId = 1;

            clsFilmGenreCollection AllFilms = new clsFilmGenreCollection();
            AllFilms.GetAllFilmsByGenre(genreId);

            List<clsFilmPrediction> AllPredictions = new List<clsFilmPrediction>();
            clsFilmPrediction aFilmPrediction = new clsFilmPrediction();
                        
            foreach (clsFilmGenre aFilm in AllFilms.AllFilmsByGenre)
            {
                var potentialRecommendation = new clsFilmRating { UserId = dummyUserId, FilmId = aFilm.FilmId};
                var movieRatingPrediction = predictionEngine.Predict(potentialRecommendation);
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

            clsFilmRecommendationCollection FilmRecommendations = new clsFilmRecommendationCollection();
            clsFilmRecommendation aRecommendationToAdd = new clsFilmRecommendation();

            clsMostRecommendedFilmsCollection AllMostRecommendedFilms = new clsMostRecommendedFilmsCollection();
            clsMostRecommendedFilms aMostRecommendedFilm = new clsMostRecommendedFilms();

            foreach (clsFilmPrediction aTopTenPrediction in topTenPredictions)
            {
                //aRecommendationToAdd = new clsFilmRecommendation();
                //aRecommendationToAdd.FilmId = aTopTenPrediction.FilmId;
                //aRecommendationToAdd.UserId = dummyUserId;
                //FilmRecommendations.ThisFilmRecommendation = aRecommendationToAdd;
                //FilmRecommendations.Add();

                //aMostRecommendedFilm = new clsMostRecommendedFilms();
                //AllMostRecommendedFilms.ThisMostRecommendedFilm.FilmId = aTopTenPrediction.FilmId;

                //if (AllMostRecommendedFilms.ThisMostRecommendedFilm.Find(aTopTenPrediction.FilmId) == true)
                //{
                //    AllMostRecommendedFilms.IncreaseTimesRecommended();
                //}
                //else
                //{
                //    AllMostRecommendedFilms.Add();
                //}
                pnlRecommendations.Controls.Add(anImdbApi.GetImdbInformation(aTopTenPrediction.FilmId));
            }
            pnlRecommendations.Visible = true;

            mlContext.Model.Save(trainedModel, modelSchema, @"C:\Users\rajeshdhooper\source\repos\FilmRecommendationSystem\FilmRecommendationSystem\Model.zip");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FilmInformation.aspx?imdbId=tt0360717");
        }

        protected void btnGenre_Click(object sender, EventArgs e)
        {
            pnlSearchBy.Visible = true;
            ddlMoods.Visible = false;
        }

        protected void btnMood_Click(object sender, EventArgs e)
        {
            pnlSearchBy.Visible = true;
            ddlGenres.Visible = false;
        }

        protected void ddlGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlGetRecommendationsContainer.Visible = true;
        }

        protected void ddlMoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlGetRecommendationsContainer.Visible = true;
        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }

    }
}