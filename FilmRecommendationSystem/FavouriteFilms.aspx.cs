using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Configuration;

namespace FilmRecommendationSystem
{
    public partial class FavouriteFilms : System.Web.UI.Page
    {
        Int32 userId;
        clsImdbAPI anImdbApi = new clsImdbAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            pnlFavouriteFilms.Visible = true;
            userId = Convert.ToInt32(Session["UserId"]);
            DisplayFavouriteFilms();
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


        private void imgbtnWatchList_AddToWatchList(object sender, CommandEventArgs e)
        {
            string filmId = e.CommandArgument.ToString();
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblWatchList_Insert");

            DisplayFavouriteFilms();
        }

        private void imgbtnWatchList_RemoveFromWatchList(object sender, CommandEventArgs e)
        {
            string filmId = e.CommandArgument.ToString();
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblWatchList_Delete");

            DisplayFavouriteFilms();
        }

        void DisplayFavouriteFilms()
        {
            pnlFavouriteFilms.Controls.Clear();
            try
            {
                clsDataConnection DB = new clsDataConnection();
                DB.AddParameter("@UserId", userId);
                DB.Execute("sproc_tblFavouriteFilms_FilterByUserId");
                Int32 recordCount = DB.Count;
                Int32 index = 0;
                Int32 filmId = 0;
                string title;
                if (recordCount == 0)
                {
                    clsDynamicPanel aDynamicPanel = new clsDynamicPanel();
                    pnlFavouriteFilms.Controls.Add(aDynamicPanel.GenerateEmptyListPanel("favourite films"));
                }
                else
                {
                    while (index < recordCount)
                    {
                        filmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                        title = DB.DataTable.Rows[index]["Title"].ToString();
                        pnlFavouriteFilms.Controls.Add(anImdbApi.GetImdbInformation(filmId));
                        index++;
                    }
                }
                pnlFavouriteFilms.Visible = true;
            }
            catch
            {
                pnlError.Visible = true;
            }
        }


        //the vast majority of this could be added to clsIMDB as a function and have it return a clsIMDB with the returned film information 
        void GetImdbInformation(Int32 filmId, string title)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblLinksFilterByFilmId");

            string imdbId = DB.DataTable.Rows[0]["ImdbId"].ToString();

            var client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + imdbId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", ConfigurationManager.AppSettings["RapidApiKey"]);
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            clsIMDBApi filmInfoReturned = new clsIMDBApi();
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
                //request.AddHeader("x-rapidapi-key", ConfigurationManager.AppSettings["RapidApiKey"]);
                //request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
                response = client.Execute(request);
                filmInfoReturned = new clsIMDBApi();
                filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsIMDBApi>(response.Content);
                imdbIdOk = filmInfoReturned.Response;
                count++;
            }

            Panel pnlFilm = new Panel();
            pnlFilm.CssClass = "filmWithTextContainer";

            ImageButton imgbtnFilmPoster = new ImageButton();
            imgbtnFilmPoster.CssClass = "image";
            imgbtnFilmPoster.ImageUrl = filmInfoReturned.Poster;
            imgbtnFilmPoster.PostBackUrl = "FilmInformation.aspx?ImdbId=" + newImdbId;

            pnlFilm.Controls.Add(imgbtnFilmPoster);

            Panel pnlFilmTitle = new Panel();
            pnlFilmTitle.CssClass = "textContainer";
            Label lblFilmTitle = new Label();
            lblFilmTitle.Text = title;
            pnlFilmTitle.Controls.Add(lblFilmTitle);
            pnlFilm.Controls.Add(pnlFilmTitle);

            Panel pnlOverlay = new Panel();
            pnlOverlay.CssClass = "overlay";

            ImageButton imgbtnRemove = new ImageButton();
            imgbtnRemove.ImageUrl = "Images/Remove.png";
            imgbtnRemove.CssClass = "overlay-itemLeft";
            imgbtnRemove.CommandArgument = filmId.ToString();
            imgbtnRemove.Command += ImgbtnRemove_Command;
            
            ImageButton imgbtnWatchList = new ImageButton();
            imgbtnWatchList.CssClass = "overlay-itemRight";
            imgbtnWatchList.CommandArgument = filmId.ToString();

            clsDataConnection DB_2 = new clsDataConnection();
            DB_2.AddParameter("@UserId", userId);
            DB_2.AddParameter("@FilmId", filmId);
            DB_2.Execute("sproc_tblWatchList_SelectByUserAndFilmId");
            
            if (DB_2.Count == 1)
            {
                imgbtnWatchList.ImageUrl = "Images/WatchLaterAdded.png";
                imgbtnWatchList.Command += imgbtnWatchList_RemoveFromWatchList;
            }
            else
            {
                imgbtnWatchList.ImageUrl = "Images/NotInWatchLater.png";
                imgbtnWatchList.Command += imgbtnWatchList_AddToWatchList;
            }

            pnlOverlay.Controls.Add(imgbtnWatchList);
            pnlOverlay.Controls.Add(imgbtnRemove);
            pnlFilm.Controls.Add(pnlOverlay);
            pnlFavouriteFilms.Controls.Add(pnlFilm);


            pnlFavouriteFilms.Visible = true;
        }

        private void ImgbtnRemove_Command(object sender, CommandEventArgs e)
        {
            //could pass in multiple values here, i.e. the filmId and the container for 
            //later deletion 
                //see https://stackoverflow.com/questions/2389258/passing-multiple-argument-through-commandargument-of-button-in-asp-net

            string filmId = e.CommandArgument.ToString();
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblFavouriteFilms_Delete");


            //you could just try and get the sender's image container and then remove it from view
            //rather than re-querying the IMDB api 
            DisplayFavouriteFilms();
        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }
    }
}