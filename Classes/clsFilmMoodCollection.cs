﻿using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsFilmMoodCollection
    {
        private List<clsFilmMood> mAllFilmMoods = new List<clsFilmMood>();
        private clsFilmMood mThisFilmMood = new clsFilmMood();

        public int Count
        {
            get {return mAllFilmMoods.Count;}
            set {}
        }
        public List<clsFilmMood> AllFilmMoods
        {
            get {return mAllFilmMoods;}
            set {mAllFilmMoods = value;}
        }

        public clsFilmMood ThisFilmMood
        {
            get {return mThisFilmMood;}
            set {{mThisFilmMood = value;}}
        }

        public clsFilmMoodCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblFilmMood_SelectAll");
            Int32 recordcount = DB.Count;
            Int32 index = 0;
            while (index < recordcount)
            {
                clsFilmMood aFilmMood = new clsFilmMood();
                aFilmMood.FilmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                aFilmMood.MoodId = Convert.ToInt32(DB.DataTable.Rows[index]["MoodId"]);
                aFilmMood.UserId = Convert.ToInt32(DB.DataTable.Rows[index]["UserId"]);
                mAllFilmMoods.Add(aFilmMood);
                index++;
            }
        }

        public void Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisFilmMood.FilmId);
            DB.AddParameter("@UserId", mThisFilmMood.UserId);
            DB.AddParameter("@MoodId", mThisFilmMood.MoodId);
            DB.Execute("sproc_tblFilmMood_Insert");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisFilmMood.FilmId);
            DB.AddParameter("@UserId", mThisFilmMood.UserId);
            DB.AddParameter("@MoodId", mThisFilmMood.MoodId);
            DB.Execute("sproc_tblFilmMood_Delete");
        }
    }
}