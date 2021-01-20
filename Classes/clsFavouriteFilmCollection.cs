using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsFavouriteFilmCollection
    {
        private List<clsFavouriteFilm> mAllFavourites = new List<clsFavouriteFilm>();
        private clsFavouriteFilm mThisFavouriteFilm = new clsFavouriteFilm();

        public int Count
        {
            get {return mAllFavourites.Count;}
            set {}
        }
        public List<clsFavouriteFilm> AllFavouriteFilms
        {
            get {return mAllFavourites;}
            set {mAllFavourites = value;}
        }

        public clsFavouriteFilm ThisFavouriteFilm
        {
            get {return mThisFavouriteFilm;}
            set {mThisFavouriteFilm = value;}
        }

        public clsFavouriteFilmCollection(int userId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.Execute("sproc_tblFavouriteFilms_FilterByUserId");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsFavouriteFilm aFavouriteFilm = new clsFavouriteFilm();
                aFavouriteFilm.UserId = Convert.ToInt32(DB.DataTable.Rows[index]["UserId"]);
                aFavouriteFilm.FilmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                mAllFavourites.Add(aFavouriteFilm);
                index++;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisFavouriteFilm.UserId);
            DB.AddParameter("@FilmId", mThisFavouriteFilm.FilmId);
            DB.Execute("sproc_tblFavouriteFilms_Insert");
            
            DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisFavouriteFilm.UserId);
            DB.AddParameter("@FilmId", mThisFavouriteFilm.FilmId);

            return DB.Execute("sproc_tblFavouriteFilms_SelectByUserAndFilmId");
        }

        public int Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisFavouriteFilm.UserId);
            DB.AddParameter("@FilmId", mThisFavouriteFilm.FilmId);
            DB.Execute("sproc_tblFavouriteFilms_Delete");
            
            DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisFavouriteFilm.UserId);
            DB.AddParameter("@FilmId", mThisFavouriteFilm.FilmId);

            return DB.Execute("sproc_tblFavouriteFilms_SelectByUserAndFilmId");
        }
    }
}