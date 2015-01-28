using System;
using NHibernate;
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
        private readonly IRepository<ClientUser> _clientUserRepo;
        private readonly IHandleMessages _handler;

        public CreateUserHandler(ISession session, IHandleMessages handler, IRepository<ClientUser> clientUserRepo, IRepository<User> repository)
        {
            _session = session;
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


            //Need to commit the new user before the Client|User relationship can be established
            _repository.Save(newUser);
            _session.Transaction.Commit();

            //Start new transactional session in order subsequent commits to be commited
            _session.BeginTransaction();
            _clientUserRepo.Save(new ClientUser(client, newUser, command.UserName));

            _handler.Handle(new CreateUserProfile(command.ContactNumber, command.UserName, command.IdNumber, command.Surname, newUser));
        }
    }
}