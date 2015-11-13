using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;

namespace PackageBuilder.TestObjects.Builders
{
    public class DataProviderOverrideBuilder
    {
        private Guid _id;
        private decimal _costOfSale;
        private IEnumerable<IDataFieldOverride> _dataFieldOverrides;

        public IDataProviderOverride Build()
        {
            return new DataProviderOverride()
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

        public DataProviderOverrideBuilder With(decimal costOfSale)
        {
            _costOfSale = costOfSale;
            return this;
        }

        public DataProviderOverrideBuilder With(params IDataFieldOverride[] dataFieldValueOverrides)
        {
            _dataFieldOverrides = dataFieldValueOverrides;
            return this;
        }
    }
}