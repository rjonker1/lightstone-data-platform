using Nancy;
using Nancy.Security;

namespace Shared.BuildingBlocks.Api
{
    public class SecureModule : NancyModule
    {
        public SecureModule()
        {
            //this.RequiresAuthentication();
        }
    }
}