using System;
using NHibernate;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Users;
using UserManagement.Domain.Entities.Commands.UserTypes;

namespace UserManagement.Domain.CommandHandlers.UserTypes
{
    public class CreateUserTypeHandler : AbstractMessageHandler<CreateUserType>
    {
        private static ISession Session;

        public CreateUserTypeHandler(ISession _session)
        {
            Session = _session;
        }

        public override void Handle(CreateUserType command)
        {


            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    var entity = new UserType(command.Value);

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