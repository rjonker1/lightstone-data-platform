using System;
using PackageBuilder.Core.Events;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Domain.Entities.DataFields.Events
{
    public class DataFieldCreated : DomainEvent
    {
		public readonly string Name;
        public readonly Type Type;
        public readonly DataProvider DataProvider;
        public readonly Guid DataProviderId;
        public DataFieldCreated(Guid id, string name, Type type, DataProvider dataProvider)
        {
			Id = id;
			Name = name;
            Type = type;
            DataProvider = dataProvider;
        }
    }
}