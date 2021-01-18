using System;

namespace Classes
{
    public class clsFilm
    {
        public int FilmId { get; set; }
        public string Title { get; set; }

        public string Valid(string newFilmTitle)
        {
            string error = "";
            if (newFilmTitle.Length > 180)
            {
                error = "The film title must not be more than 180 characters";
            }
            if (newFilmTitle.Length == 0)
            {
                error = "The film title must be more than 1 character";
            }
            return error;
        }
    }
}