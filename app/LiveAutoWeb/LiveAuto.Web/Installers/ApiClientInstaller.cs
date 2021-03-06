﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Shared.BuildingBlocks.Api.ApiClients;

namespace LiveAuto.Web.Installers
{
    public class ApiClientInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserManagementApiClient>().ImplementedBy<UserManagementApiClient>().LifestyleTransient());
        }
    }
}