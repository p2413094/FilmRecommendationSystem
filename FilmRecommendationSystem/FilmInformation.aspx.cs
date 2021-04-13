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
        Int32 filmId;
        Int32 userId;
        bool displayOverlayContainer;
        bool filmInFavourites;
        bool filmInWatchList;
        bool ratingExists;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlError.Visible = false;
                pnlFilmInformation.Visible = false;
                btnAssignTag.Enabled = false;

                bool userLoggedIn = HttpContext.Current.User.Identity.IsAuthenticated;
                if (userLoggedIn)
                {
                    displayOverlayContainer = true;
                    Session["displayOverlayContainer"] = displayOverlayContainer;
                    userId = Convert.ToInt32(Session["UserId"]);
                    btnAssignTag.Enabled = true;
                }

                filmId = Convert.ToInt32(Request.QueryString["FilmId"]);
                Session["FilmId"] = filmId;

                CheckIfUserIsLoggedIn();

                DisplayFilm(Request.QueryString["imdbId"]);
                DisplayAllMoods();
                DisplayUserAssignedMoods();
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

        void DisplayFilm(string imdbId)
        {
            var client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + imdbId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", ConfigurationManager.AppSettings["RapidApiKey"]);
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            clsImdbAPI filmInfoReturned = new clsImdbAPI();
            filmInfoReturned = new clsImdbAPI();
            filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsImdbAPI>(response.Content);
            var imdbIdOk = filmInfoReturned.Response;
            Int32 count = 0;
            string numberOfZeroes = "0";
            string newImdbId = "tt";

            while (imdbIdOk == false)
            {
                newImdbId = "tt" + numberOfZeroes.PadRight(count, '0') + imdbId;
                newImdbId = newImdbId.Replace(" ", string.Empty);
                client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + newImdbId);
                response = client.Execute(request);
                filmInfoReturned = new clsImdbAPI();
                filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsImdbAPI>(response.Content);
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
            hyplnkMoreInformation.NavigateUrl = "https://www.imdb.com/title/" + filmInfoReturned.ImdbId + "/";
            hyplnkMoreInformation.Text = "Click here";


            if (displayOverlayContainer)
            {
                clsFavouriteFilm aFavouriteFilm = new clsFavouriteFilm();
                if (aFavouriteFilm.Find(userId, filmId))
                {
                    filmInFavourites = true;
                    Session["filmInFavourites"] = filmInFavourites;
                    imgbtnFavourite.ImageUrl = "Images/FavouriteInList.png";
                }

                clsWatchList aWatchListFilm = new clsWatchList();
                if (aWatchListFilm.Find(userId, filmId))
                {
                    filmInWatchList = true;
                    Session["filmInWatchList"] = filmInWatchList;
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
            }
            else
            {
                pnlFilmOverlay.Visible = false;
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
                pnlMyTags.Visible = true;
            }
            else
            {
                pnlMyTags.Visible = false;
            }
        }

        protected void ImgbtnRemoveTag_Command(object sender, CommandEventArgs e)
        {
            clsFilmMoodCollection AllFilmMoods = new clsFilmMoodCollection();
            AllFilmMoods.ThisFilmMood.UserId = Convert.ToInt32(Session["UserId"]);
            AllFilmMoods.ThisFilmMood.FilmId = Convert.ToInt32(Session["FilmId"]);
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
            aFilmMood.ThisFilmMood.UserId = Convert.ToInt32(Session["UserId"]);
            aFilmMood.ThisFilmMood.FilmId = Convert.ToInt32(Session["FilmId"]);
            aFilmMood.ThisFilmMood.MoodId = Convert.ToInt32(ddlFilmMoods.SelectedItem.Value);
            aFilmMood.Add();

            DisplayUserAssignedMoods();
        }
       
        protected void imgbtnFavourite_Click(object sender, ImageClickEventArgs e)
        {
            clsFavouriteFilmCollection AllFavouriteFilms = new clsFavouriteFilmCollection();
            AllFavouriteFilms.ThisFavouriteFilm.UserId = Convert.ToInt32(Session["UserId"]);
            AllFavouriteFilms.ThisFavouriteFilm.FilmId = Convert.ToInt32(Session["FilmId"]);

            filmInFavourites = Convert.ToBoolean(Session["filmInFavourites"]);
            if (!filmInFavourites)
            {
                AllFavouriteFilms.Add();
                imgbtnFavourite.ImageUrl = "Images/FavouriteInList.png";
                filmInFavourites = true;
            }
            else
            {
                AllFavouriteFilms.Delete();
                imgbtnFavourite.ImageUrl = "Images/Favourite.png";
                filmInFavourites = false;
            }      
            Session["filmInFavourites"] = filmInFavourites;
        }

        protected void imgbtnWatchLater_Click(object sender, ImageClickEventArgs e)
        {
            clsWatchListCollection AllFilmsInWatchList = new clsWatchListCollection();
            AllFilmsInWatchList.ThisWatchListFilm.UserId = Convert.ToInt32(Session["UserId"]);
            AllFilmsInWatchList.ThisWatchListFilm.FilmId = Convert.ToInt32(Session["FilmId"]);

            filmInWatchList = Convert.ToBoolean(Session["filmInWatchList"]);
            if (!filmInWatchList)
            {
                AllFilmsInWatchList.Add();
                imgbtnWatchLater.ImageUrl = "Images/WatchLaterAdded.png";
                filmInWatchList = true;
            }
            else
            {
                AllFilmsInWatchList.Delete();
                imgbtnWatchLater.ImageUrl ="Images/WatchLater.png";
                filmInWatchList = false;
            }
            Session["filmInWatchList"] = filmInWatchList;
        }

        protected void ddlRating_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool userLoggedIn = HttpContext.Current.User.Identity.IsAuthenticated;
            if (userLoggedIn)
            {
                clsFilmRatingCollection AllRatings = new clsFilmRatingCollection();
                AllRatings.ThisFilmRating.UserId = Convert.ToInt32(Session["UserId"]);
                AllRatings.ThisFilmRating.FilmId = Convert.ToInt32(Session["FilmId"]);
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
}