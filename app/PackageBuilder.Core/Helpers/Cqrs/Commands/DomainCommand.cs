using System;

namespace PackageBuilder.Core.Helpers.Cqrs.Commands
{
    public class DomainCommand : IDomainCommand
    {
        public Guid Id;
    }
}
