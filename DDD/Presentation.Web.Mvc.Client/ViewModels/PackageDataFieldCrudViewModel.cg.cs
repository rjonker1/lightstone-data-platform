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
    public partial class PackageDataFieldCrudViewModel
    {
        #region Fields

        private readonly IDataFieldAppService _serviceDataField;
        private readonly IPackageAppService _servicePackage;
        private readonly IPackageDataFieldAppService _servicePackageDataField;

        #endregion

        #region Properties

        public PackageDataField PackageDataField { get; set; }
        public List<SelectListItem> DataFields { get; set; }
        public List<SelectListItem> Packages { get; set; }

        #endregion

        #region Constructor

        public PackageDataFieldCrudViewModel()
        {
            PackageDataField = new PackageDataField();
        }

        /// <summary>
        ///     Create a new instance of PackageDataField viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataField">Service dependency</param>
        /// <param name="servicePackage">Service dependency</param>
        public PackageDataFieldCrudViewModel(IPackageDataFieldAppService service, IDataFieldAppService serviceDataField,
            IPackageAppService servicePackage) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceDataField == null)
                throw new ArgumentNullException("serviceDataField", PresentationResources.exception_WithoutService);
            if (servicePackage == null)
                throw new ArgumentNullException("servicePackage", PresentationResources.exception_WithoutService);

            _servicePackageDataField = service;
            _serviceDataField = serviceDataField;
            _servicePackage = servicePackage;

            BuildVm();
        }

        #endregion
    }
}