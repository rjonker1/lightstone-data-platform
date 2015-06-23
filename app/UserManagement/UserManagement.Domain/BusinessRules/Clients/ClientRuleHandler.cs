using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.BusinessRules.Clients
{
    public class ClientRuleHandler : AbstractMessageHandler<Client>
    {
        private readonly IRepository<Contract> _contractRepository;

        public ClientRuleHandler(IRepository<Contract> contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public override void Handle(Client command)
        {
            var contractsLinkedToCustomers = _contractRepository.Where(x => command.Contracts.Contains(x) && x.Clients.Any()).SelectMany(x => x.Customers);
            if (contractsLinkedToCustomers.Any())
                throw new LightstoneAutoException("The following customers/s are already linked to the contracts to be saved: {0}".FormatWith(string.Join(", ", contractsLinkedToCustomers.Select(x => x.Name))));
        }
    }
}