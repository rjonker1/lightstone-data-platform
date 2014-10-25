#region

using System;
using LightstoneApp.Application.PackageBuilderModule.AppServices;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Presentation.Web.Mvc.Client.Resources;

#endregion

namespace LightstoneApp.Presentation.Web.Mvc.Client.ViewModels
{
    public partial class IndustryCrudViewModel
    {
        #region Fields

        private readonly IDataFieldAppService _serviceDataFields;
        private readonly IIndustryAppService _serviceIndustry;
        private readonly IPackageAppService _servicePackages;

        #endregion

        #region Properties

        public Industry Industry { get; set; }

        #endregion

        #region Constructor

        public IndustryCrudViewModel()
        {
            Industry = new Industry();
        }

        /// <summary>
        ///     Create a new instance of Industry viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataFields">Service dependency</param>
        /// <param name="servicePackages">Service dependency</param>
        public IndustryCrudViewModel(IIndustryAppService service, IDataFieldAppService serviceDataFields,
            IPackageAppService servicePackages) : this()
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

            BuildVm();
        }

        #endregion
    }
}