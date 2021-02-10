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
            clsPreviousStaffMembersCollection AllPreviousStaffMembers = new clsPreviousStaffMembersCollection();
            grdPreviousStaffMembers.DataSource = AllPreviousStaffMembers.AllPreviousStaffMembers;
            grdPreviousStaffMembers.DataBind();
        }
    }
}