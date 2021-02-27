using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FilmRecommendationSystem;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace FilmRecommendationSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                //This doen't count login failures towards account lockout
                //To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(txtUsername.Text, txtPassword.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                        var user = manager.FindByName(txtUsername.Text);
                        //user.LockoutEnabled = suspended;
                        user.LockoutEndDateUtc = DateTime.Now.AddDays(3);
                        user.LastLogin = DateTime.Now;
                        manager.Update(user);
                        Response.Redirect("Homepage.aspx");
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("https://www.google.co.uk");
                        //Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        lblError.Text = "Invalid login attempt";
                        lblError.Visible = true;
                        break;
                }
            }

        }
    }
}