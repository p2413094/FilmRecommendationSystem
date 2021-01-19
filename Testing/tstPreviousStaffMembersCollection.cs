using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstPreviousStaffMembersCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsPreviousStaffMembersCollection AllPreviousStaffMembers = new clsPreviousStaffMembersCollection();
            Assert.IsNotNull(AllPreviousStaffMembers);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsPreviousStaffMembersCollection AllPreviousStaffMembers = new clsPreviousStaffMembersCollection();
            Int32 count = 0;
            AllPreviousStaffMembers.Count = count;
            Assert.AreEqual(AllPreviousStaffMembers.Count, count);
        }

        [TestMethod]
        public void AllPreviousStaffMembersOk()
        {
            clsPreviousStaffMembersCollection PreviousStaffMembers = new clsPreviousStaffMembersCollection();
            List<clsPreviousStaffMembers> TestList = new List<clsPreviousStaffMembers>();
            clsPreviousStaffMembers TestItem = new clsPreviousStaffMembers();
            TestItem.PreviousStaffMemberId = 1;
            TestItem.FirstName = "Brian";
            TestItem.LastName = "May";
            TestItem.PrivilegeLevelId = 1;
            TestItem.DateTimeRemoved = DateTime.Now;
            TestList.Add(TestItem);
            PreviousStaffMembers.AllPreviousStaffMembers = TestList;
            Assert.AreEqual(PreviousStaffMembers.AllPreviousStaffMembers, TestList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsPreviousStaffMembersCollection PreviousStaffMembers = new clsPreviousStaffMembersCollection();
            List<clsPreviousStaffMembers> TestList = new List<clsPreviousStaffMembers>();
            clsPreviousStaffMembers TestItem = new clsPreviousStaffMembers();
            TestItem.PreviousStaffMemberId = 1;
            TestItem.FirstName = "Brian";
            TestItem.LastName = "May";
            TestItem.PrivilegeLevelId = 1;
            TestItem.DateTimeRemoved = DateTime.Now;
            TestList.Add(TestItem);
            PreviousStaffMembers.AllPreviousStaffMembers = TestList;
            Assert.AreEqual(PreviousStaffMembers.Count, TestList.Count);
        }
    }
}
