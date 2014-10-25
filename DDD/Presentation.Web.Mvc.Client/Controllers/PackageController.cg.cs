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
    public class PackageController : ControllerBase
    {
        #region Fields

        private readonly IIndustryAppService _serviceIndustry;
        private readonly IPackageAppService _servicePackage;
        private readonly IPackageDataFieldAppService _servicePackageDataFields;
        private readonly IStateAppService _serviceState;

        #endregion

        #region Constructor

        /// <summary>
        ///     Create a new instance of Package controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceIndustry">Service dependency</param>
        /// <param name="serviceState">Service dependency</param>
        /// <param name="servicePackageDataFields">Service dependency</param>
        public PackageController(IPackageAppService service, IIndustryAppService serviceIndustry,
            IStateAppService serviceState, IPackageDataFieldAppService servicePackageDataFields)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceIndustry == null)
                throw new ArgumentNullException("serviceIndustry", PresentationResources.exception_WithoutService);
            if (serviceState == null)
                throw new ArgumentNullException("serviceState", PresentationResources.exception_WithoutService);
            if (servicePackageDataFields == null)
                throw new ArgumentNullException("servicePackageDataFields",
                    PresentationResources.exception_WithoutService);

            _servicePackage = service;
            _serviceIndustry = serviceIndustry;
            _serviceState = serviceState;
            _servicePackageDataFields = servicePackageDataFields;
        }

        #endregion

        // GET
        public ActionResult Add()
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPackage Controller Begin"));

            try
            {
                // Add add logic here
                var model = new PackageCrudViewModel(_servicePackage, _serviceIndustry, _serviceState,
                    _servicePackageDataFields);

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPackage Controller End"));
                return View("PackageAddView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPackage Controller ERROR"),
                        ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PackageCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPackage Controller Begin"));

            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    bool committed = _servicePackage.Add(model.Package, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - AddPackage Controller End"));
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPackage Controller ERROR"),
                        ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("PackageAddView",
                new PackageCrudViewModel(_servicePackage, _serviceIndustry, _serviceState, _servicePackageDataFields));
        }

        // GET
        public ActionResult Modify(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPackage Controller Begin"));

            try
            {
                // Add modify logic here
                var model = new PackageCrudViewModel(_servicePackage, _serviceIndustry, _serviceState,
                    _servicePackageDataFields)
                {
                    Package = _servicePackage.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - ModifyPackage Controller End"));
                return View("PackageModifyView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - ModifyPackage Controller ERROR"), ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(PackageCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPackage Controller Begin"));

            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    bool committed = _servicePackage.Modify(model.Package, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - ModifyPackage Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - ModifyPackage Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("PackageModifyView",
                new PackageCrudViewModel(_servicePackage, _serviceIndustry, _serviceState, _servicePackageDataFields));
        }

        // GET
        public ActionResult Remove(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePackage Controller Begin"));

            try
            {
                // Add remove logic here
                var model = new PackageCrudViewModel(_servicePackage, _serviceIndustry, _serviceState,
                    _servicePackageDataFields)
                {
                    Package = _servicePackage.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - RemovePackage Controller End"));
                return View("PackageRemoveView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemovePackage Controller ERROR"), ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(PackageCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePackage Controller Begin"));

            try
            {
                // Add remove logic here
                bool committed = _servicePackage.Remove(model.Package, null);
                if (committed)
                {
                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemovePackage Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemovePackage Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("PackageRemoveView",
                new PackageCrudViewModel(_servicePackage, _serviceIndustry, _serviceState, _servicePackageDataFields));
        }

        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPackage Controller Begin"));

            try
            {
                // Add find logic here
                PackageFindViewModel model;

                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterPackage"))
                {
                    model = (PackageFindViewModel) TempData.Peek("FilterPackage");
                    PagedCollection<Package> pagedResult =
                        _servicePackage.FindPagedByFilter(
                            new CustomQuery<Package> {SerializedExpression = model.Filter}, null,
                            page != null ? (int) page : model.PageIndex, model.PageSize, new List<string> {sort},
                            sortDir == "ASC", null);
                    model.Paginate(pagedResult, model.Filter);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindPagedPackage Controller End"));
                    return PartialView("_PackageFindPartialView", model);
                }
                TempData.Remove("FilterPackage");
                model = new PackageFindViewModel(_servicePackage, _serviceIndustry, _serviceState,
                    _servicePackageDataFields);
                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPackage Controller End"));
                return View("PackageFindView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPackage Controller ERROR"),
                        ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(PackageFindViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPackage Controller Begin"));

            try
            {
                // Add find logic here
                if (ModelState.IsValid)
                {
                    CustomQuery<Package> expression = GenerateExpression(model);
                    var includes = new List<string>();
                    PagedCollection<Package> pagedResult = _servicePackage.FindPagedByFilter(expression, includes, 1,
                        model.PageSize, model.OrderBy, model.Ascendent, null);
                    model.Paginate(pagedResult, expression.SerializedExpression);

                    TempData.Clear();
                    TempData.Add("FilterPackage", model);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindPackage Controller End"));
                    return PartialView("_PackageFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPackage Controller ERROR"),
                        ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("PackageFindView",
                new PackageFindViewModel(_servicePackage, _serviceIndustry, _serviceState, _servicePackageDataFields));
        }

        #region Private Methods

        private static CustomQuery<Package> GenerateExpression(PackageFindViewModel model)
        {
            Expression<Func<Package, bool>> expression = null;

            if (model.Package.Id.HasValue)
                expression = expression.And(d => d.Id == model.Package.Id.Value);
            if (!string.IsNullOrEmpty(model.Package.Description))
                expression = expression.And(d => d.Description.Contains(model.Package.Description));
            if (!string.IsNullOrEmpty(model.Package.Name))
                expression = expression.And(d => d.Name.Contains(model.Package.Name));
            if (!string.IsNullOrEmpty(model.Package.Owner))
                expression = expression.And(d => d.Owner.Contains(model.Package.Owner));
            if (model.Package.StateId.HasValue)
                expression = expression.And(d => d.StateId == model.Package.StateId.Value);
            if (!string.IsNullOrEmpty(model.Package.Version))
                expression = expression.And(d => d.Version.Contains(model.Package.Version));
            if (model.Package.CostOfSale.HasValue)
                expression = expression.And(d => d.CostOfSale == model.Package.CostOfSale.Value);
            if (model.Package.Created.HasValue)
                expression = expression.And(d => d.Created == model.Package.Created.Value);
            if (model.Package.Edited.HasValue)
                expression = expression.And(d => d.Edited == model.Package.Edited.Value);
            if (model.Package.IndustryId.HasValue)
                expression = expression.And(d => d.IndustryId == model.Package.IndustryId.Value);
            if (model.Package.Published.HasValue)
                expression = expression.And(d => d.Published == model.Package.Published.Value);
            if (model.Package.RecomendedRetailPrice.HasValue)
                expression = expression.And(d => d.RecomendedRetailPrice == model.Package.RecomendedRetailPrice.Value);
            if (model.Package.RevisionDate.HasValue)
                expression = expression.And(d => d.RevisionDate == model.Package.RevisionDate.Value);

            return new CustomQuery<Package>(expression ?? (d => true));
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
                _servicePackage.Dispose();
                _serviceIndustry.Dispose();
                _serviceState.Dispose();
                _servicePackageDataFields.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}