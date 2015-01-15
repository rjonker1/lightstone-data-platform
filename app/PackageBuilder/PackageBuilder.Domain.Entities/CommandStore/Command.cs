using System;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.CommandStore
{
    public class Command : Entity
    {
        public virtual Type Type { get; protected set; }
        public virtual string TypeName { get; protected set; }
        public virtual byte[] CommandData { get; protected set; }

        protected Command() { }

        public Command(Guid id, Type type, string typeName, byte[] commandData) : base(id)
        {
            Type = type;
            TypeName = typeName;
            CommandData = commandData;
        }
    } 
}