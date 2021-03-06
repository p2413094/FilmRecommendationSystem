using System;
using System.Collections.Generic;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {




                LoadGenres();
                LoadMoods();
                //GenerateRecommendations(4);
                //GenerateTemporaryRecommendations();
                pnlRecommendations.Visible = false;
                //pnlUserFavouriteFilms.Visible = false;
                GetMostRecommendedFilms();

                //AllFilms = new clsFilmCollection();

                //GetUserFavouriteFilms();
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
            
            ddlGenres.Visible = false;
        }

        void LoadMoods()
        {
            clsMoodCollection AllMoods = new clsMoodCollection();
            ddlMoods.CssClass = "slctGenreMood";
            ddlMoods.DataSource = AllMoods.AllMoods;
            ddlMoods.DataValueField = "MoodId";
            ddlMoods.DataTextField = "MoodDesc";
            ddlMoods.DataBind();

            ddlMoods.Visible = false;
        }

        void GetMostRecommendedFilms()
        {
            clsMostRecommendedFilmsCollection AllMostRecommendedFilms = new clsMostRecommendedFilmsCollection();            
            foreach (clsMostRecommendedFilms aMostRecommendedFilm in AllMostRecommendedFilms.AllMostRecommendedFilms)
            {
                GetImdbInformationForMostRecommendedFilms(aMostRecommendedFilm.FilmId);
            }           
        }

        void GetUserFavouriteFilms()
        {
            clsFavouriteFilmCollection AllFavouriteFilms = new clsFavouriteFilmCollection();
            Random newRandom = new Random();
            Int32 filmsGenerated = 0;
            List<int> indexesAlreadyUsed = new List<int>();
            List<int> filmsAlreadyDisplayed = new List<int>();
            Int32 filmId = 0;
            while (filmsGenerated != 10)
            {
                int filmToDisplay = newRandom.Next(AllFavouriteFilms.AllFavouriteFilms.Count);

                if (!indexesAlreadyUsed.Contains(filmToDisplay))
                {
                    filmId = AllFavouriteFilms.AllFavouriteFilms[filmToDisplay].FilmId;

                    if (!filmsAlreadyDisplayed.Contains(filmId))
                    {
                        GetImdbInformationForUserFavouriteFilms(filmId);
                        filmsAlreadyDisplayed.Add(filmId);

                        indexesAlreadyUsed.Add(filmToDisplay);
                        filmsGenerated++;
                    }
                    else
                    {
                        filmsAlreadyDisplayed.Add(filmId);
                    }

                }
                else
                {
                    indexesAlreadyUsed.Add(filmToDisplay);
                }
            }
        }


        void GetImdbInformationForUserFavouriteFilms(Int32 filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblLinksFilterByFilmId");

            string imdbId = DB.DataTable.Rows[0]["ImdbId"].ToString();

            var client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + imdbId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "2951edd025mshf1b0f9ca8a52c6ap1e71e9jsn67c827bdd770");
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            clsIMDBApi filmInfoReturned = new clsIMDBApi();
            filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsIMDBApi>(response.Content);
            var imdbIdOk = filmInfoReturned.Response;
            Int32 count = 0;
            string numberOfZeroes = "0";
            string newImdbId = "tt";

            //this part is inefficient - needs looking at 
            while (imdbIdOk == false)
            {
                newImdbId = newImdbId + numberOfZeroes.PadRight(count, '0') + imdbId;

                //may need the below if the search fails 
                newImdbId = "tt" + numberOfZeroes.PadRight(count, '0') + imdbId;

                //newImdbId = newImdbId.Replace(" ", string.Empty);
                client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + newImdbId);
                request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-key", "2951edd025mshf1b0f9ca8a52c6ap1e71e9jsn67c827bdd770");
                request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
                response = client.Execute(request);
                filmInfoReturned = new clsIMDBApi();
                filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsIMDBApi>(response.Content);
                imdbIdOk = filmInfoReturned.Response;
                count++;
            }

            ImageButton newClickableImage = new ImageButton();
            newClickableImage.ImageUrl = filmInfoReturned.Poster;
            newClickableImage.PostBackUrl = "FilmInformation.aspx?ImdbId=" + newImdbId;

            newClickableImage.CssClass = "image";
            pnlUserFavouriteFilms.Controls.Add(newClickableImage);

            pnlUserFavouriteFilms.Visible = true;
        }





        void GetImdbInformationForMostRecommendedFilms(Int32 filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblLinksFilterByFilmId");

            string imdbId = DB.DataTable.Rows[0]["ImdbId"].ToString();

            var client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + imdbId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "2951edd025mshf1b0f9ca8a52c6ap1e71e9jsn67c827bdd770");
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            clsIMDBApi filmInfoReturned = new clsIMDBApi();
            filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsIMDBApi>(response.Content);
            var imdbIdOk = filmInfoReturned.Response;
            Int32 count = 0;
            string numberOfZeroes = "0";
            string newImdbId = "tt";

            //this part is inefficient - needs looking at 
            while (imdbIdOk == false)
            {
                newImdbId = newImdbId + numberOfZeroes.PadRight(count, '0') + imdbId;

                //may need the below if the search fails 
                newImdbId = "tt" + numberOfZeroes.PadRight(count, '0') + imdbId;

                //newImdbId = newImdbId.Replace(" ", string.Empty);
                client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + newImdbId);
                request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-key", "2951edd025mshf1b0f9ca8a52c6ap1e71e9jsn67c827bdd770");
                request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
                response = client.Execute(request);
                filmInfoReturned = new clsIMDBApi();
                filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsIMDBApi>(response.Content);
                imdbIdOk = filmInfoReturned.Response;
                count++;
            }

            ImageButton newClickableImage = new ImageButton();
            newClickableImage.ImageUrl = filmInfoReturned.Poster;
            newClickableImage.PostBackUrl = "FilmInformation.aspx?ImdbId=" + newImdbId;

            newClickableImage.CssClass = "image";
            pnlMostRecommendedFilms.Controls.Add(newClickableImage);
            pnlMostRecommendedFilms.Visible = true;
        }

        void GetImdbInformation(Int32 filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblLinksFilterByFilmId");

            string imdbId = DB.DataTable.Rows[0]["ImdbId"].ToString();

            var client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + imdbId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "2951edd025mshf1b0f9ca8a52c6ap1e71e9jsn67c827bdd770");
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            clsIMDBApi filmInfoReturned = new clsIMDBApi();
            filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsIMDBApi>(response.Content);
            var imdbIdOk = filmInfoReturned.Response;
            Int32 count = 0;
            string numberOfZeroes = "0";
            string newImdbId = "tt";

            //this part is inefficient - needs looking at 
            while (imdbIdOk == false)
            {
                newImdbId = newImdbId + numberOfZeroes.PadRight(count, '0') + imdbId;

                //may need the below if the search fails 
                newImdbId = "tt" + numberOfZeroes.PadRight(count, '0') + imdbId;

                //newImdbId = newImdbId.Replace(" ", string.Empty);
                client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + newImdbId);
                request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-key", "2951edd025mshf1b0f9ca8a52c6ap1e71e9jsn67c827bdd770");
                request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
                response = client.Execute(request);
                filmInfoReturned = new clsIMDBApi();
                filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsIMDBApi>(response.Content);
                imdbIdOk = filmInfoReturned.Response;
                count++;
            }

            ImageButton newClickableImage = new ImageButton();
            newClickableImage.ImageUrl = filmInfoReturned.Poster;
            newClickableImage.PostBackUrl = "FilmInformation.aspx?ImdbId=" + newImdbId;

            newClickableImage.CssClass = "image";
            pnlRecommendations.Controls.Add(newClickableImage);
            pnlRecommendations.Visible = true;
        }

        void GenerateTemporaryRecommendations()
        {
            ImageButton imgButton1 = new ImageButton();
            Int32 count = 6;
            Int32 index = 0;
            Int32 filmId = 1;
            imgButton1.ImageUrl = "Images/Terminator.jpg";
            imgButton1.PostBackUrl = "FilmInformation.aspx";
            imgButton1.CssClass = "image";
            pnlRecommendations.Controls.Add(imgButton1);
            while (index < count)
            {
                imgButton1 = new ImageButton();
                imgButton1.ImageUrl = "Images/The Wolf of Wall Street.jpg";
                imgButton1.PostBackUrl = "FilmInformation.aspx?FilmId=" + filmId;
                imgButton1.CssClass = "image";

                pnlRecommendations.Controls.Add(imgButton1);
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
                
                GetImdbInformation(aTopTenPrediction.FilmId);
            }

            mlContext.Model.Save(trainedModel, modelSchema, @"C:\Users\rajeshdhooper\source\repos\FilmRecommendationSystem\FilmRecommendationSystem\Model.zip");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FilmInformation.aspx?imdbId=tt0360717");
        }

        protected void btnGenre_Click(object sender, EventArgs e)
        {
            ddlGenres.Visible = true;
        }

        protected void btnMood_Click(object sender, EventArgs e)
        {
            ddlMoods.Visible = true;
        }
    }
}