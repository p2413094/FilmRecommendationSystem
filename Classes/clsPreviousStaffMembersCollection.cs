﻿using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsPreviousStaffMembersCollection
    {
        private List<clsPreviousStaffMembers> mAllPreviousStaffMembers = new List<clsPreviousStaffMembers>();
        private clsPreviousStaffMembers mThisPreviousStaffMember = new clsPreviousStaffMembers();

        public int Count
        {
            get {return mAllPreviousStaffMembers.Count;}
            set {}
        }
        public List<clsPreviousStaffMembers> AllPreviousStaffMembers
        {
            get {return mAllPreviousStaffMembers;}
            set {mAllPreviousStaffMembers = value;}
        }

        public clsPreviousStaffMembers ThisPreviousStaffMember
        {
            get {return mThisPreviousStaffMember;}
            set {mThisPreviousStaffMember = value;}
        }

        public clsPreviousStaffMembersCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblPreviousStaffMembers_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsPreviousStaffMembers aPreviousStaffMember = new clsPreviousStaffMembers();
                aPreviousStaffMember.PreviousStaffMemberId = Convert.ToInt32(DB.DataTable.Rows[index]["PreviousStaffMemberId"]);
                aPreviousStaffMember.FirstName = DB.DataTable.Rows[index]["FirstName"].ToString();
                aPreviousStaffMember.LastName = DB.DataTable.Rows[index]["LastName"].ToString();
                aPreviousStaffMember.PrivilegeLevelId = Convert.ToInt32(DB.DataTable.Rows[index]["PrivilegeLevelId"]);
                aPreviousStaffMember.DateTimeRemoved = Convert.ToDateTime(DB.DataTable.Rows[index]["DateTimeRemoved"]);
                mAllPreviousStaffMembers.Add(aPreviousStaffMember);
                index++;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FirstName", mThisPreviousStaffMember.FirstName);
            DB.AddParameter("@LastName", mThisPreviousStaffMember.LastName);
            DB.AddParameter("@PrivilegeLevelId", mThisPreviousStaffMember.PrivilegeLevelId);
            return DB.Execute("sproc_tblPreviousStaffMembers_Insert");
        }
    }
}