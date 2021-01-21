using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsMoodCollection
    {
        private List<clsMood> mAllMoods = new List<clsMood>();
        private clsMood mThisMood = new clsMood();

        public int Count
        {
            get {return mAllMoods.Count;}
            set {}
        }

        public List<clsMood> AllMoods
        {
            get{return mAllMoods;}
            set {mAllMoods = value;}
        }

        public clsMood ThisMood
        {
            get {return mThisMood;}
            set {mThisMood = value;}
        }

        public clsMoodCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblMood_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsMood aMood = new clsMood();
                aMood.MoodId = Convert.ToInt32(DB.DataTable.Rows[index]["MoodId"]);
                aMood.MoodDesc = DB.DataTable.Rows[index]["Description"].ToString();
                mAllMoods.Add(aMood);
                index++;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Description", mThisMood.MoodDesc);
            return DB.Execute("sproc_tblMood_Insert");
        }
    }
}