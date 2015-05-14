using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Clients;

namespace UserManagement.Domain.BusinessRules.Clients
{
    public class CreateClientRuleHandler : AbstractMessageHandler<CreateClientRule>
    {
        private readonly INamedEntityRepository<Client> _currentClients;

        public CreateClientRuleHandler(INamedEntityRepository<Client> currentClients)
        {
            _currentClients = currentClients;
        }

        public override void Handle(CreateClientRule command)
        {
            var entity = command.Entity;

            //Check if Client already exists
            if (_currentClients.Exists(entity.Id, entity.Name))
            {
                var exception = new LightstoneAutoException("Client already exists".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}