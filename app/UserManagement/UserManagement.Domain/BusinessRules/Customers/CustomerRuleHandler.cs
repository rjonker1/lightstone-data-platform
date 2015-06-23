using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.BusinessRules.Customers
{
    public class CustomerRuleHandler : AbstractMessageHandler<Customer>
    {
        private readonly IRepository<Contract> _contractRepository;

        public CustomerRuleHandler(IRepository<Contract> contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public override void Handle(Customer command)
        {
            var contractsLinkedToClients = _contractRepository.Where(x => command.Contracts.Contains(x) && x.Clients.Any()).SelectMany(x => x.Clients);
            if (contractsLinkedToClients.Any())
                throw new LightstoneAutoException("The following client/s are already linked to the contracts to be saved: {0}".FormatWith(string.Join(", ", contractsLinkedToClients.Select(x => x.Name))));
        }
    }
}