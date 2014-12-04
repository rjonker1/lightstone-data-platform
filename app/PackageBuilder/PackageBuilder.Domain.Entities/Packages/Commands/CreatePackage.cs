using System;
using System.Collections.Generic;
using PackageBuilder.Core.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;
using IDataProvider = PackageBuilder.Domain.Entities.DataProviders.WriteModels.IDataProvider;

namespace PackageBuilder.Domain.Entities.Packages.Commands
{
    public class CreatePackage : DomainCommand
    {
        public readonly string Name;
        public readonly string Description;
        public readonly double CostPrice;
        public readonly double SalePrice;
        public readonly string Notes;
        public readonly IEnumerable<Industry> Industries;
        public readonly State State;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly DateTime? EditedDate;
        public readonly IEnumerable<IDataProvider> DataProviders;

        public CreatePackage(Guid id, string name, string description, double costPrice, double salePrice, string notes, IEnumerable<Industry> industries, State state, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProvider> dataProviders)
        {
            Id = id;
            Name = name;
            Description = description;
            CostPrice = costPrice;
            SalePrice = salePrice;
            Notes = notes;
            Industries = industries;
            State = state;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = editedDate;
            DataProviders = dataProviders;
        }
    }
}