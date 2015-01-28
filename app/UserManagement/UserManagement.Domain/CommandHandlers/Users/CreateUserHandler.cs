using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using NHibernate;
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
        private readonly ISession _session;
        private readonly IRepository<Client> _clientRepo;
        private readonly IRepository<ClientUser> _clientUserRepo;
        private readonly IHandleMessages _handler;

        public CreateUserHandler(ISession session, IRepository<Client> clientRepo, IRepository<ClientUser> clientUserRepo, IHandleMessages handler, IRepository<User> repository)
        {
            _session = session;
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
            _session.Transaction.Commit();

            _session.BeginTransaction();
            _clientUserRepo.Save(new ClientUser("Alias", client, newUser));

            _handler.Handle(new CreateUserProfile(command.ContactNumber, command.UserName, command.IdNumber, command.Surname, newUser));
        }
    }
}