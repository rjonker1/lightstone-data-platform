using System;
using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Authentication.Token.Storage;

namespace PackageBuilder.Api.Installers
{
    public class AuthInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var userAgent = ConfigurationManager.AppSettings["TokenAuthUserAgentValue"];
            var tokenizer = new Tokenizer(cfg => cfg.AdditionalItems(ctx => ctx.Request.Headers.UserAgent = userAgent).WithKeyCache(new FileSystemTokenKeyStore(new RootPathProvider())));
            container.Register(Component.For<ITokenizer>().Instance(tokenizer).LifestyleSingleton());
        }
    }

    public class RootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            var keyStore = ConfigurationManager.AppSettings["TokenAuthKeyStorePath"];
            return new Uri(keyStore).LocalPath;
        }
    }
}