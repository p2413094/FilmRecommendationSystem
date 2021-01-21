using System;

namespace Classes
{
    public class clsFilmGenre
    {
        private Int32 mFilmId;
        private Int32 mGenreId;

        public int FilmId
        {
            get {return mFilmId;}
            set {mFilmId = value;}
        }
        public int GenreId
        {
            get {return mGenreId;}
            set {mGenreId = value;}
        }

        public bool Find(int filmId, int genreId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.AddParameter("@GenreId", genreId);
            DB.Execute("sproc_tblFilmGenre_SelectByFilmIdAndGenreId");
            if (DB.Count == 1)
            {
                mFilmId = Convert.ToInt32(DB.DataTable.Rows[0]["FilmId"]);
                mGenreId = Convert.ToInt32(DB.DataTable.Rows[0]["GenreId"]);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}