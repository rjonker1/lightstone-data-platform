using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Users;

namespace UserManagement.Domain.CommandHandlers.Users
{
    public class CreateUserHandler : AbstractMessageHandler<CreateUser>
    {

        private static ISession Session;

        public CreateUserHandler(ISession _session)
        {
            Session = _session;
        }

        public override void Handle(CreateUser command)
        {


            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    var entity = new User(command.FirstCreateDate, command.LastUpdateBy, command.LastUpdateDate,
                    command.Password, command.UserName, command.UserTypeId, command.IsActive);

                    Session.Save(entity);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}