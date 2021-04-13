using Classes;
using RestSharp;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;

namespace FilmRecommendationSystem
{
    public class clsImdbAPI
    {
        public string Title {get; set; }
        public string Year {get; set; }
        public string Rated { get; set; }
        public string Released {get; set;}
        public string Plot { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Runtime { get; set; }
        public string Poster { get; set; }
        public string ImdbId { get; set; }
        public bool Response {get; set;}

        private Int32 userId;
        
        public Panel GetImdbInformation(Int32 filmId)
        {
            clsLinkCollection AllLinks = new clsLinkCollection();
            AllLinks.ThisLink.FilmId = filmId;
            AllLinks.GetLinkByFilmId();
            string imdbId = AllLinks.ThisLink.ImdbId.ToString();
            
            var client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + imdbId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", ConfigurationManager.AppSettings["RapidApiKey"]);
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            clsImdbAPI filmInfoReturned = new clsImdbAPI();
            filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsImdbAPI>(response.Content);
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
                request.AddHeader("x-rapidapi-key", ConfigurationManager.AppSettings["RapidApiKey"]);
                request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
                response = client.Execute(request);
                filmInfoReturned = new clsImdbAPI();
                filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsImdbAPI>(response.Content);
                imdbIdOk = filmInfoReturned.Response;
                count++;
            }

            Panel pnlFilm = new Panel();
            pnlFilm.CssClass = "filmWithTextContainer";

            ImageButton newClickableImage = new ImageButton();
            newClickableImage.CssClass = "image";
            newClickableImage.ImageUrl = filmInfoReturned.Poster;
            newClickableImage.PostBackUrl = "FilmInformation.aspx?FilmId=" + filmId + "&ImdbId=" + newImdbId;
            
            Panel pnlFilmTitle = new Panel();
            pnlFilmTitle.CssClass = "titleContainer";
            Label lblFilmTitle = new Label();
            lblFilmTitle.Text = filmInfoReturned.Title;

            pnlFilmTitle.Controls.Add(lblFilmTitle);
            pnlFilm.Controls.Add(newClickableImage);
            pnlFilm.Controls.Add(pnlFilmTitle);

            return pnlFilm;
        }

        public Panel GetImdbInformationWithOptions(Int32 filmId, string title, Int32 userId, bool favourite, bool displayOverlay)
        {
            this.userId = userId;
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblLinksFilterByFilmId");

            string imdbId = DB.DataTable.Rows[0]["ImdbId"].ToString();

            var client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + imdbId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", ConfigurationManager.AppSettings["RapidApiKey"]);
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            clsImdbAPI filmInfoReturned = new clsImdbAPI();
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

            Panel pnlFilm = new Panel();
            pnlFilm.CssClass = "filmWithTextContainer";

            ImageButton imgbtnFilmPoster = new ImageButton();
            imgbtnFilmPoster.CssClass = "image";
            imgbtnFilmPoster.ImageUrl = filmInfoReturned.Poster;
            imgbtnFilmPoster.PostBackUrl = "FilmInformation.aspx?FilmId=" + filmId + "&ImdbId=" + newImdbId;

            pnlFilm.Controls.Add(imgbtnFilmPoster);


            if (displayOverlay)
            {
                Panel pnlOverlay = new Panel();
                pnlOverlay.CssClass = "overlay";
                ImageButton imgbtnRemove = new ImageButton();
                imgbtnRemove.ImageUrl = "Images/Remove.png";
                imgbtnRemove.CssClass = "overlay-itemRight";

                if (favourite == true)
                {
                    imgbtnRemove.CommandArgument = filmId.ToString();
                    imgbtnRemove.Command += RemoveFromFavourites; 
                }
                else
                {
                    imgbtnRemove.CommandArgument = filmId.ToString();
                    imgbtnRemove.Command += RemoveFromWatchList;
                }
                pnlOverlay.Controls.Add(imgbtnRemove);
                pnlFilm.Controls.Add(pnlOverlay);
            }
            
            Panel pnlFilmTitle = new Panel();
            pnlFilmTitle.CssClass = "titleContainer"; 
            Label lblFilmTitle = new Label();
            lblFilmTitle.Text = title;
            lblFilmTitle.ToolTip = title;
            pnlFilmTitle.Controls.Add(lblFilmTitle);
            pnlFilm.Controls.Add(pnlFilmTitle);

            return pnlFilm;
        }

        private void RemoveFromWatchList(object sender, CommandEventArgs e)
        {
            string filmId = e.CommandArgument.ToString();
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblWatchList_Delete");
            HttpContext.Current.Response.Redirect("WatchList.aspx");
        }

        private void RemoveFromFavourites(object sender, CommandEventArgs e)
        {
            string filmId = e.CommandArgument.ToString();
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblFavouriteFilms_Delete");
            HttpContext.Current.Response.Redirect("FavouriteFilms.aspx");
        }
    }
}