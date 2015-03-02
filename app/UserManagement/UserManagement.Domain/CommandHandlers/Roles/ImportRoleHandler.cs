using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Roles;

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
            _handler.Handle(new ValueEntityDto("Owner", typeof(Role)));
            _handler.Handle(new ValueEntityDto("SuperUser", typeof(Role)));
            _handler.Handle(new ValueEntityDto("User", typeof(Role)));
            _handler.Handle(new ValueEntityDto("Admin", typeof(Role)));
            _handler.Handle(new ValueEntityDto("ProductManager", typeof(Role)));
            _handler.Handle(new ValueEntityDto("Support", typeof(Role)));
            _handler.Handle(new ValueEntityDto("AccountManager", typeof(Role)));
        }
    }
}