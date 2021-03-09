using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsStaffMember
    {
        private Int32 mStaffMemberId;
        private Int32 mUserId;
        private Int32 mPrivilegeLevelId;
        private Boolean mConfirmed;
        private string mFirstName;
        private string mLastName;
        private Boolean mAllowed;

        public int StaffMemberId
        {
            get {return mStaffMemberId;}
            set {mStaffMemberId = value;}
        }
        public int UserId
        {
            get {return mUserId;}
            set {mUserId = value;}
        }
        public int PrivilegeLevelId
        {
            get {return mPrivilegeLevelId;}
            set {mPrivilegeLevelId = value;}
        }
        public bool Confirmed
        {
            get {return mConfirmed;}
            set {mConfirmed = value;}
        }
        public string FirstName
        {
            get {return mFirstName;}
            set {mFirstName = value;}
        }
        public string LastName
        {
            get {return mLastName;}
            set {mLastName = value;}
        }

        public bool Allowed
        {
            get {return mAllowed;}
            set {mAllowed = value;}
        }

        public List<string> Valid(string firstName, string lastName)
        {
            List<string> errorList = new List<string>();

            if (firstName.Length > 50)
            {
                errorList.Add("The first name must not be more than 50 characters");
            }
            if (firstName.Length == 0)
            {
                errorList.Add("The first name must be more than 1 character");
            }

            if (lastName.Length > 50)
            {
                errorList.Add("The last name must not be more than 50 characters");
            }
            if (lastName.Length == 0)
            {
                errorList.Add("The last name must be more than 1 character");
            }
            return errorList;
        }

        public Boolean Find(int userId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@StaffMemberId", userId);
            DB.Execute("sproc_tblStaffMember_FilterByUserId");
            if (DB.Count == 1)
            {
                mStaffMemberId = Convert.ToInt32(DB.DataTable.Rows[0]["StaffMemberId"]);
                mUserId = Convert.ToInt32(DB.DataTable.Rows[0]["UserId"]);
                mPrivilegeLevelId = Convert.ToInt32(DB.DataTable.Rows[0]["PrivilegeLevelId"]);
                mConfirmed = Convert.ToBoolean(DB.DataTable.Rows[0]["Confirmed"]);
                mFirstName = DB.DataTable.Rows[0]["FirstName"].ToString();
                mLastName = DB.DataTable.Rows[0]["LastName"].ToString();
                mAllowed = Convert.ToBoolean(DB.DataTable.Rows[0]["Allowed"]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}