using System;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class CreateDataProvider : DomainCommand
    {
        public readonly string Name;
        public readonly string Description;
        public readonly double CostOfSale;
        public readonly string SourceURL;
        public readonly Type ResponseType;
        public readonly string State;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly DateTime EditedDate;
        public readonly Type DataProviderType;

        public CreateDataProvider(Guid id, string name, string description, double costOfSale, string sourceUrl, Type responseType, string state, string owner, DateTime createdDate)
        {
			Id = id;
			Name = name;
            Description = description;
            CostOfSale = costOfSale;
            SourceURL = sourceUrl;
            ResponseType = responseType;
            State = state;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = createdDate;
        }
    }
}