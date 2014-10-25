#region

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LightstoneApp.Application.PackageBuilderModule.AppServices;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Presentation.Web.Mvc.Client.Resources;

#endregion

namespace LightstoneApp.Presentation.Web.Mvc.Client.ViewModels
{
    public partial class DataProviderCrudViewModel
    {
        #region Fields

        private readonly IDataFieldAppService _serviceDataFields;
        private readonly IDataProviderAppService _serviceDataProvider;
        private readonly IStateAppService _serviceState;

        #endregion

        #region Properties

        public DataProvider DataProvider { get; set; }
        public List<SelectListItem> States { get; set; }

        #endregion

        #region Constructor

        public DataProviderCrudViewModel()
        {
            DataProvider = new DataProvider();
        }

        /// <summary>
        ///     Create a new instance of DataProvider viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataFields">Service dependency</param>
        /// <param name="serviceState">Service dependency</param>
        public DataProviderCrudViewModel(IDataProviderAppService service, IDataFieldAppService serviceDataFields,
            IStateAppService serviceState) : this()
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

            BuildVm();
        }

        #endregion
    }
}