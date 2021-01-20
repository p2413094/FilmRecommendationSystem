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
            //clsDataConnection DB = new clsDataConnection();
            clsFavouriteFilmCollection FavouriteFilms = new clsFavouriteFilmCollection(1);
            //DB.Execute("sproc_tblFavouriteFilms_FilterByUserId");
            foreach(clsFavouriteFilm aFavouriteFilm in FavouriteFilms.AllFavouriteFilms)
            {
                //test1.Text = aFavouriteFilm.FilmId.ToString();
                Label lbl1 = new Label();
                lbl1.Text = aFavouriteFilm.FilmId.ToString();
                Panel1.Controls.Add(lbl1);
            }
        }
    }
}