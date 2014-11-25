﻿using System;
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

        public Industry(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}