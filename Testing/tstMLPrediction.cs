using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Classes;
using Microsoft.ML;

namespace Testing
{
    [TestClass]
    public class tstMLPrediction
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsMLPrediction CreatePredictionEngine = new clsMLPrediction();
            Assert.IsNotNull(CreatePredictionEngine);
        }
    }
}