using Classes;
using FilmRecommendationSystem;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register_ConfirmEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public static List<string> SearchFilms(string prefixTest, int count)
    {
        clsFilmCollection AllFilms = new clsFilmCollection();
        List<string> filmTitles = new List<string>();
        foreach (clsFilm aFilm in AllFilms.AllFilms)
        {
            if (aFilm.Title.Contains(prefixTest))
            {
                filmTitles.Add(aFilm.Title);
            }
        }
        return filmTitles;
    }

}