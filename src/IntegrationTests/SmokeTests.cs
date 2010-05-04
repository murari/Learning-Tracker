using System.Web.Mvc;
using LearningTracker.UI.Code.Controllers;
using NUnit.Framework;

namespace LearningTracker.IntegrationTests {
    [TestFixture]
    public class SmokeTests {
        [Test]
        public void HomeController_Able_get_index_view() {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }
    }
}