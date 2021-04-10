using System;
using System.Collections.Generic;

namespace Classes
{
    public class clsUser
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string UserName { get; set; }
        public string LockoutEnabled { get; set; }
        public string LockoutEndDateUtc {get; set;}
        public DateTime LastLogin {get; set;}
    }
}