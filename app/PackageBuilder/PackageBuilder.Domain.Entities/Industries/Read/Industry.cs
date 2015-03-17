using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.Entities;
using PackageBuilder.Core.NHibernate.Attributes;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;

namespace PackageBuilder.Domain.Entities.Industries.Read
{
    [DataContract]
    public class Industry : Entity, IIndustry
    {
        [DomainSignature, DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual bool IsSelected { get; set; }

        protected Industry() { }

        public Industry(Guid id, string name, bool selected) : base(id)
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