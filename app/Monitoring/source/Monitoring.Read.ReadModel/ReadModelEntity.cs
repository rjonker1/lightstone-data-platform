using System;
namespace Monitoring.Read.ReadModel
{
    public abstract class ReadModelEntity
    {
        public string Id { get; private set; }
        public Guid AggregateId { get; set; }

        protected ReadModelEntity()
        {
        }

        protected ReadModelEntity(Guid id)
        {
            Id = MakeId(this.GetType(), id);
            AggregateId = id;
        }

        public static string MakeId(Type type, Guid id)
        {
            return string.Concat(type.Name, "-", id);
        }
    }
}
