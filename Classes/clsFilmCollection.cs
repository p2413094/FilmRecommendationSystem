using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsFilmCollection
    {
        private List<clsFilm> mAllFilms = new List<clsFilm>();

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
    }
}