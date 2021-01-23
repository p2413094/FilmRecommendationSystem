using System;

namespace Classes
{
    public class clsFilmMood
    {
        private Int32 mFilmId;
        private Int32 mUserId;
        private Int32 mMoodId;

        public int FilmId
        {
            get {return mFilmId;}
            set {mFilmId = value;}
        }
        public int MoodId
        {
            get {return mMoodId;}
            set {mMoodId = value;}
        }
        public int UserId
        {
            get {return mUserId;}
            set {mUserId = value;}
        }

        public Boolean Find(int filmId, int userId, int moodId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@MoodId", moodId);
            DB.Execute("sproc_tblFilmMood_FilterByFilmIdUserIdAndMoodId");
            if (DB.Count == 1)
            {
                mFilmId = Convert.ToInt32(DB.DataTable.Rows[0]["FilmId"]);
                mUserId = Convert.ToInt32(DB.DataTable.Rows[0]["UserId"]);
                mMoodId = Convert.ToInt32(DB.DataTable.Rows[0]["MoodId"]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}