using System;

namespace PackageBuilder.Domain.Events
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

    public class DataProviderRenamedEvent : Event
    {
        public readonly string NewName;
        public DataProviderRenamedEvent(Guid id, string newName)
        {
            Id = id;
            NewName = newName;
        }
    }
}