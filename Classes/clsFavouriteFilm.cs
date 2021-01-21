using System;

namespace Classes
{
    public class clsFavouriteFilm
    {
        private Int32 mUserId;
        private Int32 mFilmId;

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

        public bool Find(int userId, int filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblFavouriteFilms_SelectByUserAndFilmId");
            if (DB.Count == 1)
            {
                mUserId = Convert.ToInt32(DB.DataTable.Rows[0]["UserId"]);
                mFilmId = Convert.ToInt32(DB.DataTable.Rows[0]["FilmId"]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}