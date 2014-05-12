using System.Web.Mvc;

namespace LiveAuto.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string licenseNo)
        {
            return null;
        }
    }
}