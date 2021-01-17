using System;

namespace Classes
{
    public class clsLink
    {
        public int FilmId { get; set; }
        public string ImdbId { get; set; }


        public string Valid(string imdbId)
        {
            string error = "";
            if (imdbId.Length > 8)
            {
                error = "The ImdbId must not be more than 8 characters";
            }
            if (imdbId.Length == 0)
            {
                error = "The ImdbId must be more than 1 character";
            }
            return error;
        }
    }
}