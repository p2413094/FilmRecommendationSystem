using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Classes;

namespace Testing
{
    [TestClass]
    public class tstEmail
    {
        [TestMethod]
        public void InstanceOk()
        {
            string destination = "";
            clsEmail anEmail = new clsEmail(destination);
            Assert.IsNotNull(anEmail);
        }
    }
}


