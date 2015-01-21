
using System;

namespace PackageBuilder.Core.Commands
{
    public interface IDomainCommand
    {
        Guid Id { get; }
    }
}
