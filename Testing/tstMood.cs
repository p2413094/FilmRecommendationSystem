using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstMood
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsMood aMood = new clsMood();
            Assert.IsNotNull(aMood);
        }

        [TestMethod]
        public void MoodIdPropertyOk()
        {
            clsMood aMood = new clsMood();
            Int32 moodId = 1;
            aMood.MoodId = moodId;
            Assert.AreEqual(aMood.MoodId, moodId);
        }

        [TestMethod]
        public void MoodDescPropertyOk()
        {
            clsMood aMood = new clsMood();
            string moodDesc = "Oscar-worthy";
            aMood.MoodDesc = moodDesc;
            Assert.AreEqual(aMood.MoodDesc, moodDesc);
        }

        [TestMethod]
        public void ValidMethodOk()
        {
            clsMood aMood = new clsMood();
            string error = "";
            string moodDesc = "Oscar-worthy";
            error = aMood.Valid(moodDesc);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void MoodDescMinLessOne()
        {
            clsMood aMood = new clsMood();
            string error = "";
            string moodDesc = "";
            error = aMood.Valid(moodDesc);
            Assert.AreNotEqual(error, "");
        }

        [TestMethod]
        public void MoodDescMinBoundary()
        {
            clsMood aMood = new clsMood();
            string error = "";
            string moodDesc = "a";
            error = aMood.Valid(moodDesc);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void MoodDescMinPlusOne()
        {
            clsMood aMood = new clsMood();
            string error = "";
            string moodDesc = "aa";
            error = aMood.Valid(moodDesc);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void MoodDescMaxLessOne()
        {
            clsMood aMood = new clsMood();
            string error = "";
            string moodDesc = "";
            moodDesc = moodDesc.PadRight(49, 'a');
            error = aMood.Valid(moodDesc);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void MoodDescMaxBoundary()
        {
            clsMood aMood = new clsMood();
            string error = "";
            string moodDesc = "";
            moodDesc = moodDesc.PadRight(50, 'a');
            error = aMood.Valid(moodDesc);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void MoodDescMaxPlusOne()
        {
            clsMood aMood = new clsMood();
            string error = "";
            string moodDesc = "";
            moodDesc = moodDesc.PadRight(51, 'a');
            error = aMood.Valid(moodDesc);
            Assert.AreNotEqual(error, "");
        }

        [TestMethod]
        public void MoodDescMid()
        {
            clsMood aMood = new clsMood();
            string error = "";
            string moodDesc = "";
            moodDesc = moodDesc.PadRight(25, 'a');
            error = aMood.Valid(moodDesc);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void MoodDescExtremeMax()
        {
            clsMood aMood = new clsMood();
            string error = "";
            string moodDesc = "";
            moodDesc = moodDesc.PadRight(500, 'a');
            error = aMood.Valid(moodDesc);
            Assert.AreNotEqual(error, "");
        }

        [TestMethod]
        public void ValidMoodAlreadyExists()
        {
            clsMood aMood = new clsMood();
            string error = "";
            string moodDesc = "funny";
            error = aMood.Valid(moodDesc);
            Assert.AreNotEqual(error, "");
        }

        [TestMethod]
        public void FindMethodOk()
        {
            Boolean found;
            clsMood aMood = new clsMood();
            Int32 moodId = 3648;
            found = aMood.Find(moodId);
            Assert.IsTrue(found);
        }
    }
}