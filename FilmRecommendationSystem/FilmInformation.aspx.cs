using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;
using Classes;

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
            if (!IsPostBack)
            {
                pnlError.Visible = false;
                //pnlFilmInformation.Visible = false;
                //string imdbId = Request.QueryString["imdbId"];
                string imdbId;
                //userId = 1;
                //filmId = 1; //Session object required here 
                imdbId = "tt0114709";

                DisplayFilm(imdbId);
                //DisplayUserAssignedMoods();

                //DisplayAllMoods();

            }

        }

        void DisplayFilm(string imdbId)
        {
            var client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + imdbId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "2951edd025mshf1b0f9ca8a52c6ap1e71e9jsn67c827bdd770");
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            clsIMDBApi filmInfoReturned = new clsIMDBApi();

            if (response.Content.Contains("False"))
            {
                pnlError.Visible = true;
            }
            else
            {
                filmInfoReturned = new clsIMDBApi();
                filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsIMDBApi>(response.Content);
                imgFilmPoster.ImageUrl = filmInfoReturned.Poster;
                lblTitle.Text = filmInfoReturned.Title + " (" + filmInfoReturned.Year + ")";
                lblPlot.Text = filmInfoReturned.Plot;   
                lblGenre.Text = filmInfoReturned.Genre;
                lblAgeRating.Text = filmInfoReturned.Rated;
                lblDirector.Text = filmInfoReturned.Director;
                lblRuntime.Text = filmInfoReturned.Runtime;
                lblReleased.Text = filmInfoReturned.Released;

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
                if (found == true)
                {
                    ddlRating.SelectedValue = Convert.ToString(AllRatings.ThisFilmRating.Rating);
                    btnAddEditRating.Text = "UPDATE RATING";
                    ratingExists = true;
                }
                else
                {
                    btnAddEditRating.Text = "ADD RATING";
                    ratingExists = false;
                }
                
                
                pnlFilmInformation.Visible = true;
            }
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
                    ImageButton imgbtnRemove = new ImageButton();
                    imgbtnRemove.CssClass = "image";
                    imgbtnRemove.ImageUrl = "Images/Remove.png";
                    imgbtnRemove.CommandArgument = DB.DataTable.Rows[index]["MoodId"].ToString();
                    imgbtnRemove.OnClientClick = "return btnRemoveTag_Clicked()";
                    imgbtnRemove.Command += ImgbtnRemove_Command;
                    pnlRemoveContainer.Controls.Add(imgbtnRemove);
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

        void DisplayAllMoods()
        {
            clsMoodCollection AllMoods = new clsMoodCollection();
            //AllMoods.AllMoods.Sort();
            ddlFilmMoods.DataSource = AllMoods.AllMoods;
            ddlFilmMoods.DataValueField = "MoodId";
            ddlFilmMoods.DataTextField = "MoodDesc";
            ddlFilmMoods.DataBind();
        }

        private void ImgbtnRemove_Command(object sender, CommandEventArgs e)
        {
            clsFilmMoodCollection AllFilmMoods = new clsFilmMoodCollection();
            AllFilmMoods.ThisFilmMood.UserId = userId;
            AllFilmMoods.ThisFilmMood.FilmId = filmId;
            AllFilmMoods.ThisFilmMood.MoodId = Convert.ToInt32(e.CommandArgument);
            AllFilmMoods.Delete();

            DisplayUserAssignedMoods();
        }

        protected void btnAssignTag_Click(object sender, EventArgs e)
        {
            clsFilmMoodCollection aFilmMood = new clsFilmMoodCollection();
            aFilmMood.ThisFilmMood.UserId = userId;
            aFilmMood.ThisFilmMood.MoodId = Convert.ToInt32(ddlFilmMoods.SelectedItem.Value);
            aFilmMood.Add();
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