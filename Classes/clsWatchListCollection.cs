using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsWatchListCollection
    {
        private List<clsWatchList> mAllFilmsInWatchList = new List<clsWatchList>();

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

        public clsWatchListCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblWatchList_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsWatchList aFilmInWatchList = new clsWatchList();
                aFilmInWatchList.UserId = Convert.ToInt32(DB.DataTable.Rows[index]["UserId"]);
                aFilmInWatchList.FilmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                aFilmInWatchList.DateAdded = Convert.ToDateTime(DB.DataTable.Rows[index]["DateTimeAdded"]);
                mAllFilmsInWatchList.Add(aFilmInWatchList);
                index++;
            }
        }
    }
}