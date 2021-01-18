using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsMoodCollection
    {
        private List<clsMood> mAllMoods = new List<clsMood>();

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
                aMood.MoodDesc = DB.DataTable.Rows[index]["Desc"].ToString();
                mAllMoods.Add(aMood);
                index++;
            }
        }
    }
}