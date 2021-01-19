using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsFilmGenreCollection
    {
        private List<clsFilmGenre> mAllFilmGenres = new List<clsFilmGenre>();
        public int Count
        {
            get {return mAllFilmGenres.Count;}
            set {}
        }
        public List<clsFilmGenre> AllFilmGenres
        {
            get {return mAllFilmGenres;}
            set {mAllFilmGenres = value;}
        }

        public clsFilmGenreCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblFilmGenre_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsFilmGenre aFilmGenre = new clsFilmGenre();
                aFilmGenre.FilmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                aFilmGenre.GenreId = Convert.ToInt32(DB.DataTable.Rows[index]["GenreId"]);
                mAllFilmGenres.Add(aFilmGenre);
                index++;
            }
        }
    }
}