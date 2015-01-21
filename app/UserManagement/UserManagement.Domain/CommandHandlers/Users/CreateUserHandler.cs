﻿using System;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.UserProfiles;
using UserManagement.Domain.Entities.Commands.Users;

namespace UserManagement.Domain.CommandHandlers.Users
{
    public class CreateUserHandler : AbstractMessageHandler<CreateUser>
    {

        private readonly IRepository<User> _repository;
        private readonly IHandleMessages _handler;

        public CreateUserHandler(IHandleMessages handler, IRepository<User> repository)
        {
            _handler = handler;
            _repository = repository;
        }

        public override void Handle(CreateUser command)
        {

            var newUser = new User(command.Id, command.FirstCreateDate, command.LastUpdateBy, command.LastUpdateDate,
                command.Password, command.UserName, command.IsActive, command.ClientUser,
                command.UserType,
                command.Roles);

            _repository.Save(newUser);

            _handler.Handle(new CreateUserProfile(command.ContactNumber, command.UserName, command.IdNumber, command.Surname, newUser));
        }
    }
}