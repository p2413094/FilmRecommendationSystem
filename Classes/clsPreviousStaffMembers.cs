using System;

namespace Classes
{
    public class clsPreviousStaffMembers
    {
        private Int32 mPreviousStaffMemberId;
        private string mFirstName;
        private string mLastName;
        private Int32 mPrivilegeLevelId;
        private DateTime mDateTimeRemoved;

        public int PreviousStaffMemberId
        {
            get {return mPreviousStaffMemberId;}
            set {mPreviousStaffMemberId = value;}
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
        public int PrivilegeLevelId
        {
            get {return mPrivilegeLevelId;}
            set {mPrivilegeLevelId = value;}
        }
        public DateTime DateTimeRemoved
        {
            get {return mDateTimeRemoved;}
            set {mDateTimeRemoved = value;}
        }

        public Boolean Find(int previousStaffMemberId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@PreviousStaffMemberId", previousStaffMemberId);
            DB.Execute("sproc_tblPreviousStaffMember_FilterByPreviousStaffMemberId");
            if (DB.Count == 1)
            {
                mPreviousStaffMemberId = Convert.ToInt32(DB.DataTable.Rows[0]["PreviousStaffMemberId"]);
                mFirstName = DB.DataTable.Rows[0]["FirstName"].ToString();
                mLastName = DB.DataTable.Rows[0]["LastName"].ToString();
                mPrivilegeLevelId = Convert.ToInt32(DB.DataTable.Rows[0]["PrivilegeLevelId"]);
                mDateTimeRemoved = Convert.ToDateTime(DB.DataTable.Rows[0]["DateTimeRemoved"]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}