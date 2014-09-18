using System;

namespace PackageBuilder.Domain.Helpers.Cqrs.Commands
{
    public class DomainCommand : IDomainCommand
    {
        public Guid Id;  
    }
}