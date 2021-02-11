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
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByEmail(txtEmailAddress.Text);
            if (user == null)
            {
                lblError.Text = "No user found";
                return;
            }
            else
            {
                string resetToken = manager.GeneratePasswordResetToken(user.Id);
            
                var result = manager.ResetPassword(user.Id, resetToken, txtPasswordConfirmation.Text);
                if (result.Succeeded)
                {
                    Response.Redirect("Homepage.aspx");
                    return;

                    //remember that an email needs to be sent when the email is successfully changed 
                }
                lblError.Text = result.Errors.FirstOrDefault();
                return;
            }
        }
    }
}