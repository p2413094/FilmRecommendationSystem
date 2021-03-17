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
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;;
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            string code = IdentityHelper.GetCodeFromRequest(Request);
            string email;

            Label lblError = new Label();

            if (code != null)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var user = manager.FindByEmail(txtEmailAddress.Text);
                if (user == null)
                {
                    lblError.Text = "We can't find an account with that email address";
                    pnlError.Controls.Add(lblError);
                    pnlError.Controls.Add(new LiteralControl("<br />"));
                    pnlError.Visible = true;
                    return;
                }
                var result = manager.ResetPassword(user.Id, code, txtPassword.Text);
                if (result.Succeeded)
                {
                    email = txtEmailAddress.Text;
                    DateTime dateTimeReset = DateTime.Now;

                    clsEmail AnEmail = new clsEmail(user.Email);
                    AnEmail.SendNewPasswordConfirmationEmail(dateTimeReset);
                    Response.Redirect("MyAccount.aspx");
                    return;
                }
                pnlPasswordErrors.CssClass = "passwordErrorContainer";
                lblError.Text = result.Errors.FirstOrDefault();
                pnlError.Controls.Add(lblError);
                pnlError.Visible = true;
                return;
            }
        }
    }
}