using System;
using System.Linq;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class ExternalModule : NancyModule
    {
        public ExternalModule(ICustomerRepository customers, IClientRepository clients)
        {
            Get["/CustomerClient/{id}"] = param =>
            {
                var searchId = new Guid(param.id);
                this.Info(() => "Searching for Customer | Client {0}".FormatWith(searchId));
                
                var customerAcc = customers.FirstOrDefault(x => x.Id == searchId);
                var clientAcc = clients.FirstOrDefault(x => x.Id == searchId);

                var accountNumber = "DEFAULT";
                if (customerAcc != null) { accountNumber = customerAcc.CustomerAccountNumber.ToString(); this.Info(() => "Found Customer {0}".FormatWith(searchId)); }
                if (clientAcc != null) { accountNumber = clientAcc.ClientAccountNumber.ToString(); this.Info(() => "Found Client {0}".FormatWith(searchId)); }

                return accountNumber;
            };
        }
    }
}