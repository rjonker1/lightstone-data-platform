using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LightstoneApp.Application.PackageBuilderModule.AppServices;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Presentation.Web.Mvc.Client.Models;
using LightstoneApp.Presentation.Web.Mvc.Client.Resources;

namespace LightstoneApp.Presentation.Web.Mvc.Client.ViewModels
{
    public partial class DataProviderFindViewModel : ViewModelBase<DataProvider>
    {
        #region Fields

        private readonly IDataFieldAppService _serviceDataFields;
        private readonly IDataProviderAppService _serviceDataProvider;
        private readonly IStateAppService _serviceState;

        #endregion

        #region Properties

        public DataProviderFindModel DataProvider { get; set; }
        public List<SelectListItem> States { get; set; }

        #endregion

        #region Constructor

        public DataProviderFindViewModel()
        {
            DataProvider = new DataProviderFindModel();
        }

        /// <summary>
        ///     Create a new instance of DataProvider viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataFields">Service dependency</param>
        /// <param name="serviceState">Service dependency</param>
        public DataProviderFindViewModel(IDataProviderAppService service, IDataFieldAppService serviceDataFields,
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