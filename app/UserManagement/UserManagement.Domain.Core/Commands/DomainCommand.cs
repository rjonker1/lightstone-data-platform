using System;

namespace UserManagement.Domain.Core.Commands
{
    public class DomainCommand : IDomainCommand
    {
        public Guid Id;
    }
}