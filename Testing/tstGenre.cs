using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstGenre
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsGenre aGenre = new clsGenre();
            Assert.IsNotNull(aGenre);
        }

        [TestMethod]
        public void GenreIdPropertyOk()
        {
            clsGenre aGenre = new clsGenre();
            Int32 genreId = 1;
            aGenre.GenreId = genreId;
            Assert.AreEqual(aGenre.GenreId, genreId);
        }

        [TestMethod]
        public void GenreDescPropertyOk()
        {
            clsGenre aGenre = new clsGenre();
            string genreDesc = "Sci-Fi";
            aGenre.GenreDesc = genreDesc;
            Assert.AreEqual(aGenre.GenreDesc, genreDesc);
        }
    }
}