using FilmRecommendationSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class tstDynamicPanel
    {
        [TestMethod]
        public void InstanceOk()
        {
            clsDynamicPanel aDynamicPanel = new clsDynamicPanel();
            Assert.IsNotNull(aDynamicPanel);
        }

        [TestMethod]
        public void GenerateSignInRegisterNavbarMethodOk()
        {
            clsDynamicPanel aDynamicPanel = new clsDynamicPanel();
            Assert.IsNotNull(aDynamicPanel.GenerateSignInRegisterNavbar());
        }

        [TestMethod]
        public void GenerateMyAccountDropDownMethodOk()
        {
            clsDynamicPanel aDynamicPanel = new clsDynamicPanel();
            Assert.IsNotNull(aDynamicPanel.GenerateMyAccountDropDown());
        }

        [TestMethod]
        public void GenerateEmptyListPanelMethodOk()
        {
            clsDynamicPanel aDynamicPanel = new clsDynamicPanel();
            string testData = "Louder Than Words";
            Assert.IsNotNull(aDynamicPanel.GenerateEmptyListPanel(testData));
        }
    }
}
