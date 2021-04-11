using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstUserCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsUserCollection AllUsers = new clsUserCollection();
            Assert.IsNotNull(AllUsers);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsUserCollection AllUsers = new clsUserCollection();
            Int32 count = 12;
            AllUsers.Count = count;
            Assert.AreEqual(AllUsers.Count, count);
        }

        [TestMethod]
        public void AllUsersOk()
        {
            clsUserCollection Users = new clsUserCollection();
            List<clsUser> TestList = new List<clsUser>();
            clsUser TestItem = new clsUser();
            TestItem.UserId = 1;
            TestItem.Email = "t800@cyberdynesystems.co.uk";
            TestItem.EmailConfirmed = "true";
            TestItem.UserName = "T-800";
            TestItem.LockoutEnabled = "False";
            TestList.Add(TestItem);
            Users.AllUsers = TestList;
            Assert.AreEqual(Users.AllUsers, TestList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsUserCollection Users = new clsUserCollection();
            List<clsUser> TestList = new List<clsUser>();
            clsUser TestItem = new clsUser();
            TestItem.UserId = 1;
            TestItem.Email = "t800@cyberdynesystems.co.uk";
            TestItem.EmailConfirmed = "true";
            TestItem.UserName = "T-800";
            TestItem.LockoutEnabled = "False";
            TestList.Add(TestItem);
            Users.AllUsers = TestList;
            Assert.AreEqual(Users.Count, TestList.Count);
        }
    }
}
