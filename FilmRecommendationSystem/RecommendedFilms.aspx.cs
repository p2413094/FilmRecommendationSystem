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
    public partial class RecommendedFilms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlRecommendations.Visible = false;
            Int32 userId = 1;
            DisplayRecommendedFilms(userId);
        }
        
        void DisplayRecommendedFilms(Int32 userId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.Execute("sproc_tblFilmRecommendation_FilterByUserId");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            Int32 filmId = 0;
            while (index < recordCount)
            {
                filmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                GetImdbInformation(filmId);
                index++;
            }
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

            ImageButton newClickableImage = new ImageButton();
            newClickableImage.ImageUrl = filmInfoReturned.Poster;
            newClickableImage.PostBackUrl = "FilmInformation.aspx?ImdbId=" + newImdbId;

            newClickableImage.CssClass = "image";
            pnlRecommendations.Controls.Add(newClickableImage);
            pnlRecommendations.Visible = true;
        }

    }
}