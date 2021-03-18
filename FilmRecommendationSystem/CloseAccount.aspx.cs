using Classes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmRecommendationSystem
{
    public partial class CloseAccount : System.Web.UI.Page
    {
        Int32 userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            userId = Convert.ToInt32(Session["UserId"]);
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


        protected void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                //Int32 userId = 50; //note that this UserId is hard-coded and temporary - the real one will be the one that you retrieve when you sign in 
                var user = manager.FindById(userId);
                manager.Delete(user);
                clsEmail AnEmail = new clsEmail(user.Email);
                AnEmail.SendAccountClosedEmail();

                clsUserCollection AllUsers = new clsUserCollection();
                AllUsers.RemoveUserFromSystem(userId);

                Response.Redirect("Homepage.aspx");
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