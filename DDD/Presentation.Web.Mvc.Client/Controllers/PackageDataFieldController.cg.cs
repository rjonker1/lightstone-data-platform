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
    public class PackageDataFieldController : ControllerBase
    {
        #region Fields

        private readonly IDataFieldAppService _serviceDataField;
        private readonly IPackageAppService _servicePackage;
        private readonly IPackageDataFieldAppService _servicePackageDataField;

        #endregion

        #region Constructor

        /// <summary>
        ///     Create a new instance of PackageDataField controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataField">Service dependency</param>
        /// <param name="servicePackage">Service dependency</param>
        public PackageDataFieldController(IPackageDataFieldAppService service, IDataFieldAppService serviceDataField,
            IPackageAppService servicePackage)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceDataField == null)
                throw new ArgumentNullException("serviceDataField", PresentationResources.exception_WithoutService);
            if (servicePackage == null)
                throw new ArgumentNullException("servicePackage", PresentationResources.exception_WithoutService);

            _servicePackageDataField = service;
            _serviceDataField = serviceDataField;
            _servicePackage = servicePackage;
        }

        #endregion

        // GET
        public ActionResult Add()
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - AddPackageDataField Controller Begin"));

            try
            {
                // Add add logic here
                var model = new PackageDataFieldCrudViewModel(_servicePackageDataField, _serviceDataField,
                    _servicePackage);

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - AddPackageDataField Controller End"));
                return View("PackageDataFieldAddView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - AddPackageDataField Controller ERROR"), ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PackageDataFieldCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - AddPackageDataField Controller Begin"));

            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    bool committed = _servicePackageDataField.Add(model.PackageDataField, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - AddPackageDataField Controller End"));
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - AddPackageDataField Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("PackageDataFieldAddView",
                new PackageDataFieldCrudViewModel(_servicePackageDataField, _serviceDataField, _servicePackage));
        }

        // GET
        public ActionResult Modify(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - ModifyPackageDataField Controller Begin"));

            try
            {
                // Add modify logic here
                var model = new PackageDataFieldCrudViewModel(_servicePackageDataField, _serviceDataField,
                    _servicePackage)
                {
                    PackageDataField = _servicePackageDataField.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - ModifyPackageDataField Controller End"));
                return View("PackageDataFieldModifyView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - ModifyPackageDataField Controller ERROR"), ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(PackageDataFieldCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - ModifyPackageDataField Controller Begin"));

            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    bool committed = _servicePackageDataField.Modify(model.PackageDataField, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - ModifyPackageDataField Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - ModifyPackageDataField Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("PackageDataFieldModifyView",
                new PackageDataFieldCrudViewModel(_servicePackageDataField, _serviceDataField, _servicePackage));
        }

        // GET
        public ActionResult Remove(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - RemovePackageDataField Controller Begin"));

            try
            {
                // Add remove logic here
                var model = new PackageDataFieldCrudViewModel(_servicePackageDataField, _serviceDataField,
                    _servicePackage)
                {
                    PackageDataField = _servicePackageDataField.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - RemovePackageDataField Controller End"));
                return View("PackageDataFieldRemoveView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemovePackageDataField Controller ERROR"), ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(PackageDataFieldCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - RemovePackageDataField Controller Begin"));

            try
            {
                // Add remove logic here
                bool committed = _servicePackageDataField.Remove(model.PackageDataField, null);
                if (committed)
                {
                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemovePackageDataField Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemovePackageDataField Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("PackageDataFieldRemoveView",
                new PackageDataFieldCrudViewModel(_servicePackageDataField, _serviceDataField, _servicePackage));
        }

        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - FindPackageDataField Controller Begin"));

            try
            {
                // Add find logic here
                PackageDataFieldFindViewModel model;

                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterPackageDataField"))
                {
                    model = (PackageDataFieldFindViewModel) TempData.Peek("FilterPackageDataField");
                    PagedCollection<PackageDataField> pagedResult =
                        _servicePackageDataField.FindPagedByFilter(
                            new CustomQuery<PackageDataField> {SerializedExpression = model.Filter}, null,
                            page != null ? (int) page : model.PageIndex, model.PageSize, new List<string> {sort},
                            sortDir == "ASC", null);
                    model.Paginate(pagedResult, model.Filter);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindPagedPackageDataField Controller End"));
                    return PartialView("_PackageDataFieldFindPartialView", model);
                }
                TempData.Remove("FilterPackageDataField");
                model = new PackageDataFieldFindViewModel(_servicePackageDataField, _serviceDataField, _servicePackage);
                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - FindPackageDataField Controller End"));
                return View("PackageDataFieldFindView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindPackageDataField Controller ERROR"), ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(PackageDataFieldFindViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - FindPackageDataField Controller Begin"));

            try
            {
                // Add find logic here
                if (ModelState.IsValid)
                {
                    CustomQuery<PackageDataField> expression = GenerateExpression(model);
                    var includes = new List<string>();
                    PagedCollection<PackageDataField> pagedResult =
                        _servicePackageDataField.FindPagedByFilter(expression, includes, 1, model.PageSize,
                            model.OrderBy, model.Ascendent, null);
                    model.Paginate(pagedResult, expression.SerializedExpression);

                    TempData.Clear();
                    TempData.Add("FilterPackageDataField", model);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindPackageDataField Controller End"));
                    return PartialView("_PackageDataFieldFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindPackageDataField Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("PackageDataFieldFindView",
                new PackageDataFieldFindViewModel(_servicePackageDataField, _serviceDataField, _servicePackage));
        }

        #region Private Methods

        private static CustomQuery<PackageDataField> GenerateExpression(PackageDataFieldFindViewModel model)
        {
            Expression<Func<PackageDataField, bool>> expression = null;

            if (model.PackageDataField.Id.HasValue)
                expression = expression.And(d => d.Id == model.PackageDataField.Id.Value);
            if (model.PackageDataField.DataFieldId.HasValue)
                expression = expression.And(d => d.DataFieldId == model.PackageDataField.DataFieldId.Value);
            if (model.PackageDataField.PackageId.HasValue)
                expression = expression.And(d => d.PackageId == model.PackageDataField.PackageId.Value);
            if (model.PackageDataField.Priority.HasValue)
                expression = expression.And(d => d.Priority == model.PackageDataField.Priority.Value);
            if (model.PackageDataField.Selected.HasValue)
                expression = expression.And(d => d.Selected == model.PackageDataField.Selected.Value);
            if (!string.IsNullOrEmpty(model.PackageDataField.UnifiedName))
                expression = expression.And(d => d.UnifiedName.Contains(model.PackageDataField.UnifiedName));

            return new CustomQuery<PackageDataField>(expression ?? (d => true));
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
                _servicePackageDataField.Dispose();
                _serviceDataField.Dispose();
                _servicePackage.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}