using Nancy;
using Nancy.Security;

namespace Shared.BuildingBlocks.Api.Security
{
    public class SecureModule : NancyModule
    {
        public SecureModule()
        {
            this.RequiresAuthentication();
        }
    }
}