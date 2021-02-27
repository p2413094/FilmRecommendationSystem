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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();


            Int32 userId = 50; //note that this UserId is hard-coded and temporary - the real one will be the one that you retrieve when you sign in 
            var user = manager.FindById(userId);
            manager.Delete(user);
            clsEmail AnEmail = new clsEmail(user.Email);
            AnEmail.SendAccountClosedEmail();

            Response.Redirect("Homepage.aspx");

            //remember that here you need to delete all data associated with the user, e.g. watch list, favourite films.

        }
    }
}