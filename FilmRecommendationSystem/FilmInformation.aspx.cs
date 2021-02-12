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
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            pnlFilmInformation.Visible = false;
            string imdbId; //= Request.QueryString["imdbId"];
            imdbId = "tt0360717";

            GetAndDisplayFilm(imdbId);
        }
        
        void GetAndDisplayFilm(string imdbId)
        {
            var client = new RestClient("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + imdbId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "2951edd025mshf1b0f9ca8a52c6ap1e71e9jsn67c827bdd770");
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);

            if (response.Content.Contains("False"))
            {
                pnlError.Visible = true;
            }
            else
            {
                clsIMDBApi filmInfoReturned = new clsIMDBApi();
                filmInfoReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<clsIMDBApi>(response.Content);
                imgFilmPoster.ImageUrl = filmInfoReturned.Poster;
                lblTitle.Text = filmInfoReturned.Title + " (" + filmInfoReturned.Year + ")";
                lblPlot.Text = filmInfoReturned.Plot;   
                lblGenre.Text = filmInfoReturned.Genre;
                lblAgeRating.Text = filmInfoReturned.Rated;
                lblDirector.Text = filmInfoReturned.Director;
                lblRuntime.Text = filmInfoReturned.Runtime;
                lblReleased.Text = filmInfoReturned.Released;

                pnlFilmInformation.Visible = true;
            }
        }
    }
}