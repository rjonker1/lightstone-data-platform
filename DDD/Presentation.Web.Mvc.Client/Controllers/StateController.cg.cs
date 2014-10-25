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
    public class StateController : ControllerBase
    {
        #region Fields

        private readonly IDataProviderAppService _serviceDataProviders;
        private readonly IPackageAppService _servicePackages;
        private readonly IStateAppService _serviceState;

        #endregion

        #region Constructor

        /// <summary>
        ///     Create a new instance of State controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataProviders">Service dependency</param>
        /// <param name="servicePackages">Service dependency</param>
        public StateController(IStateAppService service, IDataProviderAppService serviceDataProviders,
            IPackageAppService servicePackages)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceDataProviders == null)
                throw new ArgumentNullException("serviceDataProviders", PresentationResources.exception_WithoutService);
            if (servicePackages == null)
                throw new ArgumentNullException("servicePackages", PresentationResources.exception_WithoutService);

            _serviceState = service;
            _serviceDataProviders = serviceDataProviders;
            _servicePackages = servicePackages;
        }

        #endregion

        // GET
        public ActionResult Add()
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddState Controller Begin"));

            try
            {
                // Add add logic here
                var model = new StateCrudViewModel(_serviceState, _serviceDataProviders, _servicePackages);

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddState Controller End"));
                return View("StateAddView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddState Controller ERROR"),
                        ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(StateCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddState Controller Begin"));

            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    bool committed = _serviceState.Add(model.State, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - AddState Controller End"));
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddState Controller ERROR"),
                        ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("StateAddView", new StateCrudViewModel(_serviceState, _serviceDataProviders, _servicePackages));
        }

        // GET
        public ActionResult Modify(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyState Controller Begin"));

            try
            {
                // Add modify logic here
                var model = new StateCrudViewModel(_serviceState, _serviceDataProviders, _servicePackages)
                {
                    State = _serviceState.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyState Controller End"));
                return View("StateModifyView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyState Controller ERROR"),
                        ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(StateCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyState Controller Begin"));

            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    bool committed = _serviceState.Modify(model.State, null);
                    if (committed)
                    {
                        LoggerFactory.CreateLog()
                            .Debug(string.Format(CultureInfo.InvariantCulture,
                                "Presentation Layer - ModifyState Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyState Controller ERROR"),
                        ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("StateModifyView",
                new StateCrudViewModel(_serviceState, _serviceDataProviders, _servicePackages));
        }

        // GET
        public ActionResult Remove(int id)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveState Controller Begin"));

            try
            {
                // Add remove logic here
                var model = new StateCrudViewModel(_serviceState, _serviceDataProviders, _servicePackages)
                {
                    State = _serviceState.Get(new List<object> {id}, null)
                };

                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveState Controller End"));
                return View("StateRemoveView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveState Controller ERROR"),
                        ex);
            }

            return RedirectToAction("Find");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(StateCrudViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveState Controller Begin"));

            try
            {
                // Add remove logic here
                bool committed = _serviceState.Remove(model.State, null);
                if (committed)
                {
                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - RemoveState Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveState Controller ERROR"),
                        ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("StateRemoveView",
                new StateCrudViewModel(_serviceState, _serviceDataProviders, _servicePackages));
        }

        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindState Controller Begin"));

            try
            {
                // Add find logic here
                StateFindViewModel model;

                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterState"))
                {
                    model = (StateFindViewModel) TempData.Peek("FilterState");
                    PagedCollection<State> pagedResult =
                        _serviceState.FindPagedByFilter(new CustomQuery<State> {SerializedExpression = model.Filter},
                            null, page != null ? (int) page : model.PageIndex, model.PageSize, new List<string> {sort},
                            sortDir == "ASC", null);
                    model.Paginate(pagedResult, model.Filter);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindPagedState Controller End"));
                    return PartialView("_StateFindPartialView", model);
                }
                TempData.Remove("FilterState");
                model = new StateFindViewModel(_serviceState, _serviceDataProviders, _servicePackages);
                LoggerFactory.CreateLog()
                    .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindState Controller End"));
                return View("StateFindView", model);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindState Controller ERROR"),
                        ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(StateFindViewModel model)
        {
            LoggerFactory.CreateLog()
                .Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindState Controller Begin"));

            try
            {
                // Add find logic here
                if (ModelState.IsValid)
                {
                    CustomQuery<State> expression = GenerateExpression(model);
                    var includes = new List<string>();
                    PagedCollection<State> pagedResult = _serviceState.FindPagedByFilter(expression, includes, 1,
                        model.PageSize, model.OrderBy, model.Ascendent, null);
                    model.Paginate(pagedResult, expression.SerializedExpression);

                    TempData.Clear();
                    TempData.Add("FilterState", model);

                    LoggerFactory.CreateLog()
                        .Debug(string.Format(CultureInfo.InvariantCulture,
                            "Presentation Layer - FindState Controller End"));
                    return PartialView("_StateFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog()
                    .Error(
                        string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindState Controller ERROR"),
                        ex);
            }

            ModelState.AddModelError("", PresentationResources.Error);
            return View("StateFindView", new StateFindViewModel(_serviceState, _serviceDataProviders, _servicePackages));
        }

        #region Private Methods

        private static CustomQuery<State> GenerateExpression(StateFindViewModel model)
        {
            Expression<Func<State, bool>> expression = null;

            if (model.State.Id.HasValue)
                expression = expression.And(d => d.Id == model.State.Id.Value);
            if (!string.IsNullOrEmpty(model.State.Value))
                expression = expression.And(d => d.Value.Contains(model.State.Value));

            return new CustomQuery<State>(expression ?? (d => true));
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
                _serviceState.Dispose();
                _serviceDataProviders.Dispose();
                _servicePackages.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}