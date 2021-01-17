using System;
using System.Collections.Generic;
using Classes;

namespace Classes
{
    public class clsLinkCollection
    {
        private List<clsLink> mAllLinks = new List<clsLink>();

        public int Count
        {
            get {return mAllLinks.Count;}
            set {}
        }

        public List<clsLink> AllLinks
        {
            get {return mAllLinks;}
            set {mAllLinks = value;}
        }

        public clsLinkCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblLinks_SelectAll");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                clsLink aLink = new clsLink();
                aLink.FilmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                aLink.ImdbId = DB.DataTable.Rows[index]["ImdbId"].ToString();
                mAllLinks.Add(aLink);
                index++;
            }
        }
    }
}
