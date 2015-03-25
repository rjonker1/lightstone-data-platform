﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using Shared.BuildingBlocks.Api.ApiClients;

namespace CentralInterfuseApplication.Api.Helpers.Installers
{
    public class ApiClientInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install ApiClientInstaller");
            container.Register(Component.For<IUserManagementApiClient>().ImplementedBy<UserManagementApiClient>().LifestyleTransient());
            container.Register(Component.For<IPackageBuilderApiClient>().ImplementedBy<PackageBuilderApiClient>().LifestyleTransient());
            this.Info(() => "Successfully installed ApiClientInstaller");
        }
    }
}