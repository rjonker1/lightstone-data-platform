﻿using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.TestObjects.Builders
{
    public class DataProviderOverrideBuilder
    {
        private Guid _id;
        private double _costOfSale;
        private IEnumerable<DataFieldOverride> _dataFieldOverrides;

        public DataProviderOverride Build()
        {
            return new DataProviderOverride
            {
                Id = _id,
                CostOfSale = _costOfSale,
                DataFieldOverrides = _dataFieldOverrides
            };
        }

        public DataProviderOverrideBuilder With(Guid id)
        {
            _id = id;
            return this;
        }

        public DataProviderOverrideBuilder With(double costOfSale)
        {
            _costOfSale = costOfSale;
            return this;
        }

        public DataProviderOverrideBuilder With(params DataFieldOverride[] dataFieldValueOverrides)
        {
            _dataFieldOverrides = dataFieldValueOverrides;
            return this;
        }
    }
}