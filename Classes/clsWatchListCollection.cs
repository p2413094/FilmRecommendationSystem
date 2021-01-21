using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsWatchListCollection
    {
        private List<clsWatchList> mAllFilmsInWatchList = new List<clsWatchList>();
        private clsWatchList mThisWatchListFilm = new clsWatchList();

        public int Count
        {
            get {return mAllFilmsInWatchList.Count;}
            set {}
        }

        public List<clsWatchList> AllFilmsInWatchList
        {
            get {return mAllFilmsInWatchList;}
            set {mAllFilmsInWatchList = value;}
        }

        public clsWatchList ThisWatchListFilm
        {
            get {return mThisWatchListFilm;}
            set {mThisWatchListFilm = value;}
        }

        public clsWatchListCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblWatchList_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsWatchList aFilmInWatchList = new clsWatchList();
                aFilmInWatchList.FilmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                aFilmInWatchList.DateAdded = Convert.ToDateTime(DB.DataTable.Rows[index]["DateTimeAdded"]);
                mAllFilmsInWatchList.Add(aFilmInWatchList);
                index++;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisWatchListFilm.UserId);
            DB.AddParameter("@FilmId", mThisWatchListFilm.FilmId);
            DB.Execute("sproc_tblWatchList_Insert");

            DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisWatchListFilm.UserId);
            DB.AddParameter("@FilmId", mThisWatchListFilm.FilmId);
            return DB.Execute("sproc_tblWatchList_SelectByUserAndFilmId");
        }

        public int Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisWatchListFilm.UserId);
            DB.AddParameter("@FilmId", mThisWatchListFilm.FilmId);
            DB.Execute("sproc_tblWatchList_Delete");

            DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisWatchListFilm.UserId);
            DB.AddParameter("@FilmId", mThisWatchListFilm.FilmId);
            return DB.Execute("sproc_tblWatchList_SelectByUserAndFilmId");

        }
    }
}