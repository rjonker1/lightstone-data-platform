using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Web.Mvc;
using LightstoneApp.Application.PackageBuilderModule.AppServices;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;
using LightstoneApp.Presentation.Web.Mvc.Client.Resources;
using LightstoneApp.Presentation.Web.Mvc.Client.ViewModels;

namespace LightstoneApp.Presentation.Web.Mvc.Client.Controllers
{
    public class IndustryController : ControllerBase
    {
        #region Fields

        private readonly IDataFieldAppService _serviceDataFields;
        private readonly IIndustryAppService _serviceIndustry;
        private readonly IPackageAppService _servicePackages;

        #endregion

        #region Constructor

        /// <summary>
        ///     Create a new instance of Industry controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataFields">Service dependency</param>
        /// <param name="servicePackages">Service dependency</param>
        public IndustryController(IIndustryAppService service, IDataFieldAppService serviceDataFields,
            IPackageAppService servicePackages)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceDataFields == null)
                throw new ArgumentNullException("serviceDataFields", PresentationResources.exception_WithoutService);
            if (servicePackages == null)
                throw new ArgumentNullException("servicePackages", PresentationResources.exception_WithoutService);

            _serviceIndustry = service;
            _serviceDataFields = serviceDataFields;
            _servicePackages = servicePackages;
        }

        #endregion

        // GET
        public ActionResult Add()
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddIndustry Controller Begin"));

            try
            {
                // Add add logic here
                var model = new IndustryCrudViewModel(_serviceIndustry, _serviceDataFields, _servicePackages);

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddIndustry Controller End"));
                return View("IndustryAddView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddIndustry Controller ERROR"),
                        ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IndustryCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddIndustry Controller Begin"));

            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    bool committed = _serviceIndustry.Add(model.Industry, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - AddIndustry Controller End"));
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddIndustry Controller ERROR"),
                        ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("IndustryAddView",
                new IndustryCrudViewModel(_serviceIndustry, _serviceDataFields, _servicePackages));
        }

        // GET
        public ActionResult Modify(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - ModifyIndustry Controller Begin"));

            try
            {
                // Add modify logic here
                var model = new IndustryCrudViewModel(_serviceIndustry, _serviceDataFields, _servicePackages)
                {
                    Industry = _serviceIndustry.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - ModifyIndustry Controller End"));
                return View("IndustryModifyView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - ModifyIndustry Controller ERROR"), ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(IndustryCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - ModifyIndustry Controller Begin"));

            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    bool committed = _serviceIndustry.Modify(model.Industry, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - ModifyIndustry Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - ModifyIndustry Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("IndustryModifyView",
                new IndustryCrudViewModel(_serviceIndustry, _serviceDataFields, _servicePackages));
        }

        // GET
        public ActionResult Remove(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - RemoveIndustry Controller Begin"));

            try
            {
                // Add remove logic here
                var model = new IndustryCrudViewModel(_serviceIndustry, _serviceDataFields, _servicePackages)
                {
                    Industry = _serviceIndustry.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - RemoveIndustry Controller End"));
                return View("IndustryRemoveView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemoveIndustry Controller ERROR"), ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(IndustryCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - RemoveIndustry Controller Begin"));

            try
            {
                // Add remove logic here
                bool committed = _serviceIndustry.Remove(model.Industry, null);
                if (committed)
                {
                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemoveIndustry Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemoveIndustry Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("IndustryRemoveView",
                new IndustryCrudViewModel(_serviceIndustry, _serviceDataFields, _servicePackages));
        }

        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindIndustry Controller Begin"));

            try
            {
                // Add find logic here
                IndustryFindViewModel model;

                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterIndustry"))
                {
                    model = (IndustryFindViewModel) TempData.Peek("FilterIndustry");
                    PagedCollection<Industry> pagedResult =
                        _serviceIndustry.FindPagedByFilter(
                            new CustomQuery<Industry> {SerializedExpression = model.Filter}, null,
                            page != null ? (int) page : model.PageIndex, model.PageSize, new List<string> {sort},
                            sortDir == "ASC", null);
                    model.Paginate(pagedResult, model.Filter);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindPagedIndustry Controller End"));
                    return PartialView("_IndustryFindPartialView", model);
                }
                TempData.Remove("FilterIndustry");
                model = new IndustryFindViewModel(_serviceIndustry, _serviceDataFields, _servicePackages);
                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - FindIndustry Controller End"));
                return View("IndustryFindView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindIndustry Controller ERROR"),
                        ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(IndustryFindViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindIndustry Controller Begin"));

            try
            {
                // Add find logic here
                if (ModelState.IsValid)
                {
                    CustomQuery<Industry> expression = GenerateExpression(model);
                    var includes = new List<string>();
                    PagedCollection<Industry> pagedResult = _serviceIndustry.FindPagedByFilter(expression, includes, 1,
                        model.PageSize, model.OrderBy, model.Ascendent, null);
                    model.Paginate(pagedResult, expression.SerializedExpression);

                    TempData.Clear();
                    TempData.Add("FilterIndustry", model);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindIndustry Controller End"));
                    return PartialView("_IndustryFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindIndustry Controller ERROR"),
                        ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("IndustryFindView",
                new IndustryFindViewModel(_serviceIndustry, _serviceDataFields, _servicePackages));
        }

        #region Private Methods

        private static CustomQuery<Industry> GenerateExpression(IndustryFindViewModel model)
        {
            Expression<Func<Industry, bool>> expression = null;

            if (model.Industry.Id.HasValue)
                expression = expression.And(d => d.Id == model.Industry.Id.Value);
            if (!string.IsNullOrEmpty(model.Industry.Value))
                expression = expression.And(d => d.Value.Contains(model.Industry.Value));

            return new CustomQuery<Industry>(expression ?? (d => true));
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        ///     <see cref="M:System.IDisposable.Dispose" />
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serviceIndustry.Dispose();
                _serviceDataFields.Dispose();
                _servicePackages.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}