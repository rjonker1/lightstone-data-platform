using System;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.Industries.WriteModels
{
    public class Industry : Entity
    {
        protected Industry() { }

        public virtual string Name { get; set; }

        public Industry(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}