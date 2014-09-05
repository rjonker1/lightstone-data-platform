using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Events;

namespace PackageBuilder.Domain.Entities
{
    public class DataProvider : AggregateRoot, IDataProvider
    {
        private readonly Guid _id;
        public override Guid Id
        {
            get { return _id; }
        }
        public string Name { get; private set; }
        public Type ResponseType { get; private set; }

        public DataProvider() { }

        public DataProvider(Guid id, string name)
        {
            ApplyChange(new DataProviderCreatedEvent(id, name));
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("newName");
            ApplyChange(new DataProviderRenamedEvent(_id, newName));
        }
    }
}