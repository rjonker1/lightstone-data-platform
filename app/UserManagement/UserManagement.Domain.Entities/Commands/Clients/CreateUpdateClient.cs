using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Clients
{
    public class CreateUpdateClient : DomainCommand
    {
        public string ClientName;

        public CreateUpdateClient(string clientName)
        {
            ClientName = clientName;
        }

        public CreateUpdateClient(Guid id, string clientName)
        {
            Id = id;
            ClientName = clientName;
        }
    }
}