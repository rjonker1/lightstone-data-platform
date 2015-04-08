using System;
using Nancy;
using Nancy.Extensions;
using Nancy.Security;

namespace CentralInterfuseApplication.Api.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters =>
            {
                try
                {
                    this.RequiresAuthentication();
                }
                catch (Exception)
                {
                    if (Context.IsAjaxRequest())
                        return View["Auth/Login"];
                      
                    return Response.AsRedirect("/login");
                }

                return Context.IsAjaxRequest() ? View["Home"] : View["Index"];
            };
        }
    }
}