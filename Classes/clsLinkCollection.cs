using System;
using System.Collections.Generic;
using Classes;

namespace Classes
{
    public class clsLinkCollection
    {
        private List<clsLink> mAllLinks = new List<clsLink>();
        private clsLink mThisLink = new clsLink();

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

        public clsLink ThisLink
        {
            get {return mThisLink;}
            set {mThisLink = value;}
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
                aLink.ImdbId = Convert.ToInt32(DB.DataTable.Rows[index]["ImdbId"]);
                mAllLinks.Add(aLink);
                index++;
            }
        }

        public void Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisLink.FilmId);
            DB.AddParameter("@ImdbId", mThisLink.ImdbId);
            DB.Execute("sproc_tblLinks_Insert");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisLink.FilmId);
            DB.Execute("sproc_tblLinks_Delete");
        }

        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", mThisLink.FilmId);
            DB.AddParameter("@ImdbId", mThisLink.ImdbId);
            DB.Execute("sproc_tblLinks_Update");
        }
    }
}
