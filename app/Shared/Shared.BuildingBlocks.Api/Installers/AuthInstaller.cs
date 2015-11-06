using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Nancy.Authentication.Token;
using Nancy.Authentication.Token.Storage;
using Shared.BuildingBlocks.Api.Security;
using Tokenizer = Shared.BuildingBlocks.Api.Security.Tokenizer;

namespace Shared.BuildingBlocks.Api.Installers
{
    public class AuthInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITokenizer>().UsingFactoryMethod(() => new Tokenizer(cfg => cfg.AdditionalItems().WithKeyCache(new FileSystemTokenKeyStore(new RootPathProvider())))).LifestylePerWebRequest());
        }
    }
}