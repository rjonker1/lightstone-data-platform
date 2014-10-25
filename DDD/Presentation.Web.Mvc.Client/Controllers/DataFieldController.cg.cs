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
    public class DataFieldController : ControllerBase
    {
        #region Fields

        private readonly IDataFieldAppService _serviceDataField;
        private readonly IDataProviderAppService _serviceDataProvider;
        private readonly IIndustryAppService _serviceIndustry;
        private readonly IPackageDataFieldAppService _servicePackageDataFields;

        #endregion

        #region Constructor

        /// <summary>
        ///     Create a new instance of DataField controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataProvider">Service dependency</param>
        /// <param name="serviceIndustry">Service dependency</param>
        /// <param name="servicePackageDataFields">Service dependency</param>
        public DataFieldController(IDataFieldAppService service, IDataProviderAppService serviceDataProvider,
            IIndustryAppService serviceIndustry, IPackageDataFieldAppService servicePackageDataFields)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceDataProvider == null)
                throw new ArgumentNullException("serviceDataProvider", PresentationResources.exception_WithoutService);
            if (serviceIndustry == null)
                throw new ArgumentNullException("serviceIndustry", PresentationResources.exception_WithoutService);
            if (servicePackageDataFields == null)
                throw new ArgumentNullException("servicePackageDataFields",
                    PresentationResources.exception_WithoutService);

            _serviceDataField = service;
            _serviceDataProvider = serviceDataProvider;
            _serviceIndustry = serviceIndustry;
            _servicePackageDataFields = servicePackageDataFields;
        }

        #endregion

        // GET
        public ActionResult Add()
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDataField Controller Begin"));

            try
            {
                // Add add logic here
                var model = new DataFieldCrudViewModel(_serviceDataField, _serviceDataProvider, _serviceIndustry,
                    _servicePackageDataFields);

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - AddDataField Controller End"));
                return View("DataFieldAddView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDataField Controller ERROR"),
                        ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DataFieldCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDataField Controller Begin"));

            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    bool committed = _serviceDataField.Add(model.DataField, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - AddDataField Controller End"));
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDataField Controller ERROR"),
                        ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("DataFieldAddView",
                new DataFieldCrudViewModel(_serviceDataField, _serviceDataProvider, _serviceIndustry,
                    _servicePackageDataFields));
        }

        // GET
        public ActionResult Modify(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - ModifyDataField Controller Begin"));

            try
            {
                // Add modify logic here
                var model = new DataFieldCrudViewModel(_serviceDataField, _serviceDataProvider, _serviceIndustry,
                    _servicePackageDataFields)
                {
                    DataField = _serviceDataField.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - ModifyDataField Controller End"));
                return View("DataFieldModifyView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - ModifyDataField Controller ERROR"), ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(DataFieldCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - ModifyDataField Controller Begin"));

            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    bool committed = _serviceDataField.Modify(model.DataField, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - ModifyDataField Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - ModifyDataField Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("DataFieldModifyView",
                new DataFieldCrudViewModel(_serviceDataField, _serviceDataProvider, _serviceIndustry,
                    _servicePackageDataFields));
        }

        // GET
        public ActionResult Remove(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - RemoveDataField Controller Begin"));

            try
            {
                // Add remove logic here
                var model = new DataFieldCrudViewModel(_serviceDataField, _serviceDataProvider, _serviceIndustry,
                    _servicePackageDataFields)
                {
                    DataField = _serviceDataField.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - RemoveDataField Controller End"));
                return View("DataFieldRemoveView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemoveDataField Controller ERROR"), ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(DataFieldCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - RemoveDataField Controller Begin"));

            try
            {
                // Add remove logic here
                bool committed = _serviceDataField.Remove(model.DataField, null);
                if (committed)
                {
                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemoveDataField Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemoveDataField Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("DataFieldRemoveView",
                new DataFieldCrudViewModel(_serviceDataField, _serviceDataProvider, _serviceIndustry,
                    _servicePackageDataFields));
        }

        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDataField Controller Begin"));

            try
            {
                // Add find logic here
                DataFieldFindViewModel model;

                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterDataField"))
                {
                    model = (DataFieldFindViewModel) TempData.Peek("FilterDataField");
                    PagedCollection<DataField> pagedResult =
                        _serviceDataField.FindPagedByFilter(
                            new CustomQuery<DataField> {SerializedExpression = model.Filter}, null,
                            page != null ? (int) page : model.PageIndex, model.PageSize, new List<string> {sort},
                            sortDir == "ASC", null);
                    model.Paginate(pagedResult, model.Filter);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindPagedDataField Controller End"));
                    return PartialView("_DataFieldFindPartialView", model);
                }
                TempData.Remove("FilterDataField");
                model = new DataFieldFindViewModel(_serviceDataField, _serviceDataProvider, _serviceIndustry,
                    _servicePackageDataFields);
                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - FindDataField Controller End"));
                return View("DataFieldFindView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindDataField Controller ERROR"), ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(DataFieldFindViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDataField Controller Begin"));

            try
            {
                // Add find logic here
                if (ModelState.IsValid)
                {
                    CustomQuery<DataField> expression = GenerateExpression(model);
                    var includes = new List<string>();
                    PagedCollection<DataField> pagedResult = _serviceDataField.FindPagedByFilter(expression, includes, 1,
                        model.PageSize, model.OrderBy, model.Ascendent, null);
                    model.Paginate(pagedResult, expression.SerializedExpression);

                    TempData.Clear();
                    TempData.Add("FilterDataField", model);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindDataField Controller End"));
                    return PartialView("_DataFieldFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindDataField Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("DataFieldFindView",
                new DataFieldFindViewModel(_serviceDataField, _serviceDataProvider, _serviceIndustry,
                    _servicePackageDataFields));
        }

        #region Private Methods

        private static CustomQuery<DataField> GenerateExpression(DataFieldFindViewModel model)
        {
            Expression<Func<DataField, bool>> expression = null;

            if (model.DataField.Id.HasValue)
                expression = expression.And(d => d.Id == model.DataField.Id.Value);
            if (model.DataField.CostOfSale.HasValue)
                expression = expression.And(d => d.CostOfSale == model.DataField.CostOfSale.Value);
            if (model.DataField.DataProviderId.HasValue)
                expression = expression.And(d => d.DataProviderId == model.DataField.DataProviderId.Value);
            if (model.DataField.IndustryId.HasValue)
                expression = expression.And(d => d.IndustryId == model.DataField.IndustryId.Value);
            if (!string.IsNullOrEmpty(model.DataField.Name))
                expression = expression.And(d => d.Name.Contains(model.DataField.Name));
            if (model.DataField.Selected.HasValue)
                expression = expression.And(d => d.Selected == model.DataField.Selected.Value);
            if (!string.IsNullOrEmpty(model.DataField.Label))
                expression = expression.And(d => d.Label.Contains(model.DataField.Label));
            if (!string.IsNullOrEmpty(model.DataField.TypeDefinition))
                expression = expression.And(d => d.TypeDefinition.Contains(model.DataField.TypeDefinition));

            return new CustomQuery<DataField>(expression ?? (d => true));
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
                _serviceDataField.Dispose();
                _serviceDataProvider.Dispose();
                _serviceIndustry.Dispose();
                _servicePackageDataFields.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}