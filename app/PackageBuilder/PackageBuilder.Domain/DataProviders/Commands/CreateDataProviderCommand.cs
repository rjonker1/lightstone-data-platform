using System;
using PackageBuilder.Domain.Helpers.Cqrs.CommandHandling;

namespace PackageBuilder.Domain.DataProviders.Commands
{
    public class CreateDataProviderCommand : Command
    {
        public readonly string Name;

        public CreateDataProviderCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}