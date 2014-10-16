using System;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.Industries.Commands
{
    public class CreateIndustry : IDomainCommand
    {
        public Guid Id;
        public readonly string Name;

        public CreateIndustry(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}