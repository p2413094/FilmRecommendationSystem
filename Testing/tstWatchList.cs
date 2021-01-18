using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstWatchList
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsWatchList AllFilmsInWatchList = new clsWatchList();
            Assert.IsNotNull(AllFilmsInWatchList);
        }

        [TestMethod]
        public void UserIdPropertyOk()
        {
            clsWatchList AllFilmsInWatchList = new clsWatchList();
            Int32 userId = 1;
            AllFilmsInWatchList.UserId = userId;
            Assert.AreEqual(AllFilmsInWatchList.UserId, userId);
        }

        [TestMethod]
        public void FilmIdPropertyOk()
        {
            clsWatchList AllFilmsInWatchList = new clsWatchList();
            Int32 filmId = 1;
            AllFilmsInWatchList.FilmId = filmId;
            Assert.AreEqual(AllFilmsInWatchList.FilmId, filmId);
        }

        [TestMethod]
        public void DateAddedPropertyOk()
        {
            clsWatchList AllFilmsInWatchList = new clsWatchList();
            DateTime dateAdded = DateTime.Now;
            AllFilmsInWatchList.DateAdded = dateAdded;
            Assert.AreEqual(AllFilmsInWatchList.DateAdded, dateAdded);
        }
    }
}
