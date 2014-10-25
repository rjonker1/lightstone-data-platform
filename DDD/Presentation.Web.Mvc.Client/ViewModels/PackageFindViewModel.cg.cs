using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LightstoneApp.Application.PackageBuilderModule.AppServices;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Presentation.Web.Mvc.Client.Models;
using LightstoneApp.Presentation.Web.Mvc.Client.Resources;

namespace LightstoneApp.Presentation.Web.Mvc.Client.ViewModels
{
    public partial class PackageFindViewModel : ViewModelBase<Package>
    {
        #region Fields

        private readonly IIndustryAppService _serviceIndustry;
        private readonly IPackageAppService _servicePackage;
        private readonly IPackageDataFieldAppService _servicePackageDataFields;
        private readonly IStateAppService _serviceState;

        #endregion

        #region Properties

        public PackageFindModel Package { get; set; }
        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> Industrys { get; set; }

        #endregion

        #region Constructor

        public PackageFindViewModel()
        {
            Package = new PackageFindModel();
        }

        /// <summary>
        ///     Create a new instance of Package view-model
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceIndustry">Service dependency</param>
        /// <param name="serviceState">Service dependency</param>
        /// <param name="servicePackageDataFields">Service dependency</param>
        public PackageFindViewModel(IPackageAppService service, IIndustryAppService serviceIndustry,
            IStateAppService serviceState, IPackageDataFieldAppService servicePackageDataFields) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceIndustry == null)
                throw new ArgumentNullException("serviceIndustry", PresentationResources.exception_WithoutService);
            if (serviceState == null)
                throw new ArgumentNullException("serviceState", PresentationResources.exception_WithoutService);
            if (servicePackageDataFields == null)
                throw new ArgumentNullException("servicePackageDataFields",
                    PresentationResources.exception_WithoutService);

            _servicePackage = service;
            _serviceIndustry = serviceIndustry;
            _serviceState = serviceState;
            _servicePackageDataFields = servicePackageDataFields;

            BuildVm();
        }

        #endregion
    }
}