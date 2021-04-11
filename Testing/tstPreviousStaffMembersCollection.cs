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
            Int32 count = 14;
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
            TestItem.FirstName = "David";
            TestItem.LastName = "Gilmour";
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

        [TestMethod]
        public void ThisPreviousStaffMemberPropertyOk()
        {
            clsPreviousStaffMembersCollection AllPreviousStaffMembers = new clsPreviousStaffMembersCollection();
            clsPreviousStaffMembers aPreviousStaffMember = new clsPreviousStaffMembers();
            aPreviousStaffMember.PreviousStaffMemberId = 1;
            aPreviousStaffMember.FirstName = "Jimi";
            aPreviousStaffMember.LastName = "Hendrix";
            aPreviousStaffMember.PrivilegeLevelId = 1;
            AllPreviousStaffMembers.ThisPreviousStaffMember = aPreviousStaffMember;
            Assert.AreEqual(AllPreviousStaffMembers.ThisPreviousStaffMember, aPreviousStaffMember);
        }

        [TestMethod]
        public void AddMethodOk()
        {
            clsPreviousStaffMembersCollection AllPreviousStaffMembers = new clsPreviousStaffMembersCollection();
            clsPreviousStaffMembers TestItem = new clsPreviousStaffMembers();
            Int32 primaryKey = 0;
            TestItem.FirstName = "Taylor";
            TestItem.LastName = "Swift";
            TestItem.PrivilegeLevelId = 2;
            AllPreviousStaffMembers.ThisPreviousStaffMember = TestItem;
            primaryKey = AllPreviousStaffMembers.Add();
            TestItem.PreviousStaffMemberId = primaryKey;
            AllPreviousStaffMembers.ThisPreviousStaffMember.Find(primaryKey);
            Assert.AreEqual(AllPreviousStaffMembers.ThisPreviousStaffMember, TestItem);
        }
    }
}


