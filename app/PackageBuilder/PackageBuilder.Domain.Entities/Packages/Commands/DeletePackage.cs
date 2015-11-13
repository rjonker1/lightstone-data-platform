using System;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.Packages.Commands
{
    public class DeletePackage : DomainCommand
    {
        public DeletePackage(Guid id) : base(id) { }

        public override string ToString()
        {
            return "{0} - {2}".FormatWith(Id, GetType());
        }
    }
}