using System;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.Industries.Commands
{
    public class CreateIndustry : IDomainCommand
    {
        public Guid Id;
        public readonly string Name;
        public bool isSelected;

        public CreateIndustry(Guid id, string name, bool selected)
        {
            Id = id;
            Name = name;
            isSelected = selected;
        }
    }
}