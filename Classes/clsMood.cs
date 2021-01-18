using System;

namespace Classes
{
    public class clsMood
    {
        public int MoodId { get; set; }
        public string MoodDesc { get; set; }

        public string Valid(string moodDesc)
        {
            string error = "";
            if (moodDesc.Length > 50)
            {
                error = "The mood description must not be more than 50 characters";
            }
            if (moodDesc.Length == 0)
            {
                error = "The mood description must be more than 1 character";
            }
            return error;
        }
    }
}