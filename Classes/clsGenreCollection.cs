using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsGenreCollection
    {
        private List<clsGenre> mAllGenres = new List<clsGenre>();

        public int Count
        {
            get {return mAllGenres.Count;}
            set {}
        }
        public List<clsGenre> AllGenres
        {
            get {return mAllGenres;}
            set {mAllGenres = value;}
        }

        public clsGenreCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblGenre_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while(index < recordCount)
            {
                clsGenre aGenre = new clsGenre();
                aGenre.GenreId = Convert.ToInt32(DB.DataTable.Rows[index]["GenreId"]);
                aGenre.GenreDesc = DB.DataTable.Rows[index]["GenreDesc"].ToString();
                mAllGenres.Add(aGenre);
                index++;
            }
        }
    }
}