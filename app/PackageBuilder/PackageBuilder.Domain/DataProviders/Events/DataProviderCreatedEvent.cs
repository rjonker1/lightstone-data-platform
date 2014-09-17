using System;
using PackageBuilder.Domain.Helpers.Cqrs.Events;

namespace PackageBuilder.Domain.DataProviders.Events
{
    public class DataProviderCreatedEvent : Event
    {
		public readonly string Name;
        public DataProviderCreatedEvent(Guid id, string name)
        {
			Id = id;
			Name = name;
		}
    }
}