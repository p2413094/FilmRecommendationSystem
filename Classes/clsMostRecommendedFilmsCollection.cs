using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsMostRecommendedFilmsCollection
    {
        private List<clsMostRecommendedFilms> mAllMostRecommendedFilms = new List<clsMostRecommendedFilms>();
        private clsMostRecommendedFilms mThisMostRecommendedFilm = new clsMostRecommendedFilms();

        public List<clsMostRecommendedFilms> AllMostRecommendedFilms
        {
            get {return mAllMostRecommendedFilms;}
            set {mAllMostRecommendedFilms = value;}
        }
        public int Count
        {
            get {return mAllMostRecommendedFilms.Count;}
            set {}
        }

        public clsMostRecommendedFilms ThisMostRecommendedFilm 
        {
            get {return mThisMostRecommendedFilm;}
            set {mThisMostRecommendedFilm = value;}
        }

        public clsMostRecommendedFilmsCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblMostRecommendedFilms_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsMostRecommendedFilms aMostRecommendedFilm = new clsMostRecommendedFilms();
                aMostRecommendedFilm.FilmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                aMostRecommendedFilm.TimesRecommended = Convert.ToInt32(DB.DataTable.Rows[index]["TimesRecommended"]);
                mAllMostRecommendedFilms.Add(aMostRecommendedFilm);
                index++;
            }
        }

        public void Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisMostRecommendedFilm.FilmId);
            DB.Execute("sproc_tblMostRecommendedFilms_Insert");
        }

        public void IncreaseTimesRecommended()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisMostRecommendedFilm.FilmId);
            DB.Execute("sproc_tblMostRecommendedFilms_IncreaseTimesRecommended");
        }
    }
}