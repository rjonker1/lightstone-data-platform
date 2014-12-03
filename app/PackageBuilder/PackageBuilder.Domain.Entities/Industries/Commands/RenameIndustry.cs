using System;

namespace PackageBuilder.Domain.Entities.Industries.Commands
{
    public class RenameIndustry : CreateIndustry
    {
        public RenameIndustry(Guid id, string name, bool selected) : base(id, name, selected)
        {
        }
    }
}