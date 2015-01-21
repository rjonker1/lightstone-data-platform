using System;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.Industries.Commands
{
    public class CreateIndustry : DomainCommand
    {
        public readonly string Name;
        public bool IsSelected;

        public CreateIndustry(Guid id, string name, bool selected) : base(id)
        {
            Name = name;
            IsSelected = selected;
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());
        }
    }
}