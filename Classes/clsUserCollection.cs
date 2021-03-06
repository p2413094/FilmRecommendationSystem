﻿using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsUserCollection
    {
        private List<clsUser> mAllUsers = new List<clsUser>();

        public int Count
        {
            get {return mAllUsers.Count;}
            set {}
        }
        public List<clsUser> AllUsers
        {
            get { return mAllUsers;}
            set {mAllUsers = value;}
        }

        public clsUserCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_AspNetUsers_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsUser aUser = new clsUser();
                aUser.UserId = Convert.ToInt32(DB.DataTable.Rows[index]["Id"]);
                aUser.Email = DB.DataTable.Rows[index]["Email"].ToString();
                aUser.EmailConfirmed = DB.DataTable.Rows[index]["EmailConfirmed"].ToString();
                aUser.LockoutEnabled = DB.DataTable.Rows[index]["LockoutEnabled"].ToString();
                aUser.LockoutEndDateUtc = DB.DataTable.Rows[index]["LockoutEndDateUtc"].ToString();
                aUser.UserName = DB.DataTable.Rows[index]["UserName"].ToString();
                aUser.LastLogin = Convert.ToDateTime(DB.DataTable.Rows[index]["LastLogin"]);
                mAllUsers.Add(aUser);
                index++;
            }
        }

        public void RemoveUserFromSystem(Int32 userId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.Execute("sproc_tblFavouriteFilms_DeleteByUserId");

            DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.Execute("sproc_tblFilmMood_DeleteAllByUserId");

            DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.Execute("sproc_tblFilmRatings_DeleteAllByUserId");

            DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.Execute("sproc_tblFilmRecommendation_DeleteAllByUserId");

            DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.Execute("sproc_tblWatchList_DeleteAllByUserId");
        }

    }
}