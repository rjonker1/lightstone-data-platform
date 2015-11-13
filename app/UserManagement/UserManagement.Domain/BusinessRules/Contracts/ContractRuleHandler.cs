using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.BusinessRules.Contracts
{
    public class ContractRuleHandler : AbstractMessageHandler<Contract>
    {
        public override void Handle(Contract command)
        {
            if (command.Clients.Any() && command.Customers.Any())
                throw new LightstoneAutoException("Cannot associate this contract to both client/s and customer/s");
        }
    }
}