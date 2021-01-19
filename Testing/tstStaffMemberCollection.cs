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
            Int32 count = 0;
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
            TestItem.FirstName = "Tobe";
            TestItem.LastName = "Hooper";
            TestItem.Confirmed = true;
            TestItem.Allowed = true;
            TestList.Add(TestItem);
            StaffMembers.AllStaffMembers = TestList;
            Assert.AreEqual(StaffMembers.AllStaffMembers, TestList);
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
    }
}
