using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmRecommendationSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 filmId = 1;
            string newImdbId = "tt0114709";
            Response.Redirect("FilmInformation.aspx?FilmId=" + filmId + "&ImdbId=" + newImdbId);
        }
    }
}