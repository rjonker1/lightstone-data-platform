using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LightstoneApp.Application.PackageBuilderModule.AppServices;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Presentation.Web.Mvc.Client.Models;
using LightstoneApp.Presentation.Web.Mvc.Client.Resources;

namespace LightstoneApp.Presentation.Web.Mvc.Client.ViewModels
{
    public partial class DataFieldFindViewModel : ViewModelBase<DataField>
    {
        #region Fields

        private readonly IDataFieldAppService _serviceDataField;
        private readonly IDataProviderAppService _serviceDataProvider;
        private readonly IIndustryAppService _serviceIndustry;
        private readonly IPackageDataFieldAppService _servicePackageDataFields;

        #endregion

        #region Properties

        public DataFieldFindModel DataField { get; set; }
        public List<SelectListItem> DataProviders { get; set; }
        public List<SelectListItem> Industrys { get; set; }

        #endregion

        #region Constructor

        public DataFieldFindViewModel()
        {
            DataField = new DataFieldFindModel();
        }

        /// <summary>
        ///     Create a new instance of DataField viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataProvider">Service dependency</param>
        /// <param name="serviceIndustry">Service dependency</param>
        /// <param name="servicePackageDataFields">Service dependency</param>
        public DataFieldFindViewModel(IDataFieldAppService service, IDataProviderAppService serviceDataProvider,
            IIndustryAppService serviceIndustry, IPackageDataFieldAppService servicePackageDataFields) : this()
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

            BuildVm();
        }

        #endregion
    }
}