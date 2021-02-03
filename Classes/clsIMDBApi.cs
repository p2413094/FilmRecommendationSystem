﻿namespace Classes
{
    public class clsIMDBApi
    {
        public string Title {get; set; }
        public string Year {get; set; }
        public string Rated { get; set; }

        public string Released {get; set;}

        public string Plot { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Runtime { get; set; }
        public string Poster { get; set; }
        public string ImdbId { get; set; }
        public bool Response {get; set;}
    }
}