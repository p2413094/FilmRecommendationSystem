using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsFilmRatingCollection
    {
        private List<clsFilmRating> mAllFilmRatings = new List<clsFilmRating>();
        private clsFilmRating mThisFilmRating = new clsFilmRating();

        public int Count
        {
            get {return mAllFilmRatings.Count;}
            set {}
        }
        public List<clsFilmRating> AllFilmRatings
        {
            get {return mAllFilmRatings;}
            set {mAllFilmRatings = value;}
        }

        public clsFilmRating ThisFilmRating
        {
            get {return mThisFilmRating;}
            set {mThisFilmRating = value;}
        }

        public clsFilmRatingCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblFilmRatings_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsFilmRating aFilmRating = new clsFilmRating();
                aFilmRating.UserId = Convert.ToInt32(DB.DataTable.Rows[index]["UserId"]);
                aFilmRating.FilmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                aFilmRating.Rating = Convert.ToDouble(DB.DataTable.Rows[index]["Rating"]);
                mAllFilmRatings.Add(aFilmRating);
                index++;
            }
        }

        public void Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisFilmRating.FilmId);
            DB.AddParameter("@UserId", mThisFilmRating.UserId);
            DB.AddParameter("@Rating", mThisFilmRating.Rating);
            DB.Execute("sproc_tblFilmRatings_Insert");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisFilmRating.FilmId);
            DB.AddParameter("@UserId", mThisFilmRating.UserId);
            DB.Execute("sproc_tblFilmRatings_Delete");
        }
    }
}