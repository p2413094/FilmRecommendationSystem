using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsFilmRecommendationCollection
    {
        private List<clsFilmRecommendation> mAllFilmRecommendations = new List<clsFilmRecommendation>();
        private clsFilmRecommendation mThisFilmRecommendation = new clsFilmRecommendation();

        public int Count
        {
            get {return mAllFilmRecommendations.Count;}
            set {}
        }
        public List<clsFilmRecommendation> AllFilmRecommendations
        {
            get {return mAllFilmRecommendations;}
            set {mAllFilmRecommendations = value;}
        }

        public clsFilmRecommendation ThisFilmRecommendation
        {
            get {return mThisFilmRecommendation;}
            set {mThisFilmRecommendation = value;}
        }

        public clsFilmRecommendationCollection(int userId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.Execute("sproc_tblFilmRecommendation_FilterByUserId");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsFilmRecommendation aFilmRecommendation = new clsFilmRecommendation();
                aFilmRecommendation.UserId = Convert.ToInt32(DB.DataTable.Rows[index]["UserId"]);
                aFilmRecommendation.FilmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                mAllFilmRecommendations.Add(aFilmRecommendation);
                index++;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisFilmRecommendation.UserId);
            DB.AddParameter("@FilmId", mThisFilmRecommendation.FilmId);
            DB.Execute("sproc_tblFilmRecommendation_Insert");

            DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisFilmRecommendation.UserId);
            DB.AddParameter("@FilmId", mThisFilmRecommendation.FilmId);
            return DB.Execute("sproc_tblFilmRecommendation_SelectByUserAndFilmId");
        }

        public int Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisFilmRecommendation.UserId);
            DB.Execute("sproc_tblFilmRecommendation_DeleteAllByUserId");

            DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisFilmRecommendation.UserId);
            return DB.Execute("sproc_tblFilmRecommendation_FilterByUserId");
        }
    }
}