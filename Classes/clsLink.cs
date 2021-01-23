using System;

namespace Classes
{
    public class clsLink
    {
        private Int32 mFilmId;
        private Int32 mImdbId;

        public int FilmId
        {
            get {return mFilmId;}
            set {mFilmId = value;}
        }
        public int ImdbId
        {
            get {return mImdbId;}
            set {mImdbId = value;}
        }


        public string Valid(string imdbId)
        {
            string error = "";
            if (imdbId.Length > 8)
            {
                error = "The ImdbId must not be more than 8 characters";
            }
            if (imdbId.Length == 0)
            {
                error = "The ImdbId must be more than 1 character";
            }
            return error;
        }

        public Boolean Find(int filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblLinksFilterByFilmId");
            if (DB.Count == 1)
            {
                mFilmId = Convert.ToInt32(DB.DataTable.Rows[0]["FilmId"]);
                mImdbId = Convert.ToInt32(DB.DataTable.Rows[0]["ImdbId"]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}