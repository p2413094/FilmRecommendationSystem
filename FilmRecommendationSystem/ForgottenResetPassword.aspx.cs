using Classes;
using FilmRecommendationSystem.Models;
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
    public partial class ForgottenResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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


        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user's email address
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //string test = txtEmailAddress.Text;
                ApplicationUser user = manager.FindByEmail(txtEmailAddress.Text);
                if (user == null || !manager.IsEmailConfirmed(user.Id))
                {
                    lblError.Text = "The user either does not exist or is not confirmed.";
                    return;
                }
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send email with the code and the redirect to reset password page
                string code = manager.GeneratePasswordResetToken(user.Id);
                string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
                manager.SendEmail(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                Response.Redirect("ForgottenResetPassword_EmailSent");
            }
        }
    }
}