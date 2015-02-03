using Nancy;
using Nancy.Security;

namespace Api.Modules.Verification
{
    public class VerificationSecureModule : NancyModule
    {
        public VerificationSecureModule()
            : base("/api/verification")
        {
            //TODO: Enable once user management API is working
            //this.RequiresAuthentication();
        }
    }
}