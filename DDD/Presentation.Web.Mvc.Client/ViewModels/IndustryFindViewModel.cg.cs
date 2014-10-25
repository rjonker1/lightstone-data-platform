using System;
using LightstoneApp.Application.PackageBuilderModule.AppServices;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Presentation.Web.Mvc.Client.Models;
using LightstoneApp.Presentation.Web.Mvc.Client.Resources;

namespace LightstoneApp.Presentation.Web.Mvc.Client.ViewModels
{
    public partial class IndustryFindViewModel : ViewModelBase<Industry>
    {
        #region Fields

        private readonly IDataFieldAppService _serviceDataFields;
        private readonly IIndustryAppService _serviceIndustry;
        private readonly IPackageAppService _servicePackages;

        #endregion

        #region Properties

        public IndustryFindModel Industry { get; set; }

        #endregion

        #region Constructor

        public IndustryFindViewModel()
        {
            Industry = new IndustryFindModel();
        }

        /// <summary>
        ///     Create a new instance of Industry viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataFields">Service dependency</param>
        /// <param name="servicePackages">Service dependency</param>
        public IndustryFindViewModel(IIndustryAppService service, IDataFieldAppService serviceDataFields,
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