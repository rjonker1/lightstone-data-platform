using System;

namespace EventTracking.Read.ReadModel
{
    public abstract class ReadModelEntity
    {
        public virtual string Id { get; private set; }
        public virtual Guid AggregateId { get; private set; }

        protected ReadModelEntity()
        {
        }

        protected ReadModelEntity(Guid id)
        {
            Id = MakeId(GetType(), id);
            AggregateId = id;
        }

        public static string MakeId(Type type, Guid id)
        {
            return string.Concat(type.Name, "-", id);
        }
    }
}
