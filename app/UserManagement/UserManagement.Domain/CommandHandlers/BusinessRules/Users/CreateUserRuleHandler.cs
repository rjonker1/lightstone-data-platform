using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Users;

namespace UserManagement.Domain.CommandHandlers.BusinessRules.Users
{
    public class CreateUserRuleHandler : AbstractMessageHandler<CreateUserRule>
    {
        private readonly IRepository<User> _currentUsers;

        public CreateUserRuleHandler(IRepository<User> currentUsers)
        {
            _currentUsers = currentUsers;
        }

        public override void Handle(CreateUserRule command)
        {

            var entity = command.Entity;

            //Check if Username for specific user already exists
            foreach (var user in _currentUsers)
            {
                if (user.UserName.Equals(entity.UserName))
                {
                    var exception = new LightstoneAutoException("Username already exists".FormatWith(entity.GetType().Name));
                    this.Warn(() => exception);
                    throw exception;
                }
            }
        }
    }
}