using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Roles;

namespace UserManagement.Domain.BusinessRules.Roles
{
    public class CreateRoleRuleHandler : AbstractMessageHandler<CreateRoleRule>
    {
        private readonly IValueEntityRepository<Role> _roles;

        public CreateRoleRuleHandler(IValueEntityRepository<Role> roles)
        {
            _roles = roles;
        }

        public override void Handle(CreateRoleRule command)
        {
            var entity = command.Role;

            //Check if Username for specific user already exists
            if (_roles.Exists(entity.Id, entity.Value))
            {
                //var exception = new LightstoneAutoException("Role already exists".FormatWith(entity.GetType().Name));
                //this.Warn(() => exception);
                //throw exception;
            }
        }
    }
}