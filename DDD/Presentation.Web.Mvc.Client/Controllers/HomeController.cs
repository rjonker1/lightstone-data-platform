using System.Web.Mvc;

namespace LightstoneApp.Presentation.Web.Mvc.Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "TODO: Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}