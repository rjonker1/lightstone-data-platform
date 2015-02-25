using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Clients;

namespace UserManagement.Domain.BusinessRules.Clients
{
    public class SoftDeleteClientRuleHandler : AbstractMessageHandler<SoftDeleteClientRule>
    {

        private readonly IRepository<ClientUser> _clientUsers;

        public SoftDeleteClientRuleHandler(IRepository<ClientUser> clientUsers)
        {
            _clientUsers = clientUsers;
        }

        public override void Handle(SoftDeleteClientRule command)
        {

            var entity = command.Entity;
            var hasClientUser = _clientUsers.Where(x => x.Client.Id.Equals(entity.Id));

            if (hasClientUser.Any())
            {
                var exception = new LightstoneAutoException("Client cannot be deleted due to Client - User relationship".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }

            command.Entity.IsDeleted = true;
        }
    }
}