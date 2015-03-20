using System.Collections;
using Billing.Domain.Core.Repositories;
using Billing.Domain.Entities;
using Billing.Domain.Entities.DemoEntities;
using Nancy;
using Nancy.Responses.Negotiation;

namespace Billing.Api.Modules
{
    public class MIModule : NancyModule
    {
        public MIModule(IRepository<Customer> customers, IRepository<Product> products)
        {
            Get["/MI"] = _ =>
            {
                return Negotiate
                   .WithView("Index")
                   .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = products });
            };
        }
    }
}