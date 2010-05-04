using System.Web.Mvc;

namespace LearningTracker.UI.Code.Controllers {
    public class HomeController : ApplicationController {
        public ActionResult Index() {
            return View();
        }
    }
}