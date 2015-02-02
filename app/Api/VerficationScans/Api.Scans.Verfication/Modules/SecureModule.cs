using Nancy;
using Nancy.Security;

namespace Api.Scans.Verfication.Modules
{
    public class SecureModule : NancyModule
    {
        public SecureModule()
            : base("/api/verification")
        {
            this.RequiresAuthentication();
        }
    }
}