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
            clsDataConnection DB = new clsDataConnection();
            clsFilmMoodCollection filmMood = new clsFilmMoodCollection();
            DB.Execute("sproc_tblFilmMood_SelectAll");
            foreach(clsFilmMood aFilmMood in filmMood.AllFilmMoods)
            {
                test1.Text = aFilmMood.UserId.ToString();
            }
        }
    }
}