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

        private void LnkbtnLogOut_Click(object sender, EventArgs e)
        {            
            var authentication = HttpContext.Current.GetOwinContext().Authentication;
            authentication.SignOut();
        }
    }
}