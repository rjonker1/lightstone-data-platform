using System;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.Packages.Commands
{
    public class DeletePackage : DomainCommand
    {
        public DeletePackage(Guid id)
        {
            Id = id;
        }
    }
}