﻿using System;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.CommandStore
{
    public class Command : Entity
    {
        public virtual Guid EntityId { get; protected set; }
        public virtual DateTime CreatedDate { get; protected set; }
        public virtual Type Type { get; protected set; }
        public virtual string TypeName { get; protected set; }
        public virtual byte[] CommandData { get; protected set; }

        protected Command() { }

        public Command(Guid id, Guid entityId, Type type, string typeName, byte[] commandData)
            : base(id)
        {
            EntityId = entityId;
            CreatedDate = DateTime.UtcNow;
            Type = type;
            TypeName = typeName;
            CommandData = commandData;
        }
    } 
}