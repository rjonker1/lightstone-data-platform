using System;
using System.Runtime.Serialization;
using PackageBuilder.Core.Entities;
using PackageBuilder.Core.NHibernate.Attributes;

namespace PackageBuilder.Domain.Entities.Industries.WriteModels
{
    [DataContract]
    public class Industry : Entity
    {
        protected Industry() { }

        [DomainSignature, DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual bool IsSelected { get; set; }

        public Industry(Guid id, string name, bool selected) : base(id)
        {
            Name = name;
            IsSelected = selected;
        }
    }
}