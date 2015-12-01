using System.Linq;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Shared.Logging;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Lookups.Roles;
using UserManagement.Infrastructure.Repositories;

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
            var roles = _userRoleListings.Where(x => x.Role != null && x.Role.Id.Equals(entity.Id)).ToList();

            if (roles.Any())
            {
                var exception = new LightstoneAutoException("Role is associated therefore cannot be deleted".FormatWith(entity.GetType().Name));
                this.Warn(() => exception, SystemName.UserManagement);
                throw exception;
            }
        }
    }
}