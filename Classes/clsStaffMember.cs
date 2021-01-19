using System;

namespace Classes
{
    public class clsStaffMember
    {
        public int StaffMemberId { get; set; }
        public int UserId { get; set; }
        public int PrivilegeLevelId { get; set; }
        public bool Confirmed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Allowed { get; set; }

        public string Valid(string firstName, string lastName)
        {
            string error = "";
            if (firstName.Length > 50)
            {
                error = "The first name must not be more than 50 characters";
            }
            if (firstName.Length == 0)
            {
                error = "The first name must be more than 1 character";
            }

            if (lastName.Length > 50)
            {
                error = "The last name must not be more than 50 characters";
            }
            if (lastName.Length == 0)
            {
                error = "The last name must be more than 1 character";
            }
            return error;
        }
    }
}