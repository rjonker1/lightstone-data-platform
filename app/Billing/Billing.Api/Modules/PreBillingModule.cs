using System;
using System.Collections.Generic;
using System.Linq;
using Billing.Api.ViewModels;
using Billing.Domain.Entities;
using Billing.Infrastructure.Repositories;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;

namespace Billing.Api.Modules
{
    public class PreBillingModule : NancyModule
    {
        public PreBillingModule(IPreBillingRepository preBilling)
        {

            Get["/PreBilling"] = _ =>
            {
                var model = this.Bind<DataTablesViewModel>();
                //var dto = new PreBillingDto();
                var dto = (IEnumerable<PreBilling>)(preBilling.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
                //dto = new[] {new PreBillingDto()};
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = new[] { new PreBillingDto() }.ToList() });
            };

            Post["/PreBilling"] = _ =>
            {
                var model = this.Bind<DataTablesViewModel>();
                //var dto = new PreBillingDto();
                var dto = (IEnumerable<PreBilling>)(preBilling.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
                //dto = new[] {new PreBillingDto()};
                return Response.AsJson( new { data = new[] { new PreBillingDto() }.ToList() });
            };

        }
    }

    class PreBillingDto
    {
        public Guid Id = new Guid();
        public string CustomerName = "Test";
        public int NumUsers = 0;
        public string Type = "";
        public string Owner = "Testeroonie";
        public int NumProducts = 0;
        public int NumTransactions = 0;
        public string UserType = "New";
        public int Total = 0;
    }
}