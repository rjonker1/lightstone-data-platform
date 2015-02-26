using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Users;

namespace UserManagement.Domain.BusinessRules.Users
{
    public class SoftDeleteUserRuleHandler : AbstractMessageHandler<SoftDeleteUserRule>
    {

        private readonly IRepository<ClientUser> _clientUsers;

        public SoftDeleteUserRuleHandler(IRepository<ClientUser> clientUsers)
        {
            _clientUsers = clientUsers;
        }

        public override void Handle(SoftDeleteUserRule command)
        {

            var entity = command.Entity;
            var hasClientUser = _clientUsers.Where(x => x.User.Id.Equals(entity.Id));

            if (hasClientUser.Any())
            {
                var exception = new LightstoneAutoException("User cannot be deleted due to Client - User relationship".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }

            entity.IsDeleted = true;
        }
    }
}