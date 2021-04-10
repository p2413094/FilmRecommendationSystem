using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstLink
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsLink aLink = new clsLink();
            Assert.IsNotNull(aLink);
        }

        [TestMethod]
        public void FilmIdPropertyOk()
        {
            clsLink aLink = new clsLink();
            int filmId = 1;
            aLink.FilmId = filmId;
            Assert.AreEqual(aLink.FilmId, filmId);
        }

        [TestMethod]
        public void ImdbIdPropertyOk()
        {
            clsLink aLink = new clsLink();
            Int32 imdbId = 0072271;
            aLink.ImdbId = imdbId;
            Assert.AreEqual(aLink.ImdbId, imdbId);
        }

        [TestMethod]
        public void ValidMethodOk()
        {
            clsLink aLink = new clsLink();
            Int32 error = 0;
            string imdbId = "0072271";
            error = aLink.Valid(imdbId).Count;
            Assert.AreEqual(error, 0);
        }

        [TestMethod]
        public void ImdbIdLessOne()
        {
            clsLink aLink = new clsLink();
            Int32 error = 0;
            string imdbId = "";
            error = aLink.Valid(imdbId).Count;
            Assert.AreNotEqual(error, 0);
        }

        [TestMethod]
        public void ImdbIdMinBoundary()
        {
            clsLink aLink = new clsLink();
            Int32 error = 0;
            string imdbId = "0";
            error = aLink.Valid(imdbId).Count;
            Assert.AreEqual(error, 0);
        }

        [TestMethod]
        public void ImdbIdMinPlusOne()
        {
            clsLink aLink = new clsLink();
            Int32 error = 0;
            string imdbId = "00";
            error = aLink.Valid(imdbId).Count;
            Assert.AreEqual(error, 0);
        }

        [TestMethod]
        public void ImdbIdMid()
        {
            clsLink aLink = new clsLink();
            Int32 error = 0;
            string imdbId = "0000";
            error = aLink.Valid(imdbId).Count;
            Assert.AreEqual(error, 0);
        }

        [TestMethod]
        public void ImdbIdMaxMinusOne()
        {
            clsLink aLink = new clsLink();
            Int32 error = 0;
            string imdbId = "0000000";
            error = aLink.Valid(imdbId).Count;
            Assert.AreEqual(error, 0);
        }

        [TestMethod]
        public void ImdbIdMaxBoundary()
        {
            clsLink aLink = new clsLink();
            Int32 error = 0;
            string imdbId = "00000000";
            error = aLink.Valid(imdbId).Count;
            Assert.AreEqual(error, 0);
        }

        [TestMethod]
        public void ImdbIdMaxPlusOne()
        {
            clsLink aLink = new clsLink();
            Int32 error = 0;
            string imdbId = "000000000";
            error = aLink.Valid(imdbId).Count;
            Assert.AreNotEqual(error, 0);
        }

        [TestMethod]
        public void ImdbIdExtremeMax()
        {
            clsLink aLink = new clsLink();
            Int32 error = 0;
            string imdbId = "";
            imdbId = imdbId.PadRight(80, '0');
            error = aLink.Valid(imdbId).Count;
            Assert.AreNotEqual(error, 0);
        }

        [TestMethod]
        public void IllictCharacter()
        {
            clsLink aLink = new clsLink();
            Int32 error = 0;
            string illicitCharacter = "111111@";
            error = aLink.Valid(illicitCharacter).Count;
            Assert.AreNotEqual(error, 0);
        }

        [TestMethod]
        public void FindMethodOk()
        {
            clsLink aLink = new clsLink();
            Boolean found;
            Int32 filmId = 1;
            found = aLink.Find(filmId);
            Assert.IsTrue(found);
        }
    }
}
