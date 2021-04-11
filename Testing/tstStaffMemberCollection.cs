using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstStaffMemberCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            Assert.IsNotNull(AllStaffMembers);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            Int32 count = 14;
            AllStaffMembers.Count = count;
            Assert.AreEqual(AllStaffMembers.Count, count);
        }

        [TestMethod]
        public void AllStaffMembersOk()
        {
            clsStaffMemberCollection StaffMembers = new clsStaffMemberCollection();
            List<clsStaffMember> TestList = new List<clsStaffMember>();
            clsStaffMember TestItem = new clsStaffMember();
            TestItem.StaffMemberId = 1;
            TestItem.UserId = 1;
            TestItem.PrivilegeLevelId = 1;
            TestItem.FirstName = "Pink";
            TestItem.LastName = "Floyd";
            TestItem.Confirmed = true;
            TestItem.Allowed = true;
            TestList.Add(TestItem);
            StaffMembers.AllStaffMembers = TestList;
            Assert.AreEqual(StaffMembers.AllStaffMembers, TestList);
        }

        [TestMethod]
        public void ThisStaffMemberPropertyOk()
        {
            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            clsStaffMember TestItem = new clsStaffMember();
            TestItem.UserId = 1;
            TestItem.PrivilegeLevelId = 1;
            TestItem.FirstName = "Lana";
            TestItem.LastName = "Del Rey";
            AllStaffMembers.ThisStaffMember = TestItem;
            Assert.AreEqual(AllStaffMembers.ThisStaffMember, TestItem);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsStaffMemberCollection StaffMembers = new clsStaffMemberCollection();
            List<clsStaffMember> TestList = new List<clsStaffMember>();
            clsStaffMember TestItem = new clsStaffMember();
            TestItem.StaffMemberId = 1;
            TestItem.UserId = 1;
            TestItem.PrivilegeLevelId = 1;
            TestItem.FirstName = "Tobe";
            TestItem.LastName = "Hooper";
            TestItem.Confirmed = true;
            TestItem.Allowed = true;
            TestList.Add(TestItem);
            StaffMembers.AllStaffMembers = TestList;
            Assert.AreEqual(StaffMembers.Count, TestList.Count);
        }

        [TestMethod]
        public void AddMethodOk()
        {
            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            clsStaffMember TestItem = new clsStaffMember();
            Int32 primaryKey = 0;
            TestItem.UserId = 2;
            TestItem.PrivilegeLevelId = 1;
            TestItem.FirstName = "Martin";
            TestItem.LastName = "Scorsese";
            AllStaffMembers.ThisStaffMember = TestItem;
            primaryKey = AllStaffMembers.Add();
            AllStaffMembers.ThisStaffMember.Find(primaryKey);
            Assert.AreEqual(AllStaffMembers.ThisStaffMember, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOk()
        {
            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            clsStaffMember TestItem = new clsStaffMember();
            Int32 primaryKey = 0;
            TestItem.UserId = 2;
            TestItem.PrivilegeLevelId = 1;
            TestItem.FirstName = "Peter";
            TestItem.LastName = "Jackson";
            TestItem.Confirmed = true;
            TestItem.Allowed = true;
            AllStaffMembers.ThisStaffMember = TestItem;
            primaryKey = AllStaffMembers.Add();
            TestItem.StaffMemberId = primaryKey;

            TestItem.UserId = 2;
            TestItem.PrivilegeLevelId = 1;
            TestItem.FirstName = "Pete";
            TestItem.LastName = "Jacson";
            TestItem.Confirmed = false;
            TestItem.Allowed = false;
            AllStaffMembers.ThisStaffMember = TestItem;
            AllStaffMembers.Update();
            AllStaffMembers.ThisStaffMember.Find(primaryKey);
            Assert.AreEqual(AllStaffMembers.ThisStaffMember, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOk()
        {
            clsStaffMemberCollection AllStaffMembers = new clsStaffMemberCollection();
            clsStaffMember TestItem = new clsStaffMember();
            Int32 primaryKey = 0;
            TestItem.UserId = 3;
            TestItem.PrivilegeLevelId = 1;
            TestItem.FirstName = "Martin";
            TestItem.LastName = "Scorsese";
            TestItem.Confirmed = true;
            TestItem.Allowed = true;
            AllStaffMembers.ThisStaffMember = TestItem;
            primaryKey = AllStaffMembers.Add();
            TestItem.StaffMemberId = primaryKey;
            AllStaffMembers.ThisStaffMember.Find(primaryKey);
            AllStaffMembers.Delete();
            Boolean found = AllStaffMembers.ThisStaffMember.Find(primaryKey);
            Assert.IsFalse(found);       
        }
    }
}
