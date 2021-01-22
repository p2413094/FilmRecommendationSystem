using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsFilmCollection
    {
        private List<clsFilm> mAllFilms = new List<clsFilm>();
        private clsFilm mThisFilm = new clsFilm();

        public int Count
        {
            get {return mAllFilms.Count;}
            set {}
        }
        public List<clsFilm> AllFilms
        {
            get {return mAllFilms;}
            set {mAllFilms = value;}
        }

        public clsFilm ThisFilm
        {
            get {return mThisFilm;}
            set {mThisFilm = value;}
        }

        public clsFilmCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblFilm_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsFilm aFilm = new clsFilm();
                aFilm.FilmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                aFilm.Title = DB.DataTable.Rows[index]["Title"].ToString();
                mAllFilms.Add(aFilm);
                index++;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Title", mThisFilm.Title);
            return DB.Execute("sproc_tblFilm_Insert");
        }

        public Boolean FilmAlreadyExistsCheck(string title)
        {
            title = title.ToLower();
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Title", title);
            DB.Execute("sproc_tblFilm_FilterByTitle");
            if (DB.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}