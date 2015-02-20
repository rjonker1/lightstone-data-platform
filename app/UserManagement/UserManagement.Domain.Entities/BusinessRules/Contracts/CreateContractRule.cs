using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Contracts
{
    public class CreateContractRule : DomainCommand
    {
        public Contract Entity;

        public CreateContractRule(Contract client)
        {
            Entity = client;
        }
    }
}