using Nancy;
using Nancy.Bootstrappers.Windsor;

namespace Cradle.KeepAlive.Service
{
    public class NancyBootstrapper : WindsorNancyBootstrapper
    {
        // RootPathProvider required for overriding Shared RootPathProvider that gets automatically injected from assembly by Nancy
        protected override IRootPathProvider RootPathProvider
        {
            get { return new DefaultRootPathProvider(); }
        }
    }
}