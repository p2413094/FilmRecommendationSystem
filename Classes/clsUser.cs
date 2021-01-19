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
        //public DateTime DateTimeCreated { get; set; }
        public bool Suspended { get; set; }
    }
}