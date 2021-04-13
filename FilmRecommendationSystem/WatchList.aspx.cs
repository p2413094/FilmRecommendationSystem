using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using Classes;
using System.Drawing;
using System.Configuration;

namespace FilmRecommendationSystem
{
    public partial class WatchList : System.Web.UI.Page
    {
        List<clsFilm> FilmList = new List<clsFilm>();
        clsFilm aFilm = new clsFilm();
        clsImdbAPI anImdbApi= new clsImdbAPI();
        Int32 userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            pnlWatchList.Visible = false;
            try
            {
                userId = 1; //Convert.ToInt32(Session["UserId"]);
                DisplayWatchLaterFilms(userId);
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
                if (recordCount == 0)
                {
                    clsDynamicPanel aDynamicPanel = new clsDynamicPanel();
                    pnlWatchList.Controls.Add(aDynamicPanel.GenerateEmptyListPanel("watch list"));
                    btnSort.Visible = false;
                }
                else
                {
                    while (index < recordCount)
                    {
                        filmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                        title = DB.DataTable.Rows[index]["Title"].ToString();
                        pnlWatchList.Controls.Add(GetImdbInformation(filmId, title));                    
                        index++;
                    }

                }
                pnlWatchList.Visible = true;
            }
            catch
            {
                pnlError.Visible = true;
            }
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
            DB.Execute("sproc_tblWatchList_Delete");

            DisplayWatchLaterFilms(userId);
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            FilmList.Sort();
            pnlWatchList.Controls.Clear();

            foreach (clsFilm aFilm in FilmList)
            {
                //GetImdbInformation(aFilm.FilmId, aFilm.Title);
            }

        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }
    }
}