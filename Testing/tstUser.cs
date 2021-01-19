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
        public void SuspendedPropertyOk()
        {
            clsUser aUser = new clsUser();
            bool suspended = false;
            aUser.Suspended = suspended;
            Assert.AreEqual(aUser.Suspended, suspended);
        }
    }
}
