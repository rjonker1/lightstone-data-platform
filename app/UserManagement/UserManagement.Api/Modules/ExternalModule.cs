using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy;
using Shared.Logging;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class ExternalModule : NancyModule
    {
        public ExternalModule(ICustomerRepository customers, IClientRepository clients)
        {
            Get["/CustomerClient/{id}"] = param =>
            {
                Guid paramId;
                Guid.TryParse(param.id, out paramId);
                var searchId = paramId;

                this.Info(() => "Searching for Customer | Client {0}".FormatWith(searchId), SystemName.UserManagement);

                var customerAcc = customers.FirstOrDefault(x => x.Id == searchId);
                var clientAcc = clients.FirstOrDefault(x => x.Id == searchId);

                var accountNumber = "DEFAULT";
                if (customerAcc != null)
                {
                    accountNumber = customerAcc.CustomerAccountNumber.ToString();
                    this.Info(() => "Found Customer {0}".FormatWith(searchId), SystemName.UserManagement);
                }
                if (clientAcc != null)
                {
                    accountNumber = clientAcc.ClientAccountNumber.ToString();
                    this.Info(() => "Found Client {0}".FormatWith(searchId), SystemName.UserManagement);
                }

                if (accountNumber.Equals("DEFAULT"))
                    throw new LightstoneAutoException("Customer | Client could not be found: {0}".FormatWith(searchId));

                return accountNumber;
            };

           
        }
    }
}