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


        List<Panel> test = new List<Panel>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            pnlWatchList.Visible = false;
            try
            {
                userId = Convert.ToInt32(Session["UserId"]);
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
                }
                else
                {
                    bool favourite = false;
                    bool displayOverlay = true;
                    while (index < recordCount)
                    {
                        filmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                        title = DB.DataTable.Rows[index]["Title"].ToString();
                        pnlWatchList.Controls.Add(anImdbApi.GetImdbInformationWithOptions(filmId, title, userId, favourite, displayOverlay));   
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

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }
    }
}