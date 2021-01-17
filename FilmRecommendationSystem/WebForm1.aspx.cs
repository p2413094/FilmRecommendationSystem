using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace FilmRecommendationSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsLinkCollection links = new clsLinkCollection();
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblLinks_SelectAll");
            foreach(clsLink item in links.AllLinks)
            {
                test1.Text = item.ImdbId;
            }
        }
    }
}