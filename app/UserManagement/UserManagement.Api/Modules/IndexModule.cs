using Nancy;

namespace UserManagement.Api.Modules
{
    public class IndexModule : NancyModule
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