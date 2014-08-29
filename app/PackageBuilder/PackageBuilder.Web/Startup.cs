using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PackageBuilder.Web.Startup))]
namespace PackageBuilder.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
