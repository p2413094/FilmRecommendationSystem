using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstStaffMember
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Assert.IsNotNull(aStaffMember);
        }

        [TestMethod]
        public void StaffMemberIdPropertyOk()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 staffMemberId = 1;
            aStaffMember.StaffMemberId = staffMemberId;
            Assert.AreEqual(aStaffMember.StaffMemberId, staffMemberId);
        }

        [TestMethod]
        public void UserIdPropertyOk()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 userId = 1;
            aStaffMember.UserId = userId;
            Assert.AreEqual(aStaffMember.UserId, userId);
        }

        [TestMethod]
        public void PrivilegeLevelIdPropertyOk()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 privilegeLevelId = 1;
            aStaffMember.PrivilegeLevelId = privilegeLevelId;
            Assert.AreEqual(aStaffMember.PrivilegeLevelId, privilegeLevelId);
        }

        [TestMethod]
        public void ConfirmedPropertyOk()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            bool confirmed = true;
            aStaffMember.Confirmed = confirmed;
            Assert.AreEqual(aStaffMember.Confirmed, confirmed);
        }

        [TestMethod]
        public void FirstNamePropertyOk()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            string firstName = "Alan";
            aStaffMember.FirstName = firstName;
            Assert.AreEqual(aStaffMember.FirstName, firstName);
        }

        [TestMethod]
        public void LastNamePropertyOk()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            string lastName = "Turing";
            aStaffMember.LastName = lastName;
            Assert.AreEqual(aStaffMember.LastName, lastName);
        }

        [TestMethod]
        public void AllowedPropertyOk()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            bool allowed = true;
            aStaffMember.Allowed = allowed;
            Assert.AreEqual(aStaffMember.Allowed, allowed);
        }

        [TestMethod]
        public void ValidMethodOk()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "James";
            string lastName = "Cameron";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void FistNameMinLessOne()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "J";
            string lastName = "Cameron";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void FirstNameMinBoundary()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "J";
            string lastName = "Cameron";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void FirstNameMinPlusOne()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "Ja";
            string lastName = "Cameron";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void FirstNameMid()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "";
            firstName = firstName.PadRight(25, 'J');
            string lastName = "Cameron";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void FirstNameMaxMinusOne()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "";
            firstName = firstName.PadRight(49, 'J');
            string lastName = "Cameron";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void FirstNameMaxBoundary()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "";
            firstName = firstName.PadRight(50, 'J');
            string lastName = "Cameron";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void FirstNameMaxPlusOne()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "";
            firstName = firstName.PadRight(51, 'J');
            string lastName = "Cameron";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void FirstNameExtremeMax()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "";
            firstName = firstName.PadRight(500, 'J');
            string lastName = "Cameron";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void LastNameMinLessOne()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "James";
            string lastName = "";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void LastNameMinBoundary()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "James";
            string lastName = "C";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void LastNameMinPlusOne()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "James";
            string lastName = "CA";
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void LastNameMid()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "James";
            string lastName = "";
            lastName = lastName.PadRight(25, 'C');
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void LastNameMaxMinusOne()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "James";
            string lastName = "";
            lastName = lastName.PadRight(49, 'C');
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void LastNameMaxBoundary()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "James";
            string lastName = "";
            lastName = lastName.PadRight(50, 'C');
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void LastNameMaxPlusOne()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "James";
            string lastName = "";
            lastName = lastName.PadRight(51, 'C');
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void LastNameExtremeMax()
        {
            clsStaffMember aStaffMember = new clsStaffMember();
            Int32 errorCount = 0;
            string firstName = "James";
            string lastName = "";
            lastName = lastName.PadRight(500, 'C');
            errorCount = aStaffMember.Valid(firstName, lastName).Count;
            Assert.AreEqual(errorCount, 0);
        }

        [TestMethod]
        public void FindMethodOk()
        {
            clsStaffMember AStaffMember = new clsStaffMember();
            Boolean found;
            Int32 staffMemberId = 1;
            found = AStaffMember.Find(staffMemberId);
            Assert.IsTrue(found);
        }

    }
}
