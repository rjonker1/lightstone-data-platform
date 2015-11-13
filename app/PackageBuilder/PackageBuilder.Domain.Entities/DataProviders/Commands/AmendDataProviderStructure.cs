using System;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class AmendDataProviderStructure : DomainCommand
    {
        public AmendDataProviderStructure(Guid id) : base(id)
        {
        }
    }
}