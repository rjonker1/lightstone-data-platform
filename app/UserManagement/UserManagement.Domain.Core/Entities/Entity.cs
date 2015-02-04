﻿using System;
using System.Runtime.Serialization;

namespace UserManagement.Domain.Core.Entities
{
    [DataContract]
    public abstract class Entity : IEntity
    {
        [DataMember]
        public virtual Guid Id { get; protected internal set; }

        protected Entity() { }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}
