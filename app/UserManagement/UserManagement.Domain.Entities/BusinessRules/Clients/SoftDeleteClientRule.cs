using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Clients
{
    public class SoftDeleteClientRule : DomainCommand
    {

        public Client Entity;

        public SoftDeleteClientRule(Client entity)
        {
            Entity = entity;
        }
    }
}