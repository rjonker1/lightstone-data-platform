using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.TestObjects.Builders
{
    public class DataFieldBuilder
    {
        private string _name;
        private string _label;
        private string _definition;
        private IEnumerable<Industry> _industries;
        private double _costOfSale;
        private bool _isSelected;
        private Type _type;
        private IEnumerable<IDataField> _dataFields;

        public IDataField Build()
        {
            return new DataField(_name, _type.ToString(), _dataFields)
            {
                Label = _label,
                Definition = _definition,
                Industries = _industries,
                CostOfSale = _costOfSale,
                IsSelected = _isSelected,
            };
        }

        public DataFieldBuilder With(string name, string label = "", string definition = "")
        {
            _name = name;
            _label = label;
            _definition = definition;
            return this;
        }

        public DataFieldBuilder With(params Industry[] industries)
        {
            _industries = industries;
            return this;
        }

        public DataFieldBuilder With(double costOfSale)
        {
            _costOfSale = costOfSale;
            return this;
        }

        public DataFieldBuilder With(bool isSelected)
        {
            _isSelected = isSelected;
            return this;
        }

        public DataFieldBuilder With(Type type)
        {
            _type = type;
            return this;
        }

        public DataFieldBuilder With(params IDataField[] dataFields)
        {
            _dataFields = dataFields;
            return this;
        }
    }
}