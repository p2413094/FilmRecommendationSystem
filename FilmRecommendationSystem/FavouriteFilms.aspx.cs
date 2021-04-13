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
            try
            {
                userId = Convert.ToInt32(Session["UserId"]);
                DisplayFavouriteFilms();
                pnlFavouriteFilms.Visible = true;

            }
            catch
            {
                pnlError.Visible = true;
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
                    pnlFavouriteFilms.Controls.Add(GetImdbInformation(filmId, title));
                    index++;
                }
            }
            pnlFavouriteFilms.Visible = true;
        }

        Panel GetImdbInformation(Int32 filmId, string title)
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
            imgbtnFilmPoster.PostBackUrl = "FilmInformation.aspx?FilmId=" + filmId + "&ImdbId=" + newImdbId;

            pnlFilm.Controls.Add(imgbtnFilmPoster);

            Panel pnlOverlay = new Panel();
            pnlOverlay.CssClass = "overlay";

            ImageButton imgbtnRemove = new ImageButton();
            imgbtnRemove.ImageUrl = "Images/Remove.png";
            imgbtnRemove.CssClass = "overlay-itemRight";
            imgbtnRemove.CommandArgument = filmId.ToString();
            imgbtnRemove.Command += ImgbtnRemove_Command;
            
            Panel pnlFilmTitle = new Panel();
            pnlFilmTitle.CssClass = "titleContainer"; 
            Label lblFilmTitle = new Label();
            lblFilmTitle.Text = title;
            lblFilmTitle.ToolTip = title;
            pnlFilmTitle.Controls.Add(lblFilmTitle);
            pnlFilm.Controls.Add(pnlFilmTitle);

            pnlOverlay.Controls.Add(imgbtnRemove);
            pnlFilm.Controls.Add(pnlOverlay);

            return pnlFilm;
        }

        private void ImgbtnRemove_Command(object sender, CommandEventArgs e)
        {
            string filmId = e.CommandArgument.ToString();
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblFavouriteFilms_Delete");

            DisplayFavouriteFilms();
        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }
    }
}