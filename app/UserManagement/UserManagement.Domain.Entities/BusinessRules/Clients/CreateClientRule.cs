using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Clients
{
    public class CreateClientRule : DomainCommand
    {
        public Client Entity;

        public CreateClientRule(Client client)
        {
            Entity = client;
        }
    }
}