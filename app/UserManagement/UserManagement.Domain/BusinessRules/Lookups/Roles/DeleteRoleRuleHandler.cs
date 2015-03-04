using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Lookups.Roles;

namespace UserManagement.Domain.BusinessRules.Lookups.Roles
{
    public class DeleteRoleRuleHandler : AbstractMessageHandler<DeleteRoleRule>
    {

        private readonly IRepository<UserRole> _userRoleListings;

        public DeleteRoleRuleHandler(IRepository<UserRole> userRoleListings)
        {
            _userRoleListings = userRoleListings;
        }

        public override void Handle(DeleteRoleRule command)
        {
            var entity = command.Entity;
            var roles = _userRoleListings.Select(x => x).Where(x => x.Role.Id.Equals(entity.Id));

            if (roles.Any())
            {
                var exception = new LightstoneAutoException("Role is associated therefore cannot be deleted".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}