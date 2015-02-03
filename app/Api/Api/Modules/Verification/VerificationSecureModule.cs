using Nancy;
using Nancy.Security;

namespace Api.Modules.Verification
{
    public class VerificationSecureModule : NancyModule
    {
        public VerificationSecureModule()
            : base("/api/verification")
        {
            this.RequiresAuthentication();
        }
    }
}