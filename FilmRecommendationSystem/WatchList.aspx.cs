using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using Classes;

namespace FilmRecommendationSystem
{
    public partial class WatchList : System.Web.UI.Page
    {
        List<clsFilm> FilmList = new List<clsFilm>();
        clsFilm aFilm = new clsFilm();
        Int32 userId = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            pnlWatchList.Visible = false;
            //userId = //this would normally be done dynamically 
            DisplayWatchLaterFilms(userId);

            //TempRecommendations();
        }

        void TempRecommendations()
        {
            Panel pnlFilm = new Panel();
            pnlFilm.CssClass = "imagewithtext";

            ImageButton imgbtnFilmPoster = new ImageButton();
            imgbtnFilmPoster.CssClass = "image";
            imgbtnFilmPoster.ImageUrl = "Images/King Kong.jpg";
            pnlFilm.Controls.Add(imgbtnFilmPoster);

            Panel pnlFilmTitle = new Panel();
            pnlFilmTitle.CssClass = "textcontainer";
            Label lblFilmTitle = new Label();
            lblFilmTitle.Text = "Test";
            pnlFilmTitle.Controls.Add(lblFilmTitle);
            pnlFilm.Controls.Add(pnlFilmTitle);

            Panel pnlOverlay = new Panel();
            pnlOverlay.CssClass = "overlay";

            ImageButton imgbtnRemove = new ImageButton();
            imgbtnRemove.ImageUrl = "Images/Remove.png";
            imgbtnRemove.CssClass = "overlay-itemLeft";
            imgbtnRemove.Command += ImgbtnRemove_Command;

            pnlOverlay.Controls.Add(imgbtnRemove);
            pnlFilm.Controls.Add(pnlOverlay);
            pnlWatchList.Controls.Add(pnlFilm);

            pnlWatchList.Visible = true;
        }

        void GetFilmNames (Int32 filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblFilm_FilterByFilmId");
            aFilm = new clsFilm();
            aFilm.FilmId = Convert.ToInt32(DB.DataTable.Rows[0]["FilmId"]);
            aFilm.Title = DB.DataTable.Rows[0]["Title"].ToString();
            FilmList.Add(aFilm);
        }

        private void ButtonSort_Click(object sender, EventArgs e)
        {
            FilmList.Sort();
            pnlWatchList.Controls.Clear();

            foreach (clsFilm aFilm in FilmList)
            {
                GetImdbInformation(aFilm.FilmId, aFilm.Title);
            }
        }

        void DisplayWatchLaterFilms(Int32 userId)
        {
            pnlWatchList.Controls.Clear();
            try
            {
                clsDataConnection DB = new clsDataConnection();
                DB.AddParameter("@UserId", userId);
                DB.Execute("sproc_tblWatchList_FilterByUserId");
                Int32 recordCount = DB.Count;
                Int32 index = 0;
                Int32 filmId = 0;
                string title;
                while (index < recordCount)
                {
                    filmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                    title = DB.DataTable.Rows[index]["Title"].ToString();
                    GetFilmNames(filmId);
                    GetImdbInformation(filmId, title);
                    index++;
                }

                pnlWatchList.Visible = true;
            }
            catch
            {
                pnlError.Visible = true;
            }
        }

        void GetImdbInformation(Int32 filmId, string title)
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

            while (imdbIdOk == false)
            {
                newImdbId = "tt" + numberOfZeroes.PadRight(count, '0') + imdbId;
                newImdbId = newImdbId.Replace(" ", string.Empty);
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

            Panel pnlFilm = new Panel();
            pnlFilm.CssClass = "imagewithtext";

            ImageButton imgbtnFilmPoster = new ImageButton();
            imgbtnFilmPoster.CssClass = "image";
            imgbtnFilmPoster.ImageUrl = filmInfoReturned.Poster;
            imgbtnFilmPoster.PostBackUrl = "FilmInformation.aspx?ImdbId=" + newImdbId;

            pnlFilm.Controls.Add(imgbtnFilmPoster);

            Panel pnlFilmTitle = new Panel();
            pnlFilmTitle.CssClass = "textcontainer";
            Label lblFilmTitle = new Label();
            lblFilmTitle.Text = title;
            pnlFilmTitle.Controls.Add(lblFilmTitle);
            pnlFilm.Controls.Add(pnlFilmTitle);

            Panel pnlOverlay = new Panel();
            pnlOverlay.CssClass = "overlay";

            ImageButton imgbtnRemove = new ImageButton();
            imgbtnRemove.ImageUrl = "Images/Remove.png";
            imgbtnRemove.CssClass = "overlay-itemLeft";
            imgbtnRemove.Command += ImgbtnRemove_Command;

            string stringFilmId = Convert.ToString(filmId);
            imgbtnRemove.CommandArgument = stringFilmId;

            pnlOverlay.Controls.Add(imgbtnRemove);
            pnlFilm.Controls.Add(pnlOverlay);
            pnlWatchList.Controls.Add(pnlFilm);

            pnlWatchList.Visible = true;
        }

        private void ImgbtnRemove_Command(object sender, CommandEventArgs e)
        {
            string filmId = e.CommandArgument.ToString();

            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblWatchList_Delete");

            DisplayWatchLaterFilms(userId);
        }
    }
}