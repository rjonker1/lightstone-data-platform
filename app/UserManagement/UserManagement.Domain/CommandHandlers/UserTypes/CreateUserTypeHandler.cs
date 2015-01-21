using System;
using NHibernate;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Users;
using UserManagement.Domain.Entities.Commands.UserTypes;

namespace UserManagement.Domain.CommandHandlers.UserTypes
{
    public class CreateUserTypeHandler : AbstractMessageHandler<CreateUserType>
    {

        private readonly INamedEntityRepository<UserType> _repository;

        public CreateUserTypeHandler(INamedEntityRepository<UserType> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateUserType command)
        {

            if (_repository.Exists(command.Id, command.Name)) return;

            _repository.Save(new UserType(command.Id, command.Name));
        }

    }
}