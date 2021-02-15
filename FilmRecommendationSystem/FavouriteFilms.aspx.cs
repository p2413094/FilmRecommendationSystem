using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace FilmRecommendationSystem
{
    public partial class FavouriteFilms : System.Web.UI.Page
    {
        Int32 userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            pnlFavouriteFilms.Visible = false;
            userId = 1; //Request.QueryString["UserId"];
            DisplayFavouriteFilms();
            //TempRecommendations();
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
                while (index < recordCount)
                {
                    filmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                    title = DB.DataTable.Rows[index]["Title"].ToString();
                    GetImdbInformation(filmId, title);
                    index++;
                }
                pnlFavouriteFilms.Visible = true;
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
            string filmId = e.CommandArgument.ToString();
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblFavouriteFilms_Delete");

            DisplayFavouriteFilms();
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

            Int32 filmId = 1;
            string stringFilmId = Convert.ToString(filmId);
            imgbtnRemove.CommandArgument = stringFilmId;

            ImageButton imgbtnWatchList = new ImageButton();
            imgbtnWatchList.CssClass = "overlay-itemRight";
            imgbtnWatchList.CommandArgument = filmId.ToString();

            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("FilmId", filmId);
            DB.Execute("sproc_tblWatchList_SelectByUserAndFilmId");
            
            if (DB.Count != 1)
            {
                imgbtnWatchList.ImageUrl = "Images/NotInWatchLater.png";
                imgbtnWatchList.Command += imgbtnWatchList_AddToWatchList;
            }
            else
            {
                imgbtnWatchList.ImageUrl = "Images/WatchLaterAdded.png";
                imgbtnWatchList.Command += imgbtnWatchList_RemoveFromWatchList;
            }

            pnlOverlay.Controls.Add(imgbtnWatchList);
            pnlOverlay.Controls.Add(imgbtnRemove);
            pnlFilm.Controls.Add(pnlOverlay);
            pnlFavouriteFilms.Controls.Add(pnlFilm);


            pnlFavouriteFilms.Visible = true;
        }
    }
}