using System;
using System.Collections;
using System.Linq;
using Billing.Domain.Core.Repositories;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Responses.Negotiation;

namespace Billing.Api.Modules
{
    public class MIModule : NancyModule
    {
        public MIModule()//IRepository<Customer> customers, IRepository<Product> products, IRepository<User> users)
        {
            //Get["/MI"] = _ =>
            //{
                //var result = new Hashtable();
                //var totalCoS = 0.0;
                //var totalRev = 0.0;

                //foreach (var product in products)
                //{
                //    totalCoS += product.CoS;
                //    totalRev += product.Revenue;
                //}

                //result.Add("totalCoS", totalCoS);
                //result.Add("totalRevenue", totalRev);

                //var test = new ArrayList {result};

                //return Negotiate
                //   .WithView("Index")
                //   .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = test });
            //};

            //Get["/MI/Metrics"] = _ =>
            //{
                //var results = new Hashtable();

                //var lastMonthBillingEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 26);
                //var monthBillingEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);


                ////var totalCustomers = customers.Select(x => x.Transactions
                ////    .Where(t => t.Created != null && (t.Created.Value >= lastMonthBillingEnd && 
                ////                                      t.Created.Value <= monthBillingEnd))).Count();

                //var totalCustomers = customers.Count();
                //var totalUsers = users.Count();
                //var totalProducts = products.Count();

                //results.Add("totalCustomers", totalCustomers);
                //results.Add("totalUsers", totalUsers);
                //results.Add("totalProducts", totalProducts);

                //return Response.AsJson(results);
            //};
        }
    }
}