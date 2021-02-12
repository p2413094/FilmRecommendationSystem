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
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            pnlMyAccount.Visible = false;
            Int32 userId = 1; //this would normally be dynamic 
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            if (user == null)
            {
                pnlError.Visible = true;
            }
            else
            {
                lblEmailAddress.Text = user.Email;
                lblLastLogin.Text = user.LastLogin.ToString();

                pnlMyAccount.Visible = true;
            }
        }
    }
}