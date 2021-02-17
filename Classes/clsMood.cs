using System;

namespace Classes
{
    public class clsMood : IComparable<clsMood>
    {
        private Int32 mMoodId;
        private string mMoodDescription;

        public int MoodId
        {
            get { return mMoodId; }
            set { mMoodId = value; }
        }
        public string MoodDesc
        {
            get {return mMoodDescription;}
            set {mMoodDescription = value;}
        }

        public int CompareTo (clsMood other)
        {
            if (this.MoodDesc == other.MoodDesc)
            {
                return this.MoodDesc.CompareTo(other.MoodDesc);
            }

            return this.MoodDesc.CompareTo(other.MoodDesc);
        }

        public string Valid(string moodDesc)
        {
            string error = "";

            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Description", moodDesc);
            DB.Execute("sproc_tblMood_FilterByDescription");

            if (DB.Count != 0)
            {
                error = "This mood already exists";
            }
            else
            {
                if (moodDesc.Length > 50)
                {
                    error = "The mood description must not be more than 50 characters";
                }
                if (moodDesc.Length == 0)
                {
                    error = "The mood description must be more than 1 character";
                }
            }
            return error;
        }

        public bool Find(int moodId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@MoodId", moodId);
            DB.Execute("sproc_tblMood_FilterByMoodId");
            if (DB.Count == 1)
            {
                mMoodId = Convert.ToInt32(DB.DataTable.Rows[0]["MoodId"]);
                mMoodDescription = DB.DataTable.Rows[0]["Description"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}