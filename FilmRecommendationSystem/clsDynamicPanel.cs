using FilmRecommendationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmRecommendationSystem
{
    public class clsDynamicPanel
    {
        public Panel GenerateSignInRegisterNavbar()
        {
            Panel pnlContainer = new Panel();

            pnlContainer.Controls.Add(new LiteralControl("<ul>"));
            pnlContainer.Controls.Add(new LiteralControl("<li><a href='Register.aspx'>REGISTER</a></li>"));
            pnlContainer.Controls.Add(new LiteralControl("<li><a href='Login.aspx'>SIGN IN</a></li>"));
            pnlContainer.Controls.Add(new LiteralControl("</ul>"));

            return pnlContainer;
        }

        public Panel GenerateMyAccountDropDown()
        {
            Panel pnlSignInRegister = new Panel();
            pnlSignInRegister.CssClass = "dropdown";

            Button btnMyAccount = new Button();
            btnMyAccount.CssClass = "dropbtn";
            btnMyAccount.Text = "MY ACCOUNT";
            btnMyAccount.PostBackUrl = "MyAccount.aspx";
            pnlSignInRegister.Controls.Add(btnMyAccount);

            Panel pnlDropDownContent = new Panel();
            pnlDropDownContent.CssClass = "dropdown-content";

            LinkButton lnkbtnRecommendedFilms = new LinkButton();
            lnkbtnRecommendedFilms.Text = "RECOMMENDATIONS";
            lnkbtnRecommendedFilms.PostBackUrl = "RecommendedFilms.aspx";

            LinkButton lnkbtnWatchList = new LinkButton();
            lnkbtnWatchList.Text = "WATCH LIST";
            lnkbtnWatchList.PostBackUrl = "WatchList.aspx";

            LinkButton lnkbtnFavouriteFilms = new LinkButton();
            lnkbtnFavouriteFilms.Text = "FAVOURITE FILMS";
            lnkbtnFavouriteFilms.PostBackUrl = "FavouriteFilms.aspx";

            LinkButton lnkbtnLogOut = new LinkButton();
            lnkbtnLogOut.Text = "LOG OUT";
            lnkbtnLogOut.Click += LnkbtnLogOut_Click;

            pnlDropDownContent.Controls.Add(lnkbtnRecommendedFilms);
            pnlDropDownContent.Controls.Add(lnkbtnWatchList);
            pnlDropDownContent.Controls.Add(lnkbtnFavouriteFilms);
            pnlDropDownContent.Controls.Add(lnkbtnLogOut);

            pnlSignInRegister.Controls.Add(pnlDropDownContent);

            return pnlSignInRegister;
        }

        public Panel GenerateEmptyListPanel(string emptyListName)
        {
            Panel pnlEmptyList = new Panel();

            Panel pnlEmptyListHeaderContainer = new Panel();
            pnlEmptyListHeaderContainer.CssClass = "page-subheader";
            pnlEmptyList.Controls.Add(pnlEmptyListHeaderContainer);

            Label lblAlert = new Label();
            lblAlert.Text = "Alert";
            pnlEmptyListHeaderContainer.Controls.Add(lblAlert);

            Label lblNoItems = new Label();
            lblNoItems.CssClass = "italicised";
            lblNoItems.Text = "No " + emptyListName;
            pnlEmptyList.Controls.Add(lblNoItems);

            return pnlEmptyList;
        }

        public Panel GenerateSearchResultsPanel(string title, string ImdbId)
        {
            Panel pnlSearchResult = new Panel();
            pnlSearchResult.CssClass = "searchResultsContainer";
            HyperLink hyplnkSearchResultTitle = new HyperLink();

            hyplnkSearchResultTitle.Text = title;
            hyplnkSearchResultTitle.NavigateUrl = "FilmInformation.aspx?ImdbId=" + ImdbId;
                                        
            pnlSearchResult.Controls.Add(hyplnkSearchResultTitle);
            return pnlSearchResult;
        }

        public Panel GenerateEmptySearchResultsPanel()
        {
            Panel pnlSearchResult = new Panel();
            pnlSearchResult.CssClass = "searchResultsContainer";
            Label hyplnkSearchResultTitle = new Label();
            hyplnkSearchResultTitle.Text = "No titles to display";
            pnlSearchResult.Controls.Add(hyplnkSearchResultTitle);

            return pnlSearchResult;
        }


        private void LnkbtnLogOut_Click(object sender, EventArgs e)
        {            
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            HttpContext.Current.Response.Redirect("Homepage.aspx");
        }
    }
}