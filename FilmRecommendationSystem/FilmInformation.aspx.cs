using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;
using Classes;
using System.Configuration;

namespace FilmRecommendationSystem
{
    public partial class FilmInformation : System.Web.UI.Page
    {
        Int32 filmId = 1;
        Int32 userId = 1;
        bool filmInFavourites = false;
        bool filmInWatchList = false;
        bool ratingExists = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    CheckIfUserIsLoggedIn();

                pnlError.Visible = false;
            //    //pnlFilmInformation.Visible = false;
            //    string imdbId; //= Request.QueryString["imdbId"];
                userId = 1;
            //    //filmId = 1; //Session object required here 
            //    imdbId = "tt0114709";

            //    //DisplayFilm(imdbId);
                //DisplayAllMoods();

            //    DisplayUserAssignedMoods();


            //}
            lblPlot.Text = "Encrypting sensitive sections of the Web.Config is important because they are just that, sensitive. " +
                "Think about production Web.Config file. It may contain all information that requires running your web application. There are often passwords for SQL database connections, SMTP server, API Keys, or other critical information. In addition to this, Web.Config files are usually treated as just another source code file, that means, any developer on the team, or more accurately anyone with" +
                " access to the source code, can see what information is stored in Web.Config file.";
        }

        void CheckIfUserIsLoggedIn()
        {
            //bool userLoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            bool userLoggedIn = HttpContext.Current.User.Identity.IsAuthenticated;
            if (userLoggedIn)
            {
                clsDynamicPanel aDynamicPanel = new clsDynamicPanel();
                pnlNavBar.Controls.Clear();
                pnlNavBar.CssClass = "navbar";
                pnlNavBar.Controls.Add(aDynamicPanel.GenerateMyAccountDropDown());
            }
        }



        void DisplayFilm(string imdbId)
        {
            var client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + imdbId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", ConfigurationManager.AppSettings["RapidApiKey"]);
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            clsIMDBApi filmInfoReturned = new clsIMDBApi();
            filmInfoReturned = new clsIMDBApi();
            filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsIMDBApi>(response.Content);
            var imdbIdOk = filmInfoReturned.Response;
            Int32 count = 0;
            string numberOfZeroes = "0";
            string newImdbId = "tt";

            while (imdbIdOk == false)
            {
                newImdbId = "tt" + numberOfZeroes.PadRight(count, '0') + imdbId;
                newImdbId = newImdbId.Replace(" ", string.Empty);
                client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + newImdbId);
                //request = new RestRequest(Method.GET);
                //request.AddHeader("x-rapidapi-key", "2951edd025mshf1b0f9ca8a52c6ap1e71e9jsn67c827bdd770");
                //request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
                response = client.Execute(request);
                filmInfoReturned = new clsIMDBApi();
                filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsIMDBApi>(response.Content);
                imdbIdOk = filmInfoReturned.Response;
                count++;
            }
            
            imgFilmPoster.ImageUrl = filmInfoReturned.Poster;
            lblTitle.Text = filmInfoReturned.Title + " (" + filmInfoReturned.Year + ")";
            lblPlot.Text = filmInfoReturned.Plot;   
            lblGenre.Text = filmInfoReturned.Genre;
            lblAgeRating.Text = filmInfoReturned.Rated;
            lblDirector.Text = filmInfoReturned.Director;
            lblRuntime.Text = filmInfoReturned.Runtime;
            lblReleased.Text = filmInfoReturned.Released;
            //hyplnkMoreInformation.NavigateUrl = "https://www.imdb.com/title/" + newImdbId + "/";
            hyplnkMoreInformation.NavigateUrl = "https://www.imdb.com/title/tt0114709/";
            hyplnkMoreInformation.Text = "Click here";

            clsFavouriteFilm aFavouriteFilm = new clsFavouriteFilm();
            if (aFavouriteFilm.Find(userId, filmId) == true)
            {
                filmInFavourites = true;
                imgbtnFavourite.ImageUrl = "Images/FavouriteInList.png";
            }

            clsWatchList aWatchListFilm = new clsWatchList();
            if (aWatchListFilm.Find(userId, filmId) == true)
            {
                filmInWatchList = true;
                imgbtnWatchLater.ImageUrl = "Images/WatchLaterAdded.png";
            }

