using System;

namespace Classes
{
    public class clsFilm
    {
        private Int32 mFilmId;
        private string mTitle;

        public int FilmId
        {
            get {return mFilmId;}
            set {mFilmId = value;}
        }
        public string Title
        {
            get {return mTitle;}
            set {mTitle = value;}
        }

        public string Valid(string newFilmTitle)
        {
            string error = "";
            if (newFilmTitle.Length > 180)
            {
                error = "The film title must not be more than 180 characters";
            }
            if (newFilmTitle.Length == 0)
            {
                error = "The film title must be more than 1 character";
            }
            return error;
        }

        public bool Find(int filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblFilm_FilterByFilmId");
            if (DB.Count == 1)
            {
                mFilmId = Convert.ToInt32(DB.DataTable.Rows[0]["FilmId"]);
                mTitle = DB.DataTable.Rows[0]["Title"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}