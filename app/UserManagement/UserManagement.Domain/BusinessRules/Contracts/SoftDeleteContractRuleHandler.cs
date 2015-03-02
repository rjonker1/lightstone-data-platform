using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.BusinessRules.Contracts;

namespace UserManagement.Domain.BusinessRules.Contracts
{
    public class SoftDeleteContractRuleHandler : AbstractMessageHandler<SoftDeleteContractRule>
    {

        public override void Handle(SoftDeleteContractRule command)
        {
            throw new System.NotImplementedException();
        }
    }
}