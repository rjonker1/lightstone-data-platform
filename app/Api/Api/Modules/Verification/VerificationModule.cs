using Nancy;
using Nancy.Security;

namespace Api.Modules.Verification
{
    public class VerificationModule : NancyModule
    {
        public VerificationModule()
            : base("/api/verification")
        {
            this.RequiresAuthentication();
        }
    }
}