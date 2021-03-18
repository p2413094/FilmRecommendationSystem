using Classes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FilmRecommendationSystem
{
    public partial class AllUsersAndStaffMembers : System.Web.UI.Page
    {
        bool editStaffMember = true;
        Int32 originalPrivilegeLevel;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool administrator = Convert.ToBoolean(Session["Standard"]);
            
            if (!IsPostBack)
            {
                try
                {
                    pnlError.Visible = false;
                    pnlAllUsers.Visible = false;
                    pnlAllStaffMembers.Visible = false;
                    pnlNewStaffMember.Visible = false;

                    if (administrator)
                    {
                       LoadStaffMemberData();
                    }
                    LoadUserData();
                }
                catch
                {
                    pnlError.Visible = true;
                }
            }
        }

        protected void LoadStaffMemberData()
        {
            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            grdAllStaffMembers.DataSource = AllStaffMembers.AllStaffMembers;
            grdAllStaffMembers.DataBind();
                
            clsUserCollection AllUsers = new clsUserCollection();
            ddlUserId.DataSource = AllUsers.AllUsers;
            ddlUserId.DataValueField = "UserId";
            ddlUserId.DataTextField = "UserId";
            ddlUserId.DataBind();

            pnlAllStaffMembers.Visible = true;
        }

        protected void grdAllStaffMembers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            editStaffMember = true;
            int rowIndex = e.NewEditIndex;

            lblActionStaffMember.Text = "Edit staff member";
            Session["UserId"] = Convert.ToInt32(((Label)grdAllStaffMembers.Rows[rowIndex].FindControl("lblUserId")).Text);
            Session["StaffMemberId"] = Convert.ToInt32(((Label)grdAllStaffMembers.Rows[rowIndex].FindControl("lblStaffMemberId")).Text);
            txtNewStaffMemberFirstName.Text = ((Label)grdAllStaffMembers.Rows[rowIndex].FindControl("lblFirstName")).Text;
            txtNewStaffMemberLastName.Text = ((Label)grdAllStaffMembers.Rows[rowIndex].FindControl("lblLastName")).Text;
            Int32 privilegeLevel = Convert.ToInt32(((Label)grdAllStaffMembers.Rows[rowIndex].FindControl("lblPrivilegeLevelId")).Text);
            Boolean suspended = Convert.ToBoolean(((Label)grdAllStaffMembers.Rows[rowIndex].FindControl("lblAllowed")).Text);
            chkStaffMemberSuspended.Checked = suspended;

            originalPrivilegeLevel = privilegeLevel;
            ddlPrivilegelevel.SelectedValue = privilegeLevel.ToString();

            btnRegisterStaffMember.Text = "UPDATE STAFF MEMBER";
            pnlNewStaffMemberUserId.Visible = false;
            pnlNewStaffMember.Visible = true;

            LoadStaffMemberData();
            
            Page.SetFocus(btnRegisterStaffMember);
        }


        protected void btnRegisterStaffMember_Click(object sender, EventArgs e)
        {
            string firstName = txtNewStaffMemberFirstName.Text;
            string lastName = txtNewStaffMemberLastName.Text;
            Int32 userId = Convert.ToInt32(ddlUserId.SelectedItem.Value);
            Int32 privilegeLevelId = Convert.ToInt32(ddlPrivilegelevel.SelectedValue);
            Boolean suspended = chkStaffMemberSuspended.Checked;

            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            AllStaffMembers.ThisStaffMember.StaffMemberId = Convert.ToInt32(Session["StaffMemberId"]);
            AllStaffMembers.ThisStaffMember.UserId = userId;
            AllStaffMembers.ThisStaffMember.PrivilegeLevelId = privilegeLevelId;
            AllStaffMembers.ThisStaffMember.FirstName = firstName;
            AllStaffMembers.ThisStaffMember.LastName = lastName;
            AllStaffMembers.ThisStaffMember.Allowed = suspended;
            
            if (editStaffMember)
            {
                userId = Convert.ToInt32(Session["UserId"]);
            }

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            clsEmail AnEmail = new clsEmail(user.Email);

            if (editStaffMember)
            {
                if (suspended)
                {
                    DateTime suspendedEndDate = DateTime.Now.AddDays(3);
                    AnEmail.SendUserSuspensionEmail(suspendedEndDate);
                    user.LockoutEnabled = true;
                    user.LockoutEndDateUtc = suspendedEndDate;
                    manager.Update(user);
                }
                if (privilegeLevelId != originalPrivilegeLevel)
                {
                    AnEmail.SendStaffMemberPrivilegeChangeEmail();
                }
                AllStaffMembers.Update();
            }
            else
            {
                AllStaffMembers.Add();            
                AnEmail.SendNewStaffMemberStandardNoticeEmail();
            }
            
            grdAllStaffMembers.EditIndex = -1;

            pnlNewStaffMember.Visible = false;
            LoadStaffMemberData();
        }
        
        protected void grdAllStaffMembers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 staffMemberId = Convert.ToInt32(((Label)grdAllStaffMembers.Rows[e.RowIndex].FindControl("lblStaffMemberId")).Text);
            Int32 privilegeLevelId = Convert.ToInt32(((TextBox)grdAllStaffMembers.Rows[e.RowIndex].FindControl("txtPrivilegeLevelId")).Text);
            string firstName = ((TextBox)grdAllStaffMembers.Rows[e.RowIndex].FindControl("txtFirstName")).Text;
            string lastName = ((TextBox)grdAllStaffMembers.Rows[e.RowIndex].FindControl("txtLastName")).Text;
            Boolean allowed = ((CheckBox)grdAllStaffMembers.Rows[e.RowIndex].FindControl("chkAllowed")).Checked;

            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
           
            var staffMemberCheck = AllStaffMembers.ThisStaffMember.Valid(firstName, lastName);
            if (staffMemberCheck.Count != 0)
            {
                foreach (string error in staffMemberCheck)
                {
                    Label lbl1 = new Label();
                    lbl1.Text = error;
                    //Panel1.Controls.Add(lbl1);
                }
            }    
            else
            {
                AllStaffMembers.ThisStaffMember.StaffMemberId = staffMemberId;
                AllStaffMembers.ThisStaffMember.PrivilegeLevelId = privilegeLevelId;
                AllStaffMembers.ThisStaffMember.FirstName = firstName;
                AllStaffMembers.ThisStaffMember.LastName = lastName;
                AllStaffMembers.ThisStaffMember.Allowed = allowed;

                AllStaffMembers.Update();

                grdAllStaffMembers.EditIndex = -1;
                LoadStaffMemberData();
            }
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
            LoadStaffMemberData();
        }








        protected void LoadUserData()
        {
            try
            {   
                clsUserCollection AllUsers = new clsUserCollection();
                grdAllUsers.DataSource = AllUsers.AllUsers;
                grdAllUsers.DataBind();

                pnlAllUsers.Visible = true;
            }
            catch
            {
                pnlError.Visible = true;
            }
        }

        protected void grdAllUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAllUsers.EditIndex = e.NewEditIndex;

            LoadUserData();
        }

        protected void grdAllUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 userId = Convert.ToInt32(((Label)grdAllUsers.Rows[e.RowIndex].FindControl("lblUserId")).Text);
            Boolean suspended = ((CheckBox)grdAllUsers.Rows[e.RowIndex].FindControl("chkSuspended")).Checked;

            if (suspended != false)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(userId);
                user.LockoutEnabled = suspended;
                user.LockoutEndDateUtc = DateTime.Now.AddDays(3);

                clsEmail AnEmail = new clsEmail(user.Email);
                DateTime lockoutEnd = Convert.ToDateTime(user.LockoutEndDateUtc);
                manager.Update(user);

                AnEmail.SendUserSuspensionEmail(lockoutEnd);
            }
            LoadUserData();
        }

        protected void imgbtnAddNewStaffMember_Click(object sender, ImageClickEventArgs e)
        {
            pnlNewStaffMember.Visible = true;
        }

        protected void grdAllUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdAllUsers.EditIndex = -1;
            LoadUserData();
        }

        protected void imgbtUndoChanges_Click(object sender, ImageClickEventArgs e)
        {
            grdAllUsers.EditIndex = -1;
            LoadUserData();
        }

        protected void grdAllStaffMembers_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }
    }
}