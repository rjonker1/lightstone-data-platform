using System;
using PackageBuilder.Domain.Helpers.Cqrs.Events;

namespace PackageBuilder.Domain.DataProviders.Events
{
    public class DataProviderCreated : DomainEvent
    {
		public readonly string Name;
        public DataProviderCreated(Guid id, string name)
        {
			Id = id;
			Name = name;
		}
    }
}