using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace FilmRecommendationSystem
{
    public partial class SearchResults : System.Web.UI.Page
    {
        string searchText;
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            searchText = Request.QueryString["searchText"];//Session["searchText"].ToString();

            CheckIfUserIsLoggedIn();

            clsFilmCollection AllFilms = new clsFilmCollection();
            Panel pnlSearchResult = new Panel();
            HyperLink hyplnkSearchResultTitle = new HyperLink();

            if (AllFilms.SearchForFilm(searchText).Count != 0)
            {
                foreach (clsFilm aFilm in AllFilms.SearchForFilm(searchText))
                {
                    pnlSearchResult = new Panel();
                    pnlSearchResult.CssClass = "searchResultsContainer";
                    hyplnkSearchResultTitle = new HyperLink();

                    hyplnkSearchResultTitle.Text = aFilm.Title;

                    clsDataConnection DB = new clsDataConnection();
                    DB.AddParameter("@FilmId", aFilm.FilmId);
                    DB.Execute("sproc_tblLinksFilterByFilmId");
                    hyplnkSearchResultTitle.NavigateUrl = "FilmInformation.aspx?ImdbId=" + DB.DataTable.Rows[0]["ImdbId"].ToString();
                                        
                    pnlSearchResult.Controls.Add(hyplnkSearchResultTitle);
                    pnlAllSearchResults.Controls.Add(pnlSearchResult);
                }
            }
            else
            {
                pnlSearchResult = new Panel();
                pnlSearchResult.CssClass = "searchResultsContainer";
                hyplnkSearchResultTitle = new HyperLink();
                
                hyplnkSearchResultTitle.Text = "No titles to display";
            }
        }

        void CheckIfUserIsLoggedIn()
        {
            //bool userLoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            bool userLoggedIn = HttpContext.Current.User.Identity.IsAuthenticated;
            if (userLoggedIn)
            {
                clsDynamicPanel aDynamicPanel = new clsDynamicPanel();
                pnlNavBar.Controls.Clear();
                pnlNavBar.CssClass = "navbar";
                pnlNavBar.Controls.Add(aDynamicPanel.GenerateMyAccountDropDown());
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

    }
}