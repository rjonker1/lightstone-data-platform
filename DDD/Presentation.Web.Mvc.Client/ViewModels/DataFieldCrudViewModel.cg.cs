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
    public partial class DataFieldCrudViewModel
    {
        #region Fields

        private readonly IDataFieldAppService _serviceDataField;
        private readonly IDataProviderAppService _serviceDataProvider;
        private readonly IIndustryAppService _serviceIndustry;
        private readonly IPackageDataFieldAppService _servicePackageDataFields;

        #endregion

        #region Properties

        public DataField DataField { get; set; }
        public List<SelectListItem> DataProviders { get; set; }
        public List<SelectListItem> Industrys { get; set; }

        #endregion

        #region Constructor

        public DataFieldCrudViewModel()
        {
            DataField = new DataField();
        }

        /// <summary>
        ///     Create a new instance of DataField viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataProvider">Service dependency</param>
        /// <param name="serviceIndustry">Service dependency</param>
        /// <param name="servicePackageDataFields">Service dependency</param>
        public DataFieldCrudViewModel(IDataFieldAppService service, IDataProviderAppService serviceDataProvider,
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