using System;
using System.Linq;
using MemBus;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Billings;

namespace UserManagement.Api.Modules
{
    public class BillingModule : NancyModule
    {
        public BillingModule(IBus bus, IRepository<Billing> billings, IRepository<PaymentType> paymentTypes)
        {

            Get["/Billings"] = _ => Response.AsJson(billings);

            Get["/Billings/Create"] = _ =>
            {

                var paymentType = paymentTypes.Select(x => x).FirstOrDefault(x => x.Name == "Debit Order");

                bus.Publish(new CreateBilling("Contact number", "Contact person", "Company Reg", DateTime.Now, DateTime.Now, paymentType));

                return "Success";
            };
        }
    }
}