            clsFilmRatingCollection AllRatings = new clsFilmRatingCollection();
            bool found = AllRatings.ThisFilmRating.Find(filmId, userId);
            if (found)
            {
                ddlRating.SelectedValue = Convert.ToString(AllRatings.ThisFilmRating.Rating);
                ratingExists = true;
            }
            else
            {
                ratingExists = false;
            }
                
                
            pnlFilmInformation.Visible = true;
            
        }
        void DisplayUserAssignedMoods()
        {
            pnlMyTags.Controls.Clear();
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblFilmMood_FilterByUserIdAndFilmId");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            
            if (recordCount !=0)
            {
                while (index < recordCount)
                {  
                    Panel pnlTag = new Panel();
                    pnlTag.CssClass = "tagWholeContainer";

                    Panel pnlTextContainer = new Panel();
                    pnlTextContainer.CssClass = "textcontainer";
                    Label lblTag = new Label();
                    lblTag.Text = DB.DataTable.Rows[index]["Description"].ToString();
                    pnlTextContainer.Controls.Add(lblTag);
                    pnlTag.Controls.Add(pnlTextContainer);

                    Panel pnlRemoveContainer = new Panel();
                    pnlRemoveContainer.CssClass = "removeContainer";
                    ImageButton imgbtnRemoveTag = new ImageButton();
                    imgbtnRemoveTag.CssClass = "image";
                    imgbtnRemoveTag.ImageUrl = "Images/Remove.png";
                    imgbtnRemoveTag.OnClientClick = "return btnRemoveTag_Clicked()";
                    imgbtnRemoveTag.CommandArgument = DB.DataTable.Rows[index]["MoodId"].ToString();
                    imgbtnRemoveTag.Command += ImgbtnRemoveTag_Command;

                    pnlRemoveContainer.Controls.Add(imgbtnRemoveTag);
                    pnlTag.Controls.Add(pnlRemoveContainer);

                    pnlMyTags.Controls.Add(pnlTag);
                
                    index++;
                }
            }
            else
            {
                pnlMyTags.Visible = false;
            }
        }

        protected void ImgbtnRemoveTag_Command(object sender, CommandEventArgs e)
        {
            clsFilmMoodCollection AllFilmMoods = new clsFilmMoodCollection();
            AllFilmMoods.ThisFilmMood.UserId = userId;
            AllFilmMoods.ThisFilmMood.FilmId = filmId;
            AllFilmMoods.ThisFilmMood.MoodId = Convert.ToInt32(e.CommandArgument);
            AllFilmMoods.Delete();

            DisplayUserAssignedMoods();

        }

        void DisplayAllMoods()
        {
            clsMoodCollection AllMoods = new clsMoodCollection();
            ddlFilmMoods.DataSource = AllMoods.AllMoods;
            ddlFilmMoods.DataValueField = "MoodId";
            ddlFilmMoods.DataTextField = "MoodDesc";
            ddlFilmMoods.DataBind();
        }

        protected void btnAssignTag_Click(object sender, EventArgs e)
        {
            clsFilmMoodCollection aFilmMood = new clsFilmMoodCollection();
            aFilmMood.ThisFilmMood.UserId = userId;
            aFilmMood.ThisFilmMood.FilmId = filmId;
            aFilmMood.ThisFilmMood.MoodId = Convert.ToInt32(ddlFilmMoods.SelectedItem.Value);
            aFilmMood.Add();

            DisplayUserAssignedMoods();
        }
        
        protected void imgbtnFavourite_Click(object sender, ImageClickEventArgs e)
        {
            clsFavouriteFilmCollection AllFavouriteFilms = new clsFavouriteFilmCollection();
            AllFavouriteFilms.ThisFavouriteFilm.UserId = userId;
            AllFavouriteFilms.ThisFavouriteFilm.FilmId = filmId;

            if (filmInFavourites == false)
            {
                AllFavouriteFilms.Add();
                imgbtnFavourite.ImageUrl = "Images/FavouriteInList.png";
            }
            else
            {
                AllFavouriteFilms.Delete();
                imgbtnFavourite.ImageUrl = "Images/Favourite.png";
            }            
        }

        protected void imgbtnWatchLater_Click(object sender, ImageClickEventArgs e)
        {
            clsWatchListCollection AllFilmsInWatchList = new clsWatchListCollection();
            AllFilmsInWatchList.ThisWatchListFilm.UserId = userId;
            AllFilmsInWatchList.ThisWatchListFilm.FilmId = filmId;

            if (filmInWatchList == false)
            {
                AllFilmsInWatchList.Add();
                imgbtnWatchLater.ImageUrl = "Images/WatchLaterAdded.png";
            }
            else
            {
                AllFilmsInWatchList.Delete();
                imgbtnWatchLater.ImageUrl ="Images/WatchLater.png";
            }
        }

        protected void btnAddEditRating_Click(object sender, EventArgs e)
        {
        }

        protected void ddlRating_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsFilmRatingCollection AllRatings = new clsFilmRatingCollection();
            AllRatings.ThisFilmRating.UserId = userId;
            AllRatings.ThisFilmRating.FilmId = filmId;
            AllRatings.ThisFilmRating.Rating = float.Parse(ddlRating.SelectedValue);

            if (ratingExists == true)
            {
                AllRatings.Update();
            }
            else
            {
                AllRatings.Add();
            }
        }
    }
}