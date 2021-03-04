using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsFilmGenreCollection
    {
        private List<clsFilmGenre> mAllFilmGenres = new List<clsFilmGenre>();
        private clsFilmGenre mThisFilmGenre = new clsFilmGenre();
        
        private List<clsFilmGenre> mAllFilmsByGenre = new List<clsFilmGenre>();

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

        public List<clsFilmGenre> AllFilmsByGenre
        {
            get {return mAllFilmsByGenre;}
            set {mAllFilmsByGenre = value;}
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
        public void Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisFilmGenre.FilmId);
            DB.AddParameter("@GenreId", mThisFilmGenre.GenreId);
            DB.Execute("sproc_tblFilmGenre_Insert");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisFilmGenre.FilmId);
            DB.AddParameter("@GenreId", mThisFilmGenre.GenreId);
            DB.Execute("sproc_tblFilmGenre_DeleteAllByFilmIdAndGenreId");
        }

        public void DeleteByFilmId()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisFilmGenre.FilmId);
            DB.Execute("sproc_tblFilmGenre_DeleteAllByFilmId");
        }

        public void GetAllFilmsByGenre(int genreId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@GenreId", genreId);
            DB.Execute("sproc_tblFilmGenre_FilterByGenreId");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsFilmGenre aFilm = new clsFilmGenre();
                aFilm.FilmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                mAllFilmsByGenre.Add(aFilm);
                index++;
            }
        }
    }
}