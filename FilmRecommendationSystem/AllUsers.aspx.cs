using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace FilmRecommendationSystem
{
    public partial class AllUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            try
            {
                clsUserCollection AllUsers = new clsUserCollection();
                grdAllUsers.DataSource = AllUsers.AllUsers;
                grdAllUsers.DataBind();
            }
            catch
            {
                pnlError.Visible = true;
            }
        }

        protected void grdAllUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAllUsers.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void grdAllUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 userId = Convert.ToInt32(((Label)grdAllUsers.Rows[e.RowIndex].FindControl("lblUserId")).Text);
            Boolean suspended = ((CheckBox)grdAllUsers.Rows[e.RowIndex].FindControl("chkSuspended")).Checked;
            
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            user.LockoutEnabled = suspended;
            user.LockoutEndDateUtc = DateTime.Now.AddDays(3);

            clsEmail AnEmail = new clsEmail(user.Email);
            DateTime lockoutEnd = Convert.ToDateTime(user.LockoutEndDateUtc);
            manager.Update(user);

            AnEmail.SendUserSuspensionEmail(lockoutEnd);


            LoadData();
        }
    }
}