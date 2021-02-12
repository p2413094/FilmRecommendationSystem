using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace FilmRecommendationSystem
{
    public partial class AllFilms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            LoadData();
        }

        void LoadData()
        {
            try
            {
                clsFilmCollection AllFilmsInDatabase = new clsFilmCollection();
                AllFilmsInDatabase = new clsFilmCollection();
                grdAllFilms.DataSource = AllFilmsInDatabase.AllFilms;
                grdAllFilms.DataBind();
            }
            catch
            {
                pnlError.Visible = true;
            }
        }

        protected void grdAllFilms_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAllFilms.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void grdAllFilms_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            clsFilmCollection AllFilmsInDatabase = new clsFilmCollection();
            string title = ((TextBox)grdAllFilms.Rows[e.RowIndex].FindControl("txtTitle")).Text;

            AllFilmsInDatabase = new clsFilmCollection();

            foreach (string error in AllFilmsInDatabase.ThisFilm.Valid(title))
            {
                Label lblError = new Label();
                lblError.Text = error;
                Panel1.Controls.Add(lblError);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            clsFilmCollection AllFilmsInDatabase = new clsFilmCollection();
            string title = txtNewTitle.Text;
            AllFilmsInDatabase = new clsFilmCollection();
            
            if (AllFilmsInDatabase.ThisFilm.Valid(title).Count != 0)
            {
                foreach (string error in AllFilmsInDatabase.ThisFilm.Valid(title))
                {
                    Label lblError = new Label();
                    lblError.Text = error;
                    Panel2.Controls.Add(lblError);
                }
            }
            else
            {
                AllFilmsInDatabase.ThisFilm.Title = title;
                AllFilmsInDatabase.Add();
                LoadData();
            }
        }
    }
}