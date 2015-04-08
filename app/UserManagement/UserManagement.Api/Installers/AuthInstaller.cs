using System;
using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Authentication.Token.Storage;

namespace UserManagement.Api.Installers
{
    public class AuthInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var userAgent = ConfigurationManager.AppSettings["TokenAuthUserAgentValue"];
            container.Register(Component.For<ITokenizer>().Instance(new Tokenizer(cfg => cfg.AdditionalItems(ctx => ctx.Request.Headers.UserAgent = userAgent).WithKeyCache(new FileSystemTokenKeyStore(new RootPathProvider())))).LifestyleTransient());
        }
    }

    public class RootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            var keyStore = ConfigurationManager.AppSettings["TokenAuthKeyStorePath"];
            return new Uri(keyStore).LocalPath;
        }

        //public string GetRootPath()
        //{
        //    var assemblyFilePath = new Uri(typeof(RootPathProvider).Assembly.CodeBase).LocalPath;

        //    var assemblyPath = Path.GetDirectoryName(assemblyFilePath);

        //    return GetParent(assemblyPath, 2);
        //}

        //public string GetParent(string path, int levels)
        //{
        //    if (string.IsNullOrEmpty(path))
        //        throw new ArgumentException("path cannot be null or empty", "path");

        //    if (levels < 0)
        //        throw new ArgumentException("levels cannot be negative", "levels");

        //    if (levels == 0)
        //        return path;

        //    var parts = path.Split(Path.DirectorySeparatorChar);

        //    if (parts.Length <= levels)
        //        throw new InvalidOperationException("Cannot go up beyond the root.");

        //    return parts.Take(parts.Length - levels).Aggregate((p1, p2) => String.Format("{0}{1}{2}", p1, Path.DirectorySeparatorChar, p2));
        //}
    }
}