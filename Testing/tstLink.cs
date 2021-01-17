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
            string imdbId = "0072271";
            aLink.ImdbId = imdbId;
            Assert.AreEqual(aLink.ImdbId, imdbId);
        }

        [TestMethod]
        public void ValidMethodOk()
        {
            clsLink aLink = new clsLink();
            string error = "";
            string imdbId = "0072271";
            error = aLink.Valid(imdbId);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void ImdbIdLessOne()
        {
            clsLink aLink = new clsLink();
            string error = "";
            string imdbId = "";
            error = aLink.Valid(imdbId);
            Assert.AreNotEqual(error, "");
        }

        [TestMethod]
        public void ImdbIdMinBoundary()
        {
            clsLink aLink = new clsLink();
            string error = "";
            string imdbId = "0";
            error = aLink.Valid(imdbId);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void ImdbIdMinPlusOne()
        {
            clsLink aLink = new clsLink();
            string error = "";
            string imdbId = "00";
            error = aLink.Valid(imdbId);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void ImdbIdMid()
        {
            clsLink aLink = new clsLink();
            string error = "";
            string imdbId = "0000";
            error = aLink.Valid(imdbId);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void ImdbIdMaxMinusOne()
        {
            clsLink aLink = new clsLink();
            string error = "";
            string imdbId = "0000000";
            error = aLink.Valid(imdbId);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void ImdbIdMaxBoundary()
        {
            clsLink aLink = new clsLink();
            string error = "";
            string imdbId = "00000000";
            error = aLink.Valid(imdbId);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void ImdbIdMaxPlusOne()
        {
            clsLink aLink = new clsLink();
            string error = "";
            string imdbId = "000000000";
            error = aLink.Valid(imdbId);
            Assert.AreNotEqual(error, "");
        }

        [TestMethod]
        public void ImdbIdExtremeMax()
        {
            clsLink aLink = new clsLink();
            string error = "";
            string imdbId = "";
            imdbId = imdbId.PadRight(80, '0');
            error = aLink.Valid(imdbId);
            Assert.AreNotEqual(error, "");
        }
    }
}
