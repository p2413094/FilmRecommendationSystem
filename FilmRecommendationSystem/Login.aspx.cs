﻿using System;
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
                var result = signinManager.PasswordSignIn(txtUsername.Text, txtPassword.Text, RememberMe.Checked, shouldLockout: true);
                
                var user = manager.FindByName(txtUsername.Text);

                switch (result)
                {
                    case SignInStatus.Success:
                        user.LockoutEnabled = false;
                        user.LockoutEndDateUtc = null;
                        user.LastLogin = DateTime.Now;
                        signinManager.UserManager.ResetAccessFailedCount(user.Id); 
                        manager.Update(user);
                        Response.Redirect("Homepage.aspx");
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("AccountLockout.aspx");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked), true);
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