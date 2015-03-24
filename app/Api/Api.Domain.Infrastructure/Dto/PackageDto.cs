using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Contracts.Actions;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;

namespace Api.Domain.Infrastructure.Dto
{
    //public class PackageResponseDto
    //{
    //    public Guid Id { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public string Notes { get; set; }
    //    public int Version { get; set; }
    //    public decimal DisplayVersion { get; set; }
    //    public State State { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public DateTime EditedDate { get; set; }
    //    public string Owner { get; set; }
    //    public double CostOfSale { get; set; }
    //    public double RecommendedSalePrice { get; set; }
    //    public IAction Action { get; internal set; }
    //}

    //public class Action : NamedEntity, IAction
    //{
    //    public Action(string name)
    //        : base(name)
    //    {
    //    }

    //    public ICriteria Criteria { get; set; }
    //}

    public class PackageResponseDto
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IAction Action { get; private set; }

        public IEnumerable<IDataProvider> DataProviders { get; private set; }

        public PackageResponseDto()
        {
        }

        public PackageResponseDto(Guid id, string name, IAction action, IEnumerable<IDataProvider> dataProviders)
        {
            Id = id;
            Name = name;
            Action = action;
            DataProviders = dataProviders;
        }
    }
}
