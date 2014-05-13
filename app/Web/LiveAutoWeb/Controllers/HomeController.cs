using System.Collections.Generic;
using System.Web.Mvc;
using Shared.BuildingBlocks.Api;

namespace LiveAutoWeb.Controllers
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
            var client = new ApiClient();

            var response = client.Post<dynamic>("license/{licenseNo}", "4E7106BA-16B6-44F2-AF4C-D1C411440F8E", new[] { new KeyValuePair<string, object>("licenseNo", licenseNo) });

            return PartialView("SearchResults", response);
        }
    }
}