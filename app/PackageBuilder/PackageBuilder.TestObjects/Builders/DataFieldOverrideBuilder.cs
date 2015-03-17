using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.TestObjects.Builders
{
    public class DataFieldOverrideBuilder
    {
        private string _name;
        private string _namespace;
        private string _displayName;
        private double _costOfSale;
        private IEnumerable<IDataFieldOverride> _dataFieldOverrides;

        public IDataFieldOverride Build()
        {
            return new DataFieldOverride
            {
                Name = _name,
                Namespace = _namespace,
                DisplayName = _displayName,
                CostOfSale = _costOfSale,
                DataFieldOverrides = _dataFieldOverrides
            };
        }

        public DataFieldOverrideBuilder With(string name, string @namespace, string displayName)
        {
            _name = name;
            _namespace = @namespace;
            _displayName = displayName;
            return this;
        }

        public DataFieldOverrideBuilder With(double costOfSale)
        {
            _costOfSale = costOfSale;
            return this;
        }

        public DataFieldOverrideBuilder With(params IDataFieldOverride[] dataFieldOverrides)
        {
            _dataFieldOverrides = dataFieldOverrides;
            return this;
        }
    }
}