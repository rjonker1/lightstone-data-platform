using Shared.BuildingBlocks.Api.Security;

namespace UserManagement.Api.Modules
{
    public class IndexModule : SecureModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["Index"];
            };

            Get["/Home"] = parameters =>
            {
                return View["Home"];
            };
        }
    }
}