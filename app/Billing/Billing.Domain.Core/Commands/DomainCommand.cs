using System;

namespace Billing.Domain.Core.Commands
{
    public class DomainCommand : IDomainCommand
    {
        public Guid Id;
    }
}