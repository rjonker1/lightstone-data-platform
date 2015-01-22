using System;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Roles;
using UserManagement.Domain.Entities.Commands.UserTypes;

namespace UserManagement.Domain.CommandHandlers.Roles
{
    public class ImportRoleHandler : AbstractMessageHandler<ImportRole>
    {

        private readonly IHandleMessages _handler;

        public ImportRoleHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportRole command)
        {
            try
            {
                _handler.Handle(new CreateRole("Owner"));
                _handler.Handle(new CreateRole("SuperUser"));
                _handler.Handle(new CreateRole("User"));
                _handler.Handle(new CreateRole("Admin"));
                _handler.Handle(new CreateRole("ProductManager"));
                _handler.Handle(new CreateRole("Support"));
                _handler.Handle(new CreateRole("AccountManager"));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}