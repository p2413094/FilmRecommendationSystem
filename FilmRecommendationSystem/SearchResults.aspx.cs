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
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlAllSearchResults.Visible = false;
            pnlError.Visible = false;

            if (!IsPostBack)
            {
                try
                {
                    string searchText = Request.QueryString["searchText"];
                    Session["searchText"] = searchText;
                    CheckIfUserIsLoggedIn();

                    clsFilmCollection AllFilms = new clsFilmCollection();
                    clsDataConnection DB = new clsDataConnection();
                    clsDynamicPanel aDynamicPanel = new clsDynamicPanel();

                    if (AllFilms.SearchForFilm(searchText).Count != 0)
                    {
                        foreach (clsFilm aFilm in AllFilms.SearchForFilm(searchText))
                        {
                            DB = new clsDataConnection();
                            DB.AddParameter("@FilmId", aFilm.FilmId);
                            DB.Execute("sproc_tblLinksFilterByFilmId");
                                        
                            string imdbId = DB.DataTable.Rows[0]["ImdbId"].ToString();
                            pnlActualSearchResults.Controls.Add(aDynamicPanel.GenerateSearchResultsPanel(aFilm.Title, imdbId));
                        }
                        GenerateMoods();
                        pnlAllSearchResults.Visible = true;
                    }
                    else
                    {
                        pnlActualSearchResults.Controls.Clear();
                        pnlActualSearchResults.Controls.Add(aDynamicPanel.GenerateEmptySearchResultsPanel());
                    }
                }
                catch
                {
                    pnlError.Visible = true;
                }
            }
        }

        void GenerateMoods()
        {
            clsMoodCollection AllMoods = new clsMoodCollection();
            ddlMoods.DataSource = AllMoods.AllMoods;
            ddlMoods.DataValueField = "MoodId";
            ddlMoods.DataTextField = "MoodDesc";
            ddlMoods.DataBind();

        }

        void CheckIfUserIsLoggedIn()
        {
            bool userLoggedIn = HttpContext.Current.User.Identity.IsAuthenticated;
            if (userLoggedIn)
            {
                clsDynamicPanel aDynamicPanel = new clsDynamicPanel();
                pnlNavBar.Controls.Clear();
                pnlNavBar.CssClass = "navbar";
                pnlNavBar.Controls.Add(aDynamicPanel.GenerateMyAccountDropDown());
            }
        }

        protected void ddlGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 genreId = ddlGenre.SelectedIndex;
            clsDataConnection DB = new clsDataConnection();
            clsDynamicPanel aDynamicPanel = new clsDynamicPanel();

            string searchText = Session["searchText"].ToString();

            DB.AddParameter("@Title", searchText);
            DB.AddParameter("@GenreId", genreId);
            DB.Execute("sproc_tblFilm_CollateWithTblFilmGenreAndLinks");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            if (recordCount != 0)
            {
                pnlActualSearchResults.Controls.Clear();
                while (index < recordCount)
                {
                    string title = DB.DataTable.Rows[index]["Title"].ToString();
                    string imdbId = DB.DataTable.Rows[index]["ImdbId"].ToString();

                    pnlActualSearchResults.Controls.Add(aDynamicPanel.GenerateSearchResultsPanel(title, imdbId));
                    index++;
                }
            }
            else
            {
                pnlActualSearchResults.Controls.Clear();
                pnlActualSearchResults.Controls.Add(aDynamicPanel.GenerateEmptySearchResultsPanel());
            }
            pnlAllSearchResults.Visible = true;
        }

        protected void ddlMood_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 moodId = Convert.ToInt32(ddlMoods.SelectedItem.Value);
            clsDataConnection DB = new clsDataConnection();
            string searchText = Session["searchText"].ToString();
            clsDynamicPanel aDynamicPanel = new clsDynamicPanel();

            DB.AddParameter("@Title", searchText);
            DB.AddParameter("@MoodId", moodId);
            DB.Execute("sproc_tblFilm_CollateWithTblFilmMoodAndLinks");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            if (recordCount != 0)
            {
                pnlActualSearchResults.Controls.Clear();
                while (index < recordCount)
                {
                    string title = DB.DataTable.Rows[index]["Title"].ToString();
                    string imdbId = DB.DataTable.Rows[index]["ImdbId"].ToString();

                    pnlActualSearchResults.Controls.Add(aDynamicPanel.GenerateSearchResultsPanel(title, imdbId));
                    index++;
                }
            }
            else
            {
                pnlActualSearchResults.Controls.Clear();
                pnlActualSearchResults.Controls.Add(aDynamicPanel.GenerateEmptySearchResultsPanel());
            }
            pnlAllSearchResults.Visible = true;
        }
    }
}