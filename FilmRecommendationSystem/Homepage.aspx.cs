using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Newtonsoft.Json;
using RestSharp;

namespace FilmRecommendationSystem
{
    public partial class Homepage : System.Web.UI.Page
    {
        bool favourite = false;
        bool displayOverlay = false;
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
                pnlMostRecommendedFilms.Controls.Add(anImdbApi.GetImdbInformationWithOptions(aMostRecommendedFilm.FilmId, "", 0, favourite, displayOverlay));
            }
            pnlMostRecommendedFilms.Visible = true;
        }

        void GetUserFavouriteFilms()
        {
            clsFavouriteFilmCollection AllFavouriteFilms = new clsFavouriteFilmCollection();
            AllFavouriteFilms.GetTopFavourites();
            foreach (clsFavouriteFilm aFavouriteFilm in AllFavouriteFilms.TopFavourites)
            {
                pnlUserFavouriteFilms.Controls.Add(anImdbApi.GetImdbInformationWithOptions(aFavouriteFilm.FilmId, "", 0, favourite, displayOverlay));
            }
            pnlUserFavouriteFilms.Visible = true;
        }

        public static (IDataView training, IDataView test) LoadData(MLContext mlContext)
        {            
            DatabaseLoader loader = mlContext.Data.CreateDatabaseLoader<clsFilmRating>();

            string connectionString = null;
            System.Net.WebClient client = new System.Net.WebClient();
            connectionString = client.DownloadString("http://localhost:5000/");

            string sqlCommand = "SELECT CAST(UserId as REAL) AS UserId, CAST(FilmId as REAL) AS FilmId, CAST(Rating as REAL) AS Rating FROM tblFilmRatings";

            DatabaseSource dbSource = new DatabaseSource(SqlClientFactory.Instance, connectionString, sqlCommand);

            IDataView data = loader.Load(dbSource);

            var set = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);
            IDataView trainingDataView = set.TrainSet;
            IDataView testDataView = set.TestSet;

            return (trainingDataView, testDataView);
        }
        
        public ITransformer BuildAndTrainModel(MLContext mlContext, IDataView trainingDataView)
        {
            IEstimator<ITransformer> estimator = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: "UserId")
            .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "movieIdEncoded", inputColumnName: "FilmId"));
        
            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "movieIdEncoded",
                LabelColumnName = "Rating",
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var trainerEstimator = estimator.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));
        
            ITransformer model = trainerEstimator.Fit(trainingDataView);

            var path = Server.MapPath(@"~/Model.zip");

            mlContext.Model.Save(model, trainingDataView.Schema, path);

            return model;
        }

        void GenerateRecommendations(int genreId)
        {
            //create a new instance of the MLContext class
            MLContext mlContext = new MLContext();

            (IDataView trainingDataView, IDataView testDataView) = LoadData(mlContext);
            ITransformer model = BuildAndTrainModel(mlContext, trainingDataView);

            //create an instance of the class which represents the IDataView/ DataViewRow schema  
            DataViewSchema modelSchema;

            //find the saved model 
            var path = Server.MapPath(@"~/Model.zip");

            //load the saved model  
            ITransformer trainedModel = mlContext.Model.Load(path,
                out modelSchema);

            //create a prediction engine for film recommendations 
            var predictionEngine = mlContext.Model.CreatePredictionEngine<clsFilmRating, MovieRatingPrediction>(trainedModel);
            
            var tempUserId = Session["UserId"];
            Single userId;
            Boolean signedIn = false;

            //check if user is signed in 
            if (tempUserId == null)
            {
                userId = 1;
            }
            else
            {
                userId = Convert.ToSingle(tempUserId);
                signedIn = true;
            }

            //get all films from the database
            clsFilmGenreCollection AllFilms = new clsFilmGenreCollection();
            AllFilms.GetAllFilmsByGenre(genreId);

            List<clsFilmPrediction> AllPredictions = new List<clsFilmPrediction>();
            clsFilmPrediction aFilmPrediction = new clsFilmPrediction();
                        
            foreach (clsFilmGenre aFilm in AllFilms.AllFilmsByGenre)
            {
                var potentialRecommendation = new clsFilmRating { UserId = userId, FilmId = aFilm.FilmId};
                var movieRatingPrediction = predictionEngine.Predict(potentialRecommendation);
                //if a rating is high enough, add it to film predictions 
                if (Math.Round(movieRatingPrediction.Score, 1) > 4.4)
                {
                    aFilmPrediction = new clsFilmPrediction();
                    aFilmPrediction.FilmId = aFilm.FilmId;
                    aFilmPrediction.Score = movieRatingPrediction.Score;

                    AllPredictions.Add(aFilmPrediction);
                }
            }
            
            //sort them by score
            AllPredictions.Sort();

            //get the ten best recommendations 
            var topTenPredictions = AllPredictions.Take(10);

            clsFilmRecommendationCollection FilmRecommendations = new clsFilmRecommendationCollection();
            clsFilmRecommendation aRecommendationToAdd = new clsFilmRecommendation();

            clsMostRecommendedFilmsCollection AllMostRecommendedFilms = new clsMostRecommendedFilmsCollection();
            clsMostRecommendedFilms aMostRecommendedFilm = new clsMostRecommendedFilms();

            foreach (clsFilmPrediction aTopTenPrediction in topTenPredictions)
            {
                if (signedIn)
                {
                    //save the recommendations for future use 
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
                //get imdb information for film 
                pnlRecommendations.Controls.Add(anImdbApi.GetImdbInformation(aTopTenPrediction.FilmId));
            }
            pnlRecommendations.Visible = true;

            //save the model for later use
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