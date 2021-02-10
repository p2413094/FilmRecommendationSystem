using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace FilmRecommendationSystem
{
    public partial class AllStaffMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            grdAllStaffMembers.DataSource = AllStaffMembers.AllStaffMembers;
            grdAllStaffMembers.DataBind();
        }

        protected void grdAllStaffMembers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAllStaffMembers.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void grdAllStaffMembers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 staffMemberId = Convert.ToInt32(((Label)grdAllStaffMembers.Rows[e.RowIndex].FindControl("lblStaffMemberId")).Text);
            Int32 privilegeLevelId = Convert.ToInt32(((TextBox)grdAllStaffMembers.Rows[e.RowIndex].FindControl("txtPrivilegeLevelId")).Text);
            string firstName = ((TextBox)grdAllStaffMembers.Rows[e.RowIndex].FindControl("txtFirstName")).Text;
            string lastName = ((TextBox)grdAllStaffMembers.Rows[e.RowIndex].FindControl("txtLastName")).Text;
            Boolean allowed = ((CheckBox)grdAllStaffMembers.Rows[e.RowIndex].FindControl("chkAllowed")).Checked;

            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            AllStaffMembers.ThisStaffMember.StaffMemberId = staffMemberId;
            AllStaffMembers.ThisStaffMember.PrivilegeLevelId = privilegeLevelId;
            AllStaffMembers.ThisStaffMember.FirstName = firstName;
            AllStaffMembers.ThisStaffMember.LastName = lastName;
            AllStaffMembers.ThisStaffMember.Allowed = allowed;

            AllStaffMembers.Update();

            grdAllStaffMembers.EditIndex = -1;
            LoadData();
        }

        protected void grdAllStaffMembers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 staffMemberId = Convert.ToInt32(((Label)grdAllStaffMembers.Rows[e.RowIndex].FindControl("lblStaffMemberId")).Text);
            Int32 privilegeLevelId = Convert.ToInt32(((Label)grdAllStaffMembers.Rows[e.RowIndex].FindControl("lblPrivilegeLevelId")).Text);
            string firstName = ((Label)grdAllStaffMembers.Rows[e.RowIndex].FindControl("lblFirstName")).Text;
            string lastName = ((Label)grdAllStaffMembers.Rows[e.RowIndex].FindControl("lblLastName")).Text;

            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            AllStaffMembers.ThisStaffMember.StaffMemberId = staffMemberId;
            AllStaffMembers.ThisStaffMember.FirstName = firstName;
            AllStaffMembers.ThisStaffMember.LastName = lastName;
            AllStaffMembers.ThisStaffMember.PrivilegeLevelId = privilegeLevelId;
            AllStaffMembers.Delete();
            LoadData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Int32 userId = Convert.ToInt32(txtNewUserId.Text);
            string firstName = txtNewFirstName.Text;
            string lastName = txtNewLastName.Text;
            Int32 privilegeLevelId = Convert.ToInt32(txtNewPrivilegeLevel.Text);
            
            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            AllStaffMembers.ThisStaffMember.UserId = userId;
            AllStaffMembers.ThisStaffMember.FirstName = firstName;
            AllStaffMembers.ThisStaffMember.LastName = lastName;
            AllStaffMembers.ThisStaffMember.PrivilegeLevelId = privilegeLevelId;
            AllStaffMembers.Add();

            LoadData();
        }
    }

}
