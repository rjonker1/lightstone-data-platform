using System;
using System.Linq;
using System.Web.Mvc;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Helpers;
using LiveAutoWeb.Models;
using LiveAutoWeb.ViewModels;
using Shared.BuildingBlocks.Api;

namespace LiveAutoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiClient _apiClient = new ApiClient();
        public ActionResult Index()
        {
            var response = _apiClient.Get<ApiMetaData>("4E7106BA-16B6-44F2-AF4C-D1C411440F8E");

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search()
        {
            var response = _apiClient.Get<ApiMetaData>("4E7106BA-16B6-44F2-AF4C-D1C411440F8E");

            var dict = response.Actions.First().Criteria.Fields.ToDictionary(x => x.Name, x => Type.GetType(x.Type));
            var dynamicType = DynamicTypeCreator.CreateNewType("dynamicPageViewModel", dict, typeof(DynamicPageViewModel));
            var viewModel = Activator.CreateInstance(dynamicType);
            var action = response.Actions.First().Name;
            var url = response.Path.Replace("{action}", action);
            ((DynamicPageViewModel) viewModel).Url = url;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(Vechicle model)
        {
            var response = _apiClient.Post<dynamic>("4E7106BA-16B6-44F2-AF4C-D1C411440F8E", model.Url, model);

            return PartialView("SearchResults", response);
        }
    }
}