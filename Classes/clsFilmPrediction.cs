using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmRecommendationSystem
{
    public class clsFilmPrediction : IComparable<clsFilmPrediction>
    {
        private Int32 mFilmId;
        private float mScore;
        public Int32 FilmId
        {
            get { return mFilmId;}
            set {mFilmId = value;}
        }

        public float Score
        {
            get {return mScore;}
            set {mScore = value;}
        }

        public int CompareTo (clsFilmPrediction film)
        {
            if (this.Score < film.Score)
            {
                return 1;
            }
            else if (this.Score > film.Score)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}