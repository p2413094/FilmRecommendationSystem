using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace FilmRecommendationSystem
{
    public partial class Register_EmailConfirmed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = IdentityHelper.GetCodeFromRequest(Request);
            int userId = Convert.ToInt32(IdentityHelper.GetUserIdFromRequest(Request));
            if (code != null && userId != null)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var result = manager.ConfirmEmail(userId, code);
                if (result.Succeeded)
                {
                    var user = manager.FindById(userId);
                    clsEmail AnEmail = new clsEmail(user.Email);
                    user.LockoutEnabled = false;
                    user.LockoutEndDateUtc = null;
                    manager.Update(user);
                    AnEmail.SendAccountVerifiedEmail();
                    //successPanel.Visible = true;
                    return;
                }
            }
            //successPanel.Visible = false;
            //errorPanel.Visible = true;
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