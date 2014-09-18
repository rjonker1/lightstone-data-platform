using System;
using PackageBuilder.Domain.Helpers.Cqrs.Events;

namespace PackageBuilder.Domain.DataFields.Events
{
    public class DataFieldCreated : DomainEvent
    {
		public readonly string Name;
        public readonly Type Type;
        public readonly Guid DataProviderId;
        public DataFieldCreated(Guid id, string name, Type type, Guid dataProviderId)
        {
			Id = id;
			Name = name;
            Type = type;
            DataProviderId = dataProviderId;
        }
    }
}