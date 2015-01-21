﻿using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Dtos.WriteModels
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public IEnumerable<Industry> Industries { get; set; }
        public int Version { get; set; }
        public decimal DisplayVersion { get; set; }
        public State State { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public string Owner { get; set; }
        public double CostOfSale { get; set; }
        public double RecommendedSalePrice { get; set; }
        public IEnumerable<DataProviderDto> DataProviders { get; set; }
    }
}