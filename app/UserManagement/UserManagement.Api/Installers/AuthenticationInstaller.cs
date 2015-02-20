﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Api.Helpers.Security;

namespace UserManagement.Api.Installers
{
    public class AuthenticationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserAuthenticationClient>().ImplementedBy<UserAuthenticatorClient>().LifestyleTransient());
            container.Register(Component.For<IUmAuthenticator>().ImplementedBy<UmAuthenticator>().LifestyleTransient());
            container.Register(Component.For<IAuthenticateUser>().ImplementedBy<RedisAuthenticator>().LifestyleTransient());
        }
    }
}