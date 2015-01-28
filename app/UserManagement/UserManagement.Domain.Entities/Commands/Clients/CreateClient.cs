using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Clients
{
    public class CreateClient : DomainCommand
    {

        public string ClientName;

        public CreateClient(string clientName)
        {
            Id = Guid.NewGuid();
            ClientName = clientName;
        }
    }
}