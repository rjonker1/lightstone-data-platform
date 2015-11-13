
using System;

namespace PackageBuilder.Domain.Core.Contracts.Commands
{
    public interface IDomainCommand
    {
        Guid Id { get; }
    }
}
