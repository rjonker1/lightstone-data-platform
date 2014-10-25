using System;
using LightstoneApp.Application.PackageBuilderModule.AppServices;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Presentation.Web.Mvc.Client.Models;
using LightstoneApp.Presentation.Web.Mvc.Client.Resources;

namespace LightstoneApp.Presentation.Web.Mvc.Client.ViewModels
{
    public partial class StateFindViewModel : ViewModelBase<State>
    {
        #region Fields

        private readonly IDataProviderAppService _serviceDataProviders;
        private readonly IPackageAppService _servicePackages;
        private readonly IStateAppService _serviceState;

        #endregion

        #region Properties

        public StateFindModel State { get; set; }

        #endregion

        #region Constructor

        public StateFindViewModel()
        {
            State = new StateFindModel();
        }

        /// <summary>
        ///     Create a new instance of State viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDataProviders">Service dependency</param>
        /// <param name="servicePackages">Service dependency</param>
        public StateFindViewModel(IStateAppService service, IDataProviderAppService serviceDataProviders,
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