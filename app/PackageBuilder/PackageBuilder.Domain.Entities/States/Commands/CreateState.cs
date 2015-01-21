using System;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.Commands;
using PackageBuilder.Domain.Entities.Enums;

namespace PackageBuilder.Domain.Entities.States.Commands
{
    public class CreateState : DomainCommand
    {
        public readonly StateName Name;
        public readonly string Alias;

        public CreateState(Guid id, StateName name) : base(id)
        {
            Name = name;
            Alias = name.ToString();
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());
        }
    }
}