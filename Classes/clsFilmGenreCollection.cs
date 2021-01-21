using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsFilmGenreCollection
    {
        private List<clsFilmGenre> mAllFilmGenres = new List<clsFilmGenre>();
        private clsFilmGenre mThisFilmGenre = new clsFilmGenre();

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

        public clsFilmGenre ThisFilmGenre
        {
            get {return mThisFilmGenre;}
            set {mThisFilmGenre = value;}
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
        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisFilmGenre.FilmId);
            DB.AddParameter("@GenreId", mThisFilmGenre.GenreId);
            DB.Execute("sproc_tblFilmGenre_Insert");

            //1
            DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisFilmGenre.FilmId);
            DB.AddParameter("@GenreId", mThisFilmGenre.GenreId);
            DB.Execute("sproc_tblFilmGenre_SelectByFilmIdAndGenreId");
            return DB.Count;
        }

        public int Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisFilmGenre.FilmId);
            DB.AddParameter("@GenreId", mThisFilmGenre.GenreId);
            DB.Execute("sproc_tblFilmGenre_DeleteAllByFilmIdAndGenreId");

            //this part is inefficient - needs to be in a function as it is exactly the same as //1
            DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisFilmGenre.FilmId);
            DB.AddParameter("@GenreId", mThisFilmGenre.GenreId);
            DB.Execute("sproc_tblFilmGenre_SelectByFilmIdAndGenreId");
            return DB.Count;
        }
    }
}