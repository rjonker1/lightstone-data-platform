using System.Web.Mvc;

namespace LightstoneApp.Presentation.Web.Mvc.Client
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}