using System;
using System.Collections.Generic;
using Classes;
using System.Text.RegularExpressions;
using System.Linq;

namespace Classes
{
    public class clsFilm : IComparable<clsFilm>
    {
        public int CompareTo (clsFilm other)
        {
            if (this.Title == other.Title)
            {
                return this.Title.CompareTo(other.Title);
            }

            return this.Title.CompareTo(other.Title);
        }


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
            if (title.Length == 0)
            {
                errorList.Add("The film title must be more than 1 character");
            }
            if (title.Length > 180)
            {
                errorList.Add("The film title must not be more than 180 characters");
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