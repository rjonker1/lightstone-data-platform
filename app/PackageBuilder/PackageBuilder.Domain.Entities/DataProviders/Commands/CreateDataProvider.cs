using System;
using PackageBuilder.Core.Commands;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class CreateDataProvider : DomainCommand
    {
        public readonly string Name;
        public readonly string Description;
        public readonly double CostOfSale;
        public readonly string SourceURL;
        public readonly Type ResponseType;
        public readonly State State;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly DateTime? EditedDate;
        public readonly Type DataProviderType;

        public CreateDataProvider(Guid id, string name, string description, double costOfSale, string sourceUrl, Type responseType, State state, string owner, DateTime createdDate, DateTime? editedDate)
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
            EditedDate = editedDate;
        }
    }
}