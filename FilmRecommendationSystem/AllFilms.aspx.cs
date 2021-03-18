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
                editFilm = false;
                pnlAllFilms.Visible = true;
                pnlActionFilm.Visible = false;
                pnlError.Visible = false;
                pnlActionFilmError.Visible = false;
                LoadData();
                GenerateFilmYears();
            }
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
            string filmTitle = ((Label)grdAllFilms.Rows[rowIndex].FindControl("lblTitle")).Text;

            txtFilmTitle.Text = filmTitle;

            clsLink aLink = new clsLink();
            aLink.Find(filmId);
            Int32 imdbId = aLink.ImdbId;
            txtImdbId.Text = imdbId.ToString();

            Session["FilmId"] = filmId;
            Session["Title"] = filmTitle;
            Session["originalIMDBId"] = imdbId;
            Session["EditFilm"] = true;

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

            GenerateFilmYears();
            Page.SetFocus(btnActionFilmCancel);
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
                pnlActionFilmErrorBody.Controls.Add(lblError);
            }
        }

        protected void txtFilmSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void btnActionFilm_Click(object sender, EventArgs e)
        {
            string originalTitle = "";
            editFilm = Convert.ToBoolean(Session["EditFilm"]);
            if (editFilm)
            {
                originalTitle = Session["Title"].ToString();
            }

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
                    lblError.Text = "- " + error;
                    pnlActionFilmErrorBody.Controls.Add(lblError);
                    pnlActionFilmErrorBody.Controls.Add(new LiteralControl("<br />"));
                }
            }

            clsLinkCollection AllLinks = new clsLinkCollection();
            var imdbIdCheck = AllLinks.ThisLink.Valid(tempImdbId);
            if (imdbIdCheck.Count != 0)
            {
                foreach (string error in imdbIdCheck)
                {
                    Label lblError = new Label();
                    lblError.Text = "- " + error;
                    pnlActionFilmErrorBody.Controls.Add(lblError);
                    pnlActionFilmErrorBody.Controls.Add(new LiteralControl("<br />"));
                    imdbIdOk = false;
                }
                pnlActionFilmError.Visible = true;
            }
            else
            {
                imdbId = Convert.ToInt32(tempImdbId);
                bool ImdbIdAlreadyExists = AllLinks.ImdbIdAlreadyExistsCheck(imdbId);

                if (ImdbIdAlreadyExists)
                {
                    //if (!editFilm) //adding a new film
                    //{
                        Label lblError = new Label();
                        lblError.Text = "- IMDBId already assigned to another film";
                        pnlActionFilmErrorBody.Controls.Add(lblError);
                        pnlActionFilmErrorBody.Controls.Add(new LiteralControl("<br />"));
                        pnlActionFilmError.Visible = true;
                        imdbIdOk = false;
                    //}

                    Int32 originalImdbId = Convert.ToInt32(Session["originalIMDBId"]);

                    if (originalImdbId == imdbId)
                    {
                        imdbIdOk = true;
                    }
                    else
                    {
                        imdbIdOk = false;
                    }

                    //else //if we're editing a film
                    //{
                    //    Int32 originalImdbId = Convert.ToInt32(Session["originalIMDBId"]);
                    //    if (originalImdbId != imdbId)
                    //    {
                    //        Label lblError = new Label();
                    //        lblError.Text = "- IMDBId already assigned to another film";
                    //        pnlActionFilmErrorBody.Controls.Add(lblError);
                    //        pnlActionFilmErrorBody.Controls.Add(new LiteralControl("<br />"));
                    //        imdbIdOk = false;
                    //    }
                    //    else
                    //    {
                    //        imdbIdOk = true;
                    //    }
                    //}
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
                    pnlActionFilmErrorBody.Controls.Add(lblError);
                    filmAlreadyExists = true;
                }
                else //if we ARE editing a film
                {
                    if (newTitle != originalTitle)
                    {
                        Label lblError = new Label();
                        lblError.Text = "Film already exists";
                        pnlActionFilmErrorBody.Controls.Add(lblError);
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
                LoadData();
                pnlActionFilm.Visible = false;
            }

            if (editFilm)
            {
                AllFilms = new clsFilmCollection();
                AllFilms.ThisFilm.FilmId = Convert.ToInt32(Session["FilmId"]);

                newTitle = titleAndYearReleased;

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
                pnlActionFilm.Visible = false;
            }
        }

        protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            pnlActionFilm.Visible = true;
            GenerateFilmYears();
            Page.SetFocus(btnActionFilmCancel);
        }

        void GenerateFilmYears()
        {
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

        protected void grdAllFilms_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 filmId = Convert.ToInt32(((Label)grdAllFilms.Rows[e.RowIndex].FindControl("lblFilmId")).Text);
            clsFilmCollection AllFilms = new clsFilmCollection();
            AllFilms.ThisFilm.FilmId = filmId;
            AllFilms.Delete();
            LoadData();
        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }

        protected void grdAllFilms_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadData();
            grdAllFilms.PageIndex = e.NewPageIndex;
            grdAllFilms.DataBind();
        }
    }
}