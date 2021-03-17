using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace FilmRecommendationSystem
{
    public partial class PreviousStaffMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            pnlAllPreviousStaffMembers.Visible = false;

            try
            {
                clsPreviousStaffMembersCollection AllPreviousStaffMembers = new clsPreviousStaffMembersCollection();
                grdPreviousStaffMembers.DataSource = AllPreviousStaffMembers.AllPreviousStaffMembers;
                grdPreviousStaffMembers.DataBind();

                pnlAllPreviousStaffMembers.Visible = true;
            }
            catch
            {
                pnlError.Visible = true;
            }
        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }
    }
}