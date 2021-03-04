using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Data;
using System.Text.RegularExpressions;


namespace FilmRecommendationSystem
{
    public partial class AllFilms : System.Web.UI.Page
    {
        bool editFilm;
        Int32 filmId;
        List<clsFilmGenre> GenresAlreadyAttachedToFilm = new List<clsFilmGenre>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                editFilm = false;
                pnlError.Visible = false;
            }
        }

        void LoadData()
        {
            try
            {
                clsFilmCollection AllFilmsInDatabase = new clsFilmCollection();
                AllFilmsInDatabase = new clsFilmCollection();
                grdAllFilms.DataSource = AllFilmsInDatabase.AllFilms;
                grdAllFilms.DataBind();

                if (!string.IsNullOrEmpty(txtFilmSearch.Text.Trim()))
                {
                    grdAllFilms.DataSource = AllFilmsInDatabase.SearchForFilm(txtFilmSearch.Text);
                    grdAllFilms.DataBind();
                }

            }
            catch
            {
                pnlError.Visible = true;
            }
        }

        protected void grdAllFilms_RowEditing(object sender, GridViewEditEventArgs e)
        {
            editFilm = true;
            int rowIndex = e.NewEditIndex;
            filmId = Convert.ToInt32(((Label)grdAllFilms.Rows[rowIndex].FindControl("lblFilmId")).Text);

            lblActionFilm.Text = "Edit film record";
            btnActionFilm.Text = "UPDATE FILM";
            txtFilmTitle.Text = ((Label)grdAllFilms.Rows[rowIndex].FindControl("lblTitle")).Text;

            clsLink aLink = new clsLink();
            aLink.Find(filmId);
            Int32 imdbId = aLink.ImdbId;
            txtImdbId.Text = imdbId.ToString();

            Session["FilmId"] = filmId;
            Session["originalIMDBId"] = imdbId;

            pnlActionFilm.Visible = true;
            LoadData();

            clsFilmGenre aFilmGenre = new clsFilmGenre();
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblFilmGenre_FilterByFilmId");
            Int32 recordCount = DB.Count;
            Int32 index = 0;
            while (index < recordCount)
            {
                Int32 genreId = Convert.ToInt32(DB.DataTable.Rows[index]["GenreId"]);
                chkbxlstGenres.Items.FindByValue(genreId.ToString()).Selected = true;
                aFilmGenre.FilmId = filmId;
                aFilmGenre.GenreId = genreId;
                GenresAlreadyAttachedToFilm.Add(aFilmGenre);
                index++;
            }

        }

        protected void grdAllFilms_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            clsFilmCollection AllFilmsInDatabase = new clsFilmCollection();
            string title = ((TextBox)grdAllFilms.Rows[e.RowIndex].FindControl("txtTitle")).Text;
            Session["Title"] = title;
            AllFilmsInDatabase = new clsFilmCollection();

            foreach (string error in AllFilmsInDatabase.ThisFilm.Valid(title))
            {
                Label lblError = new Label();
                lblError.Text = error;
                Panel1.Controls.Add(lblError);
            }
        }

        protected void txtFilmSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void btnActionFilm_Click(object sender, EventArgs e)
        {
            string originalTitle = Session["Title"].ToString();
            string newTitle = txtFilmTitle.Text;
            string tempImdbId = txtImdbId.Text;
            Int32 imdbId = 0;
            bool imdbIdOk = false;

            clsFilm aFilm = new clsFilm();
            var filmTitleCheck = aFilm.Valid(newTitle);
            if (filmTitleCheck.Count != 0)
            {
                foreach (string error in filmTitleCheck)
                {
                    Label lblError = new Label();
                    lblError.Text = error;
                    pnlActionFilmError.Controls.Add(lblError);
                    pnlActionFilmError.Controls.Add(new LiteralControl("<br />"));
                }
            }

            clsLinkCollection AllLinks = new clsLinkCollection();
            var imdbIdCheck = AllLinks.ThisLink.Valid(tempImdbId);
            if (imdbIdCheck.Count != 0)
            {
                foreach (string error in imdbIdCheck)
                {
                    Label lblError = new Label();
                    lblError.Text = error;
                    pnlActionFilmError.Controls.Add(lblError);
                    pnlActionFilmError.Controls.Add(new LiteralControl("<br />"));
                    imdbIdOk = false;
                }
            }
            else
            {
                imdbId = Convert.ToInt32(tempImdbId);
                bool ImdbIdAlreadyExists = AllLinks.ImdbIdAlreadyExistsCheck(imdbId);

                if (ImdbIdAlreadyExists)
                {
                    if (!editFilm) //adding a new film
                    {
                        Label lblError = new Label();
                        lblError.Text = "IMDBId already assigned to another film";
                        pnlActionFilmError.Controls.Add(lblError);
                        pnlActionFilmError.Controls.Add(new LiteralControl("<br />"));
                        imdbIdOk = false;
                    }

                    else //if we're editing a film
                    {
                        Int32 originalImdbId = Convert.ToInt32(Session["originalIMDBId"]);
                        if (originalImdbId != imdbId)
                        {
                            Label lblError = new Label();
                            lblError.Text = "IMDBId already assigned to another film";
                            pnlActionFilmError.Controls.Add(lblError);
                            pnlActionFilmError.Controls.Add(new LiteralControl("<br />"));
                            imdbIdOk = false;
                        }
                        else
                        {
                            imdbIdOk = true;
                        }
                    }
                }
                else
                {
                    imdbIdOk = true;
                }
            }

            newTitle = newTitle.TrimEnd();
            string yearReleased = " " + "(" + ddlYear.SelectedValue + ")";
            string titleAndYearReleased = newTitle + yearReleased;

            bool filmAlreadyExists = false;
            clsFilmCollection AllFilms = new clsFilmCollection();
            if (AllFilms.FilmAlreadyExistsCheck(titleAndYearReleased))
            {
                if (!editFilm)
                {
                    Label lblError = new Label();
                    lblError.Text = "Film already exists";
                    pnlActionFilmError.Controls.Add(lblError);
                    filmAlreadyExists = true;
                }
                else //if we ARE editing a film
                {
                    if (newTitle != originalTitle)
                    {
                        Label lblError = new Label();
                        lblError.Text = "Film already exists";
                        pnlActionFilmError.Controls.Add(lblError);
                        filmAlreadyExists = true;
                    }
                    else
                    {
                        filmAlreadyExists = false;
                    }
                }
            }
            else
            {
                filmAlreadyExists = false;
            }

            if (!editFilm && !filmAlreadyExists && imdbIdOk)
            {
                AllFilms = new clsFilmCollection();
                AllFilms.ThisFilm.Title = titleAndYearReleased;
                Int32 filmId = AllFilms.Add();
                AllLinks.ThisLink.FilmId = filmId;
                AllLinks.ThisLink.ImdbId = imdbId;
                AllLinks.Add();

                clsFilmGenreCollection AllFilmGenres = new clsFilmGenreCollection();

                foreach (ListItem item in chkbxlstGenres.Items)
                {
                    if (item.Selected)
                    {
                        AllFilmGenres.ThisFilmGenre.FilmId = filmId;
                        AllFilmGenres.ThisFilmGenre.GenreId = Convert.ToInt32(item.Value);
                        AllFilmGenres.Add();
                        AllFilmGenres = new clsFilmGenreCollection();
                    }
                }
            }

            if (editFilm)
            {
                AllFilms = new clsFilmCollection();
                AllFilms.ThisFilm.FilmId = Convert.ToInt32(Session["FilmId"]);

                if (newTitle == originalTitle)
                {
                    AllFilms.ThisFilm.Title = originalTitle;
                }
                else
                {
                    AllFilms.ThisFilm.Title = newTitle;
                }

                AllFilms.Update();

                clsFilmGenreCollection AllFilmGenres = new clsFilmGenreCollection();
                AllFilmGenres.ThisFilmGenre.FilmId = filmId;
                AllFilmGenres.DeleteByFilmId();

                foreach (ListItem item in chkbxlstGenres.Items)
                {
                    if (item.Selected)
                    {
                        AllFilmGenres.ThisFilmGenre.FilmId = filmId;
                        AllFilmGenres.ThisFilmGenre.GenreId = Convert.ToInt32(item.Value);
                        AllFilmGenres.Add();
                        AllFilmGenres = new clsFilmGenreCollection();
                    }
                }

                LoadData();
            }
        }

        protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            pnlActionFilm.Visible = true;
            int year = DateTime.Now.Year;
            for (int i = year - 120; i <= year + 4; i++)
            {
                ListItem li = new ListItem(i.ToString());
                ddlYear.Items.Add(li);
            }
            ddlYear.Items.FindByText(year.ToString()).Selected = true;
        }

        protected void btnActionFilmCancel_Click(object sender, EventArgs e)
        {
            txtFilmTitle.Text = string.Empty;
            ddlYear.ClearSelection();
            chkbxlstGenres.ClearSelection();
            txtImdbId.Text = string.Empty;
            
            //pnlActionFilm.Visible = false;
        }
    }
}