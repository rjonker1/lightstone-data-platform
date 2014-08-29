using System.Web.Mvc;

namespace PackageBuilder.Web.Controllers
{
    public class PackageController : Controller
    {
        public ActionResult Index()
        {
            return View(new TestViewModel());
        }
    }

    public class TestViewModel
    {
        public string NameId { get; set; }
        public string Surnname { get; set; }
        public int Age { get; set; }
    }
}