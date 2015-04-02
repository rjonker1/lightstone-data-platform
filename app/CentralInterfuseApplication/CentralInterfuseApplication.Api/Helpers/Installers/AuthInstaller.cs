using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Authentication.Token.Storage;

namespace CentralInterfuseApplication.Api.Helpers.Installers
{
    public class AuthInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<ITokenizer>().ImplementedBy<Tokenizer>().LifestyleTransient());
            container.Register(Component.For<ITokenizer>().Instance(new Tokenizer(cfg => cfg.AdditionalItems(ctx => ctx.Request.Headers.UserAgent = "1").WithKeyCache(new FileSystemTokenKeyStore(new RootPathProvider())))));
        }
    }

    public class RootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return new Uri(@"D:\").LocalPath;
        }
    }
}