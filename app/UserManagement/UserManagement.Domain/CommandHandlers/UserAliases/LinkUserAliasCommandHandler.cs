using System;
using System.Linq;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.UserAliases;

namespace UserManagement.Domain.CommandHandlers.UserAliases
{
    public class LinkUserAliasCommandHandler : AbstractMessageHandler<LinkUserAliasCommand>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<CustomerUser> _customerUserRepository;
        private readonly IRepository<ClientUserAlias> _userAliasRepository;

        public LinkUserAliasCommandHandler(IRepository<User> userRepository, IRepository<ClientUserAlias> userAliasRepository, IRepository<CustomerUser> customerUserRepository)
        {
            _userRepository = userRepository;
            _userAliasRepository = userAliasRepository;
            _customerUserRepository = customerUserRepository;
        }

        public override void Handle(LinkUserAliasCommand command)
        {
            var alias = _userAliasRepository.Get(command.AliasId);
            alias.User = _userRepository.Get(command.UserId);

            var customerUser = _customerUserRepository.FirstOrDefault(x => x.Customer.Id == command.CustomerId && x.User.Id == command.UserId);
            if (customerUser != null) customerUser.IsDefault = true;
        }
    }
}
