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
        clsImdbAPI anImdbApi = new clsImdbAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            //pnlError.Visible = false;
            //pnlRecommendations.Visible = false;
            Int32 userId = 1;
            //DisplayRecommendedFilms(userId);
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
        
        void DisplayRecommendedFilms(Int32 userId)
        {
            try
            {
                clsDataConnection DB = new clsDataConnection();
                DB.AddParameter("@UserId", userId);
                DB.Execute("sproc_tblFilmRecommendation_FilterByUserId");
                Int32 recordCount = DB.Count;
                Int32 index = 0;
                Int32 filmId = 0;
                if (recordCount == 0)
                {
                    Label lblNoRecommendedFilms = new Label();
                    lblNoRecommendedFilms.CssClass = "italicised";
                    lblNoRecommendedFilms.Text = "No recommended films";
                    pnlRecommendations.Controls.Add(lblNoRecommendedFilms);
                }
                else
                {
                    while (index < recordCount)
                    {
                        filmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                        pnlRecommendations.Controls.Add(anImdbApi.GetImdbInformation(filmId));
                        index++;
                    }
                }
                pnlRecommendations.Visible = true;
            }
            catch
            {
                pnlError.Visible = true;
            }
        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }
    }
}