using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping;
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
        private readonly IRepository<Client> _clientRepo;
        private readonly IRepository<ClientUser> _clientUserRepo;
        private readonly IHandleMessages _handler;

        public CreateUserHandler(IRepository<Client> clientRepo, IRepository<ClientUser> clientUserRepo, IHandleMessages handler, IRepository<User> repository)
        {
            _clientRepo = clientRepo;
            _clientUserRepo = clientUserRepo;
            _handler = handler;
            _repository = repository;
        }

        public override void Handle(CreateUser command)
        {

            var clientId = new Guid();
            var clientName = "";


            for (int i = 0; i < command.ClientObject.Count; i++)
            {
                clientId = (command.ClientObject[i].Id);
                clientName = (command.ClientObject[i].ClientName);
            }

            var client = new Client(clientId, clientName);

            var newUser = new User(command.Id, command.FirstCreateDate, command.LastUpdateBy, command.LastUpdateDate,
                command.Password, command.UserName, command.IsActive,
                //command.Clients,
                command.UserType,
                command.Customers,
                command.Roles);


            _repository.Save(newUser);

            var clientUser = new ClientUser("Alias", client, newUser);
            _clientUserRepo.Save(clientUser);

            _handler.Handle(new CreateUserProfile(command.ContactNumber, command.UserName, command.IdNumber, command.Surname, newUser));
        }
    }
}