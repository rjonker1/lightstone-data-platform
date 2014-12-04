using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Core.Commands;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class CreateDataProvider : DomainCommand
    {
        public IPointToLaceProvider DataProvider { get; set; }
        public readonly DataProviderName Name;
        public readonly string Description;
        public readonly double CostOfSale;
        public readonly Type ResponseType;
        public readonly State State;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly DateTime? EditedDate;
        public readonly Type DataProviderType;

        public CreateDataProvider(IPointToLaceProvider dataProvider, Guid id, DataProviderName name, string description, double costOfSale, Type responseType, string owner, DateTime createdDate)
        {
            DataProvider = dataProvider;
			Id = id;
			Name = name;
            Description = description;
            CostOfSale = costOfSale;
            ResponseType = responseType;
            Owner = owner;
            CreatedDate = createdDate;
        }
    }
}