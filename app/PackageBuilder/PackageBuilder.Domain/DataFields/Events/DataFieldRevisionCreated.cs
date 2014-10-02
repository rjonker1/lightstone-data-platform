using System;
using PackageBuilder.Core.Helpers.Cqrs.Events;
using PackageBuilder.Domain.DataProviders.WriteModels;

namespace PackageBuilder.Domain.DataFields.Events
{
    public class DataFieldRevisionCreated : DomainEvent
    {
		public readonly string Name;
        public readonly Type Type;
        public readonly DataProvider DataProvider;
        public readonly Guid DataProviderId;
        public DataFieldRevisionCreated(Guid id, string name, Type type, DataProvider dataProvider)
        {
			Id = id;
			Name = name;
            Type = type;
            DataProvider = dataProvider;
        }
    }
}