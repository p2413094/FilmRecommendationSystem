using System;
using System.Collections.Generic;
using Classes;

namespace Classes
{
    public class clsFilm
    {
        private Int32 mFilmId;
        private string mTitle;

        public int FilmId
        {
            get {return mFilmId;}
            set {mFilmId = value;}
        }
        public string Title
        {
            get {return mTitle;}
            set {mTitle = value;}
        }

        public List<string> Valid(string title)
        {
            List<string> errorList = new List<string>();
            clsFilmCollection AllFilms = new clsFilmCollection();
            Boolean exists = AllFilms.FilmAlreadyExistsCheck(title);

            if (title.Length > 180)
            {
                errorList.Add("The film title must not be more than 180 characters");
            }
            if (title.Length == 0)
            {
                errorList.Add("The film title must be more than 1 character");
            }
            if (exists == true)
            {
                errorList.Add("Film already exists");
            }
            return errorList;
        }

        public bool Find(int filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblFilm_FilterByFilmId");
            if (DB.Count == 1)
            {
                mFilmId = Convert.ToInt32(DB.DataTable.Rows[0]["FilmId"]);
                mTitle = DB.DataTable.Rows[0]["Title"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}