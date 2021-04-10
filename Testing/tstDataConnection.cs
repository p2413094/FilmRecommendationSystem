using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstDataConnection
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsDataConnection DB = new clsDataConnection();
            Assert.IsNotNull(DB);
        }
    }
}
