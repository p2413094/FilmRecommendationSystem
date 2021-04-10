using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstUser
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsUser aUser = new clsUser();
            Assert.IsNotNull(aUser);
        }

        [TestMethod]
        public void UserIdPropertyOk()
        {
            clsUser aUser = new clsUser();
            Int32 userId = 1;
            aUser.UserId = userId;
            Assert.AreEqual(aUser.UserId, userId);
        }

        [TestMethod]
        public void EmailPropertyOk()
        {
            clsUser aUser = new clsUser();
            string emailAddress = "ellenripley57@sulaco.com";
            aUser.Email = emailAddress;
            Assert.AreEqual(aUser.Email, emailAddress);
        }

        [TestMethod]
        public void EmailConfirmedPropertyOk()
        {
            clsUser aUser = new clsUser();
            string emailConfirmed = "true";
            aUser.EmailConfirmed = emailConfirmed;
            Assert.AreEqual(aUser.EmailConfirmed, emailConfirmed);
        }

        [TestMethod]
        public void UserNamePropertyOk()
        {
            clsUser aUser = new clsUser();
            string userName = "SarahConnor91";
            aUser.UserName = userName;
            Assert.AreEqual(aUser.UserName, userName);
        }
        
        [TestMethod]
        public void LockoutEnabledPropertyOk()
        {
            clsUser aUser = new clsUser();
            string lockoutEnabled = "False";
            aUser.LockoutEnabled = lockoutEnabled;
            Assert.AreEqual(aUser.LockoutEnabled, lockoutEnabled);
        }

        [TestMethod]
        public void LockoutEndDateUtcPropertyOk()
        {
            clsUser aUser = new clsUser();
            string lockoutEndDateUtc = Convert.ToString(DateTime.Now.AddDays(3));
            aUser.LockoutEndDateUtc = lockoutEndDateUtc;
            Assert.AreEqual(aUser.LockoutEndDateUtc, lockoutEndDateUtc);
        }

        [TestMethod]
        public void LastLoginPropertyOk()
        {
            clsUser aUser = new clsUser();
            DateTime lastLogin = DateTime.Now.AddDays(-3);
            aUser.LastLogin = lastLogin;
            Assert.AreEqual(aUser.LastLogin, lastLogin);
        }
    }
}
