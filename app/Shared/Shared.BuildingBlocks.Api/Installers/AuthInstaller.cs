using System;
using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Enums;
using Nancy.Authentication.Token;
using Nancy.Authentication.Token.Storage;
using Shared.BuildingBlocks.Api.Security;

namespace Shared.BuildingBlocks.Api.Installers
{
    public class AuthInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var systemName = SystemName.Api;
            var systemNameSetting = ConfigurationManager.AppSettings["tokenizer/logging/systemName/enum"];
            if (!string.IsNullOrEmpty(systemNameSetting))
                Enum.TryParse(systemNameSetting, out systemName);
            container.Register(Component.For<ITokenizer>().UsingFactoryMethod(() => new DataPlatformTokenizer(cfg => cfg.WithKeyCache(new FileSystemTokenKeyStore(new RootPathProvider())), systemName)).LifestylePerWebRequest());
        }
    }
}