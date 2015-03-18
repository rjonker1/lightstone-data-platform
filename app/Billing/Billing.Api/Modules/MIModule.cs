using System.Collections;
using Billing.Domain.Entities;
using Nancy;
using Nancy.Responses.Negotiation;

namespace Billing.Api.Modules
{
    public class MIModule : NancyModule
    {
        public MIModule()
        {
            Get["/MI"] = _ =>
            {
                var dto = new ArrayList
                {
                    new PreBilling()
                };
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new {data = dto});
            };
        }
    }
}