using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.UserTypes;

namespace UserManagement.Domain.CommandHandlers.UserTypes
{
    public class ImportUserTypeHandler : AbstractMessageHandler<ImportUserType>
    {

        private readonly IHandleMessages _handler;

        public ImportUserTypeHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportUserType command)
        {
            _handler.Handle(new ValueEntityDto("Internal", typeof (UserType)));
            _handler.Handle(new ValueEntityDto("External", typeof(UserType)));
        }
    }
}