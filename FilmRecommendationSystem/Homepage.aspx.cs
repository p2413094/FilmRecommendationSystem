using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using FilmRecommendationSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.ML;
using Newtonsoft.Json;
using RestSharp;

namespace FilmRecommendationSystem
{
    public partial class Homepage : System.Web.UI.Page
    {
        clsImdbAPI anImdbApi = new clsImdbAPI();

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            try
            {
                pnlSearchBy.Visible = false;

                if (!IsPostBack)
                {
                    LoadGenres();
                    LoadMoods();
                }

                pnlRecommendations.Visible = false;

                GetMostRecommendedFilms();
                GetUserFavouriteFilms();

                CheckIfUserIsLoggedIn();
            }
            catch
            {
                pnlError.Visible = true;
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

        void GenerateRecommendations(int genreId)
        {
            DataViewSchema modelSchema;
            MLContext mlContext = new MLContext();
            var path = Server.MapPath(@"~/Model.zip");

            //ITransformer trainedModel = mlContext.Model.Load(@"C:\Users\rajeshdhooper\source\repos\FilmRecommendationSystem\FilmRecommendationSystem\Model.zip", 
            //    out modelSchema);

            ITransformer trainedModel = mlContext.Model.Load(path,
                out modelSchema);

            var predictionEngine = mlContext.Model.CreatePredictionEngine<clsFilmRating, MovieRatingPrediction>(trainedModel);
            
            var tempUserId = Session["UserId"];
            Single userId;
            Boolean signedIn = false;

            if (tempUserId == null)
            {
                userId = 1;
            }
            else
            {
                userId = Convert.ToSingle(tempUserId);
                signedIn = true;
            }

            clsFilmGenreCollection AllFilms = new clsFilmGenreCollection();
            AllFilms.GetAllFilmsByGenre(genreId);

            List<clsFilmPrediction> AllPredictions = new List<clsFilmPrediction>();
            clsFilmPrediction aFilmPrediction = new clsFilmPrediction();
                        
            foreach (clsFilmGenre aFilm in AllFilms.AllFilmsByGenre)
            {
                var potentialRecommendation = new clsFilmRating { UserId = userId, FilmId = aFilm.FilmId};
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
                if (signedIn)
                {
                    aRecommendationToAdd = new clsFilmRecommendation();
                    aRecommendationToAdd.FilmId = aTopTenPrediction.FilmId;
                    aRecommendationToAdd.UserId = Convert.ToInt32(userId);
                    FilmRecommendations.ThisFilmRecommendation = aRecommendationToAdd;
                    FilmRecommendations.Add();
                }

                aMostRecommendedFilm = new clsMostRecommendedFilms();
                AllMostRecommendedFilms.ThisMostRecommendedFilm.FilmId = aTopTenPrediction.FilmId;

                if (AllMostRecommendedFilms.ThisMostRecommendedFilm.Find(aTopTenPrediction.FilmId) == true)
                {
                    AllMostRecommendedFilms.IncreaseTimesRecommended();
                }
                else
                {
                    AllMostRecommendedFilms.Add();
                }
                pnlRecommendations.Controls.Add(anImdbApi.GetImdbInformation(aTopTenPrediction.FilmId));
            }
            pnlRecommendations.Visible = true;

            mlContext.Model.Save(trainedModel, modelSchema, path);
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
            Int32 genreId = Convert.ToInt32(ddlGenres.SelectedValue);
            GenerateRecommendations(genreId);
        }

        protected void ddlMoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 moodId = Convert.ToInt32(ddlMoods.SelectedValue);
            Int32 genreId = Convert.ToInt32(ddlGenres.SelectedValue);
            GenerateRecommendations(genreId);

            clsFilmMood aFilmMood = new clsFilmMood();
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@MoodId", moodId);
            DB.Execute("sproc_tblFilmMood_FilterByMoodId");
            Int32 recordCount = DB.Count;
            Int32 index = 0;

            if (DB.Count != 0)
            {
                while (index < recordCount)
                {
                    pnlRecommendations.Controls.Add(anImdbApi.GetImdbInformation((Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]))));
                    index++;
                }
            }
            else
            {
                Panel pnlNoFilmsAvailableContainer = new Panel();
                pnlNoFilmsAvailableContainer.CssClass = "textAlignCentre";
                Label lblNoFilmsAvailableText = new Label();
                lblNoFilmsAvailableText.Text = "There are no films available that suit your criteria. Please try again later.";
                pnlNoFilmsAvailableContainer.Controls.Add(lblNoFilmsAvailableText);
            }
        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }
    }
}