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
    public class DataProviderController : ControllerBase
    {
        #region Fields

        private readonly IDataFieldAppService _serviceDataFields;
        private readonly IDataProviderAppService _serviceDataProvider;
        private readonly IStateAppService _serviceState;

        #endregion

        #region Constructor

        /// <summary>
        ///     Create a new instance of DataProvider controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataFields">Service dependency</param>
        /// <param name="serviceState">Service dependency</param>
        public DataProviderController(IDataProviderAppService service, IDataFieldAppService serviceDataFields,
            IStateAppService serviceState)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceDataFields == null)
                throw new ArgumentNullException("serviceDataFields", PresentationResources.exception_WithoutService);
            if (serviceState == null)
                throw new ArgumentNullException("serviceState", PresentationResources.exception_WithoutService);

            _serviceDataProvider = service;
            _serviceDataFields = serviceDataFields;
            _serviceState = serviceState;
        }

        #endregion

        // GET
        public ActionResult Add()
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - AddDataProvider Controller Begin"));

            try
            {
                // Add add logic here
                var model = new DataProviderCrudViewModel(_serviceDataProvider, _serviceDataFields, _serviceState);

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - AddDataProvider Controller End"));
                return View("DataProviderAddView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - AddDataProvider Controller ERROR"), ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DataProviderCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - AddDataProvider Controller Begin"));

            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    bool committed = _serviceDataProvider.Add(model.DataProvider, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - AddDataProvider Controller End"));
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - AddDataProvider Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("DataProviderAddView",
                new DataProviderCrudViewModel(_serviceDataProvider, _serviceDataFields, _serviceState));
        }

        // GET
        public ActionResult Modify(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - ModifyDataProvider Controller Begin"));

            try
            {
                // Add modify logic here
                var model = new DataProviderCrudViewModel(_serviceDataProvider, _serviceDataFields, _serviceState)
                {
                    DataProvider = _serviceDataProvider.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - ModifyDataProvider Controller End"));
                return View("DataProviderModifyView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - ModifyDataProvider Controller ERROR"), ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(DataProviderCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - ModifyDataProvider Controller Begin"));

            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    bool committed = _serviceDataProvider.Modify(model.DataProvider, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - ModifyDataProvider Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - ModifyDataProvider Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("DataProviderModifyView",
                new DataProviderCrudViewModel(_serviceDataProvider, _serviceDataFields, _serviceState));
        }

        // GET
        public ActionResult Remove(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - RemoveDataProvider Controller Begin"));

            try
            {
                // Add remove logic here
                var model = new DataProviderCrudViewModel(_serviceDataProvider, _serviceDataFields, _serviceState)
                {
                    DataProvider = _serviceDataProvider.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - RemoveDataProvider Controller End"));
                return View("DataProviderRemoveView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemoveDataProvider Controller ERROR"), ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(DataProviderCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - RemoveDataProvider Controller Begin"));

            try
            {
                // Add remove logic here
                bool committed = _serviceDataProvider.Remove(model.DataProvider, null);
                if (committed)
                {
                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemoveDataProvider Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemoveDataProvider Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("DataProviderRemoveView",
                new DataProviderCrudViewModel(_serviceDataProvider, _serviceDataFields, _serviceState));
        }

        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - FindDataProvider Controller Begin"));

            try
            {
                // Add find logic here
                DataProviderFindViewModel model;

                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterDataProvider"))
                {
                    model = (DataProviderFindViewModel) TempData.Peek("FilterDataProvider");
                    PagedCollection<DataProvider> pagedResult =
                        _serviceDataProvider.FindPagedByFilter(
                            new CustomQuery<DataProvider> {SerializedExpression = model.Filter}, null,
                            page != null ? (int) page : model.PageIndex, model.PageSize, new List<string> {sort},
                            sortDir == "ASC", null);
                    model.Paginate(pagedResult, model.Filter);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindPagedDataProvider Controller End"));
                    return PartialView("_DataProviderFindPartialView", model);
                }
                TempData.Remove("FilterDataProvider");
                model = new DataProviderFindViewModel(_serviceDataProvider, _serviceDataFields, _serviceState);
                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture,
                        "Presentation Layer - FindDataProvider Controller End"));
                return View("DataProviderFindView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindDataProvider Controller ERROR"), ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(DataProviderFindViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture,
                    "Presentation Layer - FindDataProvider Controller Begin"));

            try
            {
                // Add find logic here
                if (ModelState.IsValid)
                {
                    CustomQuery<DataProvider> expression = GenerateExpression(model);
                    var includes = new List<string>();
                    PagedCollection<DataProvider> pagedResult = _serviceDataProvider.FindPagedByFilter(expression,
                        includes, 1, model.PageSize, model.OrderBy, model.Ascendent, null);
                    model.Paginate(pagedResult, expression.SerializedExpression);

                    TempData.Clear();
                    TempData.Add("FilterDataProvider", model);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindDataProvider Controller End"));
                    return PartialView("_DataProviderFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindDataProvider Controller ERROR"), ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("DataProviderFindView",
                new DataProviderFindViewModel(_serviceDataProvider, _serviceDataFields, _serviceState));
        }

        #region Private Methods

        private static CustomQuery<DataProvider> GenerateExpression(DataProviderFindViewModel model)
        {
            Expression<Func<DataProvider, bool>> expression = null;

            if (model.DataProvider.Id.HasValue)
                expression = expression.And(d => d.Id == model.DataProvider.Id.Value);
            if (!string.IsNullOrEmpty(model.DataProvider.Name))
                expression = expression.And(d => d.Name.Contains(model.DataProvider.Name));
            if (model.DataProvider.OverrideFieldLevelCostOfSale.HasValue)
                expression =
                    expression.And(
                        d => d.OverrideFieldLevelCostOfSale == model.DataProvider.OverrideFieldLevelCostOfSale.Value);
            if (!string.IsNullOrEmpty(model.DataProvider.Owner))
                expression = expression.And(d => d.Owner.Contains(model.DataProvider.Owner));
            if (!string.IsNullOrEmpty(model.DataProvider.SourceURL))
                expression = expression.And(d => d.SourceURL.Contains(model.DataProvider.SourceURL));
            if (model.DataProvider.StateId.HasValue)
                expression = expression.And(d => d.StateId == model.DataProvider.StateId.Value);
            if (!string.IsNullOrEmpty(model.DataProvider.Version))
                expression = expression.And(d => d.Version.Contains(model.DataProvider.Version));
            if (model.DataProvider.CostOfSale.HasValue)
                expression = expression.And(d => d.CostOfSale == model.DataProvider.CostOfSale.Value);
            if (model.DataProvider.Created.HasValue)
                expression = expression.And(d => d.Created == model.DataProvider.Created.Value);
            if (!string.IsNullOrEmpty(model.DataProvider.Description))
                expression = expression.And(d => d.Description.Contains(model.DataProvider.Description));
            if (model.DataProvider.Edited.HasValue)
                expression = expression.And(d => d.Edited == model.DataProvider.Edited.Value);
            if (model.DataProvider.RevisionDate.HasValue)
                expression = expression.And(d => d.RevisionDate == model.DataProvider.RevisionDate.Value);

            return new CustomQuery<DataProvider>(expression ?? (d => true));
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
                _serviceDataProvider.Dispose();
                _serviceDataFields.Dispose();
                _serviceState.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}