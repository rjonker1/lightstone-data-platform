using System;
using System.Linq;
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
                var customerAcc = customers.FirstOrDefault(x => x.Id == searchId);
                var clientAcc = clients.FirstOrDefault(x => x.Id == searchId);

                var accountNumber = "DEFAULT";
                if (customerAcc != null) accountNumber = customerAcc.CustomerAccountNumber.ToString();
                if (clientAcc != null) accountNumber = clientAcc.ClientAccountNumber.ToString();

                return accountNumber;
            };
        }
    }
}