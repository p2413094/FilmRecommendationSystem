using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Classes;

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

    }
}