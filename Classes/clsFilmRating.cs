using System;

namespace Classes
{
    public class clsFilmRating
    {
        private Single mFilmId;
        private Single mUserId;
        private Single mRating;

        public Single FilmId
        {
            get {return mFilmId;}
            set {mFilmId = value;}
        }
        public Single UserId
        {
            get {return mUserId;}
            set {mUserId = value;}
        }
        public Single Rating
        {
            get {return mRating;}
            set {mRating = value;}
        }

        public Boolean Find(Single filmId, Single userId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.AddParameter("UserId", userId);
            DB.Execute("sproc_tblFilmRatings_FilterByFilmIdAndUserId");
            if (DB.Count == 1)
            {
                mFilmId = Convert.ToSingle(DB.DataTable.Rows[0]["FilmId"]);
                mUserId = Convert.ToSingle(DB.DataTable.Rows[0]["UserId"]);
                mRating = Convert.ToSingle(DB.DataTable.Rows[0]["Rating"]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}