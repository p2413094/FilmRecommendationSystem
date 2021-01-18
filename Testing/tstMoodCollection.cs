using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class tstMoodCollection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsMoodCollection allMoods = new clsMoodCollection();
            Assert.IsNotNull(allMoods);
        }

        [TestMethod]
        public void CountPropertyOk()
        {
            clsMoodCollection allMoods = new clsMoodCollection();
            Int32 count = 3683;
            allMoods.Count = count;
            Assert.AreEqual(allMoods.Count, count);
        }

        [TestMethod]
        public void AllMoodsOk()
        {
            clsMoodCollection moods = new clsMoodCollection();
            List<clsMood> testList = new List<clsMood>();
            clsMood testItem = new clsMood();
            testItem.MoodId = 1;
            testItem.MoodDesc = "Oscar-worthy";
            testList.Add(testItem);
            moods.AllMoods = testList;
            Assert.AreEqual(moods.AllMoods, testList);
        }

        [TestMethod]
        public void CountMatchesList()
        {
            clsMoodCollection moods = new clsMoodCollection();
            List<clsMood> testList = new List<clsMood>();
            clsMood testItem = new clsMood();
            testItem.MoodId = 1;
            testItem.MoodDesc = "Oscar-worthy";
            testList.Add(testItem);
            moods.AllMoods = testList;
            Assert.AreEqual(moods.Count, testList.Count);
        }
    }
}
