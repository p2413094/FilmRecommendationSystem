using System;

namespace Classes
{
    public class clsMostRecommendedFilms : IComparable<clsMostRecommendedFilms>
    {
        public int CompareTo (clsMostRecommendedFilms other)
        {
            if (this.TimesRecommended == other.TimesRecommended)
            {
                return this.TimesRecommended.CompareTo(other.TimesRecommended);
            }
            return this.TimesRecommended.CompareTo(other.TimesRecommended);
        }

        private Int32 mFilmId;
        private Int32 mTimesRecommended;

        public int FilmId
        {
            get {return mFilmId;}
            set {mFilmId = value;}
        }
        public int TimesRecommended
        {
            get {return mTimesRecommended;}
            set {mTimesRecommended = value;}
        }

        public bool Find(int filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblMostRecommendedFilms_FilterByFilmId");
            if (DB.Count == 1)
            {
                mFilmId = Convert.ToInt32(DB.DataTable.Rows[0]["FilmId"]);
                //mTimesRecommended = Convert.ToInt32(DB.DataTable.Rows[0]["TimesRecommended"]);
                return true;
            }
            else
            {
                return false; 
            }

        }
    }
}