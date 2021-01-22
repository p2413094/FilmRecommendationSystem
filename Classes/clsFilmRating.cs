using System;

namespace Classes
{
    public class clsFilmRating
    {
        private Int32 mFilmId;
        private Int32 mUserId;
        private double mRating;

        public int FilmId
        {
            get {return mFilmId;}
            set {mFilmId = value;}
        }
        public int UserId
        {
            get {return mUserId;}
            set {mUserId = value;}
        }
        public double Rating
        {
            get {return mRating;}
            set {mRating = value;}
        }

        public Boolean Find(int filmId, int userId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.AddParameter("UserId", userId);
            DB.Execute("sproc_tblFilmRatings_FilterByFilmIdAndUserId");
            if (DB.Count == 1)
            {
                mFilmId = Convert.ToInt32(DB.DataTable.Rows[0]["FilmId"]);
                mUserId = Convert.ToInt32(DB.DataTable.Rows[0]["UserId"]);
                mRating = Convert.ToDouble(DB.DataTable.Rows[0]["Rating"]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}