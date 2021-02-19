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
    }
}