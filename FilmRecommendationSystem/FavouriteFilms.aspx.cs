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
                bool favourite = false;
                bool displayOverlay = true;
                while (index < recordCount)
                {
                    filmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                    title = DB.DataTable.Rows[index]["Title"].ToString();
                    pnlFavouriteFilms.Controls.Add(anImdbApi.GetImdbInformationWithOptions(filmId, title, userId, favourite, displayOverlay));
                    index++;
                }
            }
            pnlFavouriteFilms.Visible = true;
        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }
    }
}