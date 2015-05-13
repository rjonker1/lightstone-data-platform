using Nancy;

namespace Lim.Web.UI.Modules
{
    public class IntegrationForApiModule : NancyModule
    {
        public IntegrationForApiModule()
        {
            Get["/integrations/for/api/push"] = _ => View["integrations/api/push"];

            Get["/integrations/for/api/pull"] = _ => View["integrations/api/pull"];

            Get["/integrations/for/api/configurations"] = _ => View["integrations/api/configurations"];
        }
    }
}