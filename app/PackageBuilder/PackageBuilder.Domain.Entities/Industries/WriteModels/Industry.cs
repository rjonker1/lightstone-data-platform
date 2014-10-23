using System;
using PackageBuilder.Core.Entities;
using PackageBuilder.Core.NHibernate.Attributes;

namespace PackageBuilder.Domain.Entities.Industries.WriteModels
{
    public class Industry : Entity
    {
        protected Industry() { }

        [DomainSignature]
        public virtual string Name { get; set; }

        public Industry(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}