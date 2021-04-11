using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstPreviousStaffMembers
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsPreviousStaffMembers aPreviousStaffMember = new clsPreviousStaffMembers();
            Assert.IsNotNull(aPreviousStaffMember);
        }

        [TestMethod]
        public void PreviousStaffMemberIdPropertyOk()
        {
            clsPreviousStaffMembers aPreviousStaffMember = new clsPreviousStaffMembers();
            Int32 previousStaffMemberId = 1;
            aPreviousStaffMember.PreviousStaffMemberId = previousStaffMemberId;
            Assert.AreEqual(aPreviousStaffMember.PreviousStaffMemberId, previousStaffMemberId);
        }

        [TestMethod]
        public void FirstNamePropertyOk()
        {
            clsPreviousStaffMembers aPreviousStaffMember = new clsPreviousStaffMembers();
            string firstName = "David";
            aPreviousStaffMember.FirstName = firstName;
            Assert.AreEqual(aPreviousStaffMember.FirstName, firstName);
        }

        [TestMethod]
        public void LastNamePropertyOk()
        {
            clsPreviousStaffMembers aPreviousStaffMember = new clsPreviousStaffMembers();
            string lastName = "Gilmour";
            aPreviousStaffMember.LastName = lastName;
            Assert.AreEqual(aPreviousStaffMember.LastName, lastName);
        }

        [TestMethod]
        public void PrivilegeLevelIdPropertyOk()
        {
            clsPreviousStaffMembers aPreviousStaffMember = new clsPreviousStaffMembers();
            Int32 privilegeLevelId = 1;
            aPreviousStaffMember.PrivilegeLevelId = privilegeLevelId;
            Assert.AreEqual(aPreviousStaffMember.PrivilegeLevelId, privilegeLevelId);
        }

        [TestMethod]
        public void DateTimeRemovedPropertyOk()
        {
            clsPreviousStaffMembers aPreviousStaffMember = new clsPreviousStaffMembers();
            DateTime dateTimeRemoved = DateTime.Now;
            aPreviousStaffMember.DateTimeRemoved = dateTimeRemoved;
            Assert.AreEqual(aPreviousStaffMember.DateTimeRemoved, dateTimeRemoved);
        }

        [TestMethod]
        public void FindMethodOk()
        {
            clsPreviousStaffMembers APreviousStaffMember = new clsPreviousStaffMembers();
            Boolean found;
            Int32 previousStaffMemberId = 1;
            found = APreviousStaffMember.Find(previousStaffMemberId);
            Assert.IsTrue(found);
        }
    }
}