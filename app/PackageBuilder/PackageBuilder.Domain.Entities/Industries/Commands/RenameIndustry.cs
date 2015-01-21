using System;
using DataPlatform.Shared.Helpers.Extensions;

namespace PackageBuilder.Domain.Entities.Industries.Commands
{
    public class RenameIndustry : CreateIndustry
    {
        public RenameIndustry(Guid id, string name, bool selected) : base(id, name, selected)
        {
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());
        }
    }
}