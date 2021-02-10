using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsStaffMemberCollection
    {
        private List<clsStaffMember> mAllStaffMembers = new List<clsStaffMember>();
        private clsStaffMember mThisStaffMember = new clsStaffMember();

        public int Count
        {
            get {return mAllStaffMembers.Count;}
            set {}
        }
        public List<clsStaffMember> AllStaffMembers
        {
            get {return mAllStaffMembers;}
            set {mAllStaffMembers = value;}
        }

        public clsStaffMember ThisStaffMember
        {
            get {return mThisStaffMember;}
            set {mThisStaffMember = value;}
        }

        public clsStaffMemberCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblStaffMember_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsStaffMember aStaffMember = new clsStaffMember();
                aStaffMember.StaffMemberId = Convert.ToInt32(DB.DataTable.Rows[index]["StaffMemberId"]);
                aStaffMember.UserId = Convert.ToInt32(DB.DataTable.Rows[index]["UserId"]);
                aStaffMember.PrivilegeLevelId = Convert.ToInt32(DB.DataTable.Rows[index]["PrivilegeLevelId"]);
                aStaffMember.Confirmed = Convert.ToBoolean(DB.DataTable.Rows[index]["Confirmed"]);
                aStaffMember.FirstName = DB.DataTable.Rows[index]["FirstName"].ToString();
                aStaffMember.LastName = DB.DataTable.Rows[index]["LastName"].ToString();
                aStaffMember.Allowed = Convert.ToBoolean(DB.DataTable.Rows[index]["Allowed"]);
                mAllStaffMembers.Add(aStaffMember);
                index++;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisStaffMember.UserId);
            DB.AddParameter("@PrivilegeLevelId", mThisStaffMember.PrivilegeLevelId);
            DB.AddParameter("@FirstName", mThisStaffMember.FirstName);
            DB.AddParameter("@LastName", mThisStaffMember.LastName);
            return DB.Execute("sproc_tblStaffMember_Insert");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@StaffMemberId", mThisStaffMember.StaffMemberId);
            DB.Execute("sproc_tblStaffMember_Delete");

            DB = new clsDataConnection();
            DB.AddParameter("@FirstName", mThisStaffMember.FirstName);
            DB.AddParameter("@LastName", mThisStaffMember.LastName);
            DB.AddParameter("@PrivilegeLevelId", mThisStaffMember.PrivilegeLevelId);
            DB.Execute("sproc_tblPreviousStaffMembers_Insert");
        }

        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@StaffMemberId", mThisStaffMember.StaffMemberId);
            DB.AddParameter("@PrivilegeLevelId", mThisStaffMember.PrivilegeLevelId);
            DB.AddParameter("@FirstName", mThisStaffMember.FirstName);
            DB.AddParameter("@LastName", mThisStaffMember.LastName);
            DB.AddParameter("@Allowed", mThisStaffMember.Allowed);
            DB.Execute("sproc_tblStaffMember_Update");
        }
    }
}