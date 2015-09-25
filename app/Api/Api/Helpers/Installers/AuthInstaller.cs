using System;
using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Authentication.Token.Storage;

namespace Api.Helpers.Installers
{
    public class AuthInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var userAgent = ConfigurationManager.AppSettings["TokenAuthUserAgentValue"];
            container.Register(Component.For<ITokenizer>().Instance(new Tokenizer(cfg => cfg.AdditionalItems(ctx => ctx.Request.Headers.UserAgent = userAgent).WithKeyCache(new FileSystemTokenKeyStore(new RootPathProvider())))).LifestyleSingleton());
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