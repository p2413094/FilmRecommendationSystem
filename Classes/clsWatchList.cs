using System;

namespace Classes
{
    public class clsWatchList
    {
        private Int32 mUserId;
        private Int32 mFilmId;
        private DateTime mDateAdded;

        public int UserId
        {
            get {return mUserId;}
            set {mUserId = value;}
        }
        public int FilmId
        {
            get {return mFilmId;}
            set {mFilmId = value;}
        }
        public DateTime DateAdded
        {
            get {return mDateAdded;}
            set {mDateAdded = value;}
        }

        public Boolean Find(int userId, int filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblWatchList_SelectByUserAndFilmId");
            if(DB.Count == 1)
            {
                mUserId = Convert.ToInt32(DB.DataTable.Rows[0]["UserId"]);
                mFilmId = Convert.ToInt32(DB.DataTable.Rows[0]["FilmId"]);
                mDateAdded = Convert.ToDateTime(DB.DataTable.Rows[0]["DateTimeAdded"]);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}