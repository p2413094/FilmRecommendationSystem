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
            clsGenreCollection Genres = new clsGenreCollection();
            DB.Execute("sproc_tblGenre_SelectAll");
            foreach(clsGenre aGenre in Genres.AllGenres)
            {
                test1.Text = aGenre.GenreDesc.ToString();
            }
        }
    }
}