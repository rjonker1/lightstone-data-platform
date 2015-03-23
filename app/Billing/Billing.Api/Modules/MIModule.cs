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
                var result = new Hashtable();
                var totalCoS = 0.0;
                var totalRev = 0.0;

                foreach (var product in products)
                {
                    totalCoS += product.CoS;
                    totalRev += product.Revenue;
                }

                result.Add("totalCoS", totalCoS);
                result.Add("totalRevenue", totalRev);

                var test = new ArrayList {result};

                return Negotiate
                   .WithView("Index")
                   .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = test });
            };
        }
    }
}