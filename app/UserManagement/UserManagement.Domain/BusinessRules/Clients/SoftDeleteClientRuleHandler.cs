using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Clients;

namespace UserManagement.Domain.BusinessRules.Clients
{
    public class SoftDeleteClientRuleHandler : AbstractMessageHandler<SoftDeleteClientRule>
    {

        private readonly INamedEntityRepository<Client> _currentClients;

        public override void Handle(SoftDeleteClientRule command)
        {
            throw new System.NotImplementedException();
        }
    }
}