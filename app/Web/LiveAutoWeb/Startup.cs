using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LiveAutoWeb.Startup))]
namespace LiveAutoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
