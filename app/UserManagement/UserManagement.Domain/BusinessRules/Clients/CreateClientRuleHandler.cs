using System.Linq;
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

        private readonly IRepository<Client> _currentClients;

        public CreateClientRuleHandler(IRepository<Client> currentClients)
        {
            _currentClients = currentClients;
        }

        public override void Handle(CreateClientRule command)
        {
            var entity = command.Entity;

            //Check if Username for specific user already exists
            if (Enumerable.Any(_currentClients, client => client.Name.Equals(entity.Name)))
            {
                var exception = new LightstoneAutoException("Client already exists".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}