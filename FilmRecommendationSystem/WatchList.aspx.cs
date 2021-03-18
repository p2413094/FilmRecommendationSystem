﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using Classes;
using System.Drawing;

namespace FilmRecommendationSystem
{
    public partial class WatchList : System.Web.UI.Page
    {
        List<clsFilm> FilmList = new List<clsFilm>();
        clsFilm aFilm = new clsFilm();
        clsImdbAPI anImdbApi= new clsImdbAPI();
        Int32 userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            pnlWatchList.Visible = false;
            userId = Convert.ToInt32(Session["UserId"]);
            DisplayWatchLaterFilms(userId);
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

        void GetFilmNames (Int32 filmId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblFilm_FilterByFilmId");
            aFilm = new clsFilm();
            aFilm.FilmId = Convert.ToInt32(DB.DataTable.Rows[0]["FilmId"]);
            aFilm.Title = DB.DataTable.Rows[0]["Title"].ToString();
            FilmList.Add(aFilm);
        }

        void DisplayWatchLaterFilms(Int32 userId)
        {
            try
            {
                clsDataConnection DB = new clsDataConnection();
                DB.AddParameter("@UserId", userId);
                DB.Execute("sproc_tblWatchList_FilterByUserId");
                Int32 recordCount = DB.Count;
                Int32 index = 0;
                Int32 filmId = 0;
                string title;

                if (recordCount == 0)
                {
                    clsDynamicPanel aDynamicPanel = new clsDynamicPanel();
                    pnlWatchList.Controls.Add(aDynamicPanel.GenerateEmptyListPanel("watch list"));
                    btnSort.Visible = false;
                }
                else
                {
                    while (index < recordCount)
                    {
                        filmId = Convert.ToInt32(DB.DataTable.Rows[index]["FilmId"]);
                        title = DB.DataTable.Rows[index]["Title"].ToString();
                        //GetFilmNames(filmId);
                        pnlWatchList.Controls.Add(anImdbApi.GetImdbInformation(filmId));                    
                        index++;
                    }

                }
                pnlWatchList.Visible = true;
            }
            catch
            {
                pnlError.Visible = true;
            }
        }

        private void ImgbtnRemove_Command(object sender, CommandEventArgs e)
        {
            string filmId = e.CommandArgument.ToString();

            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.AddParameter("@FilmId", filmId);
            DB.Execute("sproc_tblWatchList_Delete");

            DisplayWatchLaterFilms(userId);
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            FilmList.Sort();
            pnlWatchList.Controls.Clear();

            foreach (clsFilm aFilm in FilmList)
            {
                //GetImdbInformation(aFilm.FilmId, aFilm.Title);
            }

        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Response.Redirect("Homepage.aspx");
        }
    }
}