#region

using System;
using LightstoneApp.Application.PackageBuilderModule.AppServices;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Presentation.Web.Mvc.Client.Resources;

#endregion

namespace LightstoneApp.Presentation.Web.Mvc.Client.ViewModels
{
    public partial class StateCrudViewModel
    {
        #region Fields

        private readonly IDataProviderAppService _serviceDataProviders;
        private readonly IPackageAppService _servicePackages;
        private readonly IStateAppService _serviceState;

        #endregion

        #region Properties

        public State State { get; set; }

        #endregion

        #region Constructor

        public StateCrudViewModel()
        {
            State = new State();
        }

        /// <summary>
        ///     Create a new instance of State viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataProviders">Service dependency</param>
        /// <param name="servicePackages">Service dependency</param>
        public StateCrudViewModel(IStateAppService service, IDataProviderAppService serviceDataProviders,
            IPackageAppService servicePackages) : this()
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

            BuildVm();
        }

        #endregion
    }
}