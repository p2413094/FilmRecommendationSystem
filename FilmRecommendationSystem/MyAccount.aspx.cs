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
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    pnlError.Visible = false;
                    pnlMyAccount.Visible = false;
                    pnlStaffAdmin.Visible = false;
                    btnViewStaffMembers.Visible = false;
                    btnViewPreviousStaffMembers.Visible = false;
                    Int32 userId = Convert.ToInt32(Session["UserId"]); 
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var user = manager.FindById(userId);

                    clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
                    AllStaffMembers.ThisStaffMember.UserId = userId;

                    if (AllStaffMembers.ThisStaffMember.Find(userId))
                    {
                        if (AllStaffMembers.ThisStaffMember.PrivilegeLevelId == 2)
                        {
                            pnlStaffAdmin.Visible = true;
                            btnViewStaffMembers.Visible = true;
                            btnViewPreviousStaffMembers.Visible = true;
                            Session["Standard"] = false;
                        }
                        else
                        {
                            pnlStaffAdmin.Visible = true;
                            Session["Standard"] = true;
                        }
                    }
                    lblEmailAddress.Text = user.Email;
                    lblLastLogin.Text = user.LastLogin.ToString();

                    pnlMyAccount.Visible = true;
                }
                catch
                {
                    pnlError.Visible = true;
                }
            }
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

        protected void btnViewUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllUsersAndStaffMembers.aspx");
        }
        protected void btnViewFilms_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllFilms.aspx");
        }

        protected void btnViewPreviousStaffMembers_Click(object sender, EventArgs e)
        {
            Response.Redirect("PreviousStaffMembers.aspx");
        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }
    }
}