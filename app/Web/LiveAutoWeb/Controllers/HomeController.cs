using System.Web.Mvc;
using Shared.BuildingBlocks.Api;

namespace LiveAutoWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var client = new ApiClient();

            var response = client.Get("4E7106BA-16B6-44F2-AF4C-D1C411440F8E");

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string licenseNo)
        {
            var client = new ApiClient();

            var response = client.Post<dynamic>("4E7106BA-16B6-44F2-AF4C-D1C411440F8E", "license", "licenseNo=" + licenseNo);

            return PartialView("SearchResults", response);
        }
    }
}