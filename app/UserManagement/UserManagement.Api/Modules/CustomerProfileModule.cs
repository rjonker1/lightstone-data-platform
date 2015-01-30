using System;
using System.Linq;
using MemBus;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.CustomerProfiles;

namespace UserManagement.Api.Modules
{
    public class CustomerProfileModule : NancyModule
    {
        public CustomerProfileModule(IBus bus, IRepository<CustomerProfile> customerProfiles, IRepository<CommercialState> commercialStates, IRepository<Billing> billings, IRepository<CreateSource> createSources, 
                                        IRepository<Customer> customers, IRepository<PlatformStatus> platformStatuses)
        {

            Get["/CustomerProfiles"] = _ => Response.AsJson(customerProfiles);

            Get["/CustomerProfiles/Create"] = _ =>
            {

                var commercialState = commercialStates.Select(x => x).FirstOrDefault(x => x.Name == "Billable");
                var billing = billings.Select(x => x).FirstOrDefault(x => x.CompanyRegistration == "Company Reg");
                var createSource = createSources.Select(x => x).FirstOrDefault(x => x.Name == "Web Signup");
                var customer = customers.Select(x => x).FirstOrDefault(x => x.CustomerName == "Testeroonie Inc. Global");
                var platformStatus = platformStatuses.Select(x => x).FirstOrDefault(x => x.Name == "ACTIVATED");

                bus.Publish(new CreateCustomerProfile("1234", DateTime.Now, "Test User", DateTime.Now, commercialState,
                                                        billing, createSource, customer, platformStatus));

                return "Success";
            };
        }
    }
}