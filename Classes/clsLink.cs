using System;
using System.Collections.Generic;
using Classes;
using System.Text.RegularExpressions;
using System.Linq;

namespace Classes
{
    public class clsLink
    {
        private Int32 mFilmId;
        private Int32 mImdbId;

        public int FilmId
        {
            get {return mFilmId;}
            set {mFilmId = value;}
        }
        public int ImdbId
        {
            get {return mImdbId;}
            set {mImdbId = value;}
        }


        public List<string> Valid(string imdbId)
        {
            List<string> ErrorList = new List<string>();
            Regex illicitCharacters = new Regex ("[a-zA-Z()!@±!£$%^&*?><{}+_=-]");
            bool containsIllicitCharacter = illicitCharacters.IsMatch(imdbId);

            if (imdbId.Length > 8)
            {
                ErrorList.Add("The ImdbId must not be more than 8 characters");
            }
            if (imdbId.Length == 0)
            {
                ErrorList.Add("The ImdbId must be more than 1 character");
            }            
            if(containsIllicitCharacter)
            {
                ErrorList.Add("Illicit characters are not allowed");
            }

            return ErrorList;
        }

        public Boolean Find(int filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblLinksFilterByFilmId");
            if (DB.Count == 1)
            {
                mImdbId = Convert.ToInt32(DB.DataTable.Rows[0]["ImdbId"]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}