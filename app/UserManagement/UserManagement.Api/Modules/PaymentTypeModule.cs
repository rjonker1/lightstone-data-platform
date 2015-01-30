using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class PaymentTypeModule : NancyModule
    {
        public PaymentTypeModule(IRepository<PaymentType> paymentTypes)
        {

            Get["/PaymentTypes"] = _ => Response.AsJson(paymentTypes);
        }
    }
}