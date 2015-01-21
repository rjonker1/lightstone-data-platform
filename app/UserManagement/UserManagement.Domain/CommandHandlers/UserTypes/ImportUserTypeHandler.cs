using System;
using UserManagement.Domain.Core.MessageHandling;
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
            try
            {
                _handler.Handle(new CreateUserType("User"));
                _handler.Handle(new CreateUserType("Internal"));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}