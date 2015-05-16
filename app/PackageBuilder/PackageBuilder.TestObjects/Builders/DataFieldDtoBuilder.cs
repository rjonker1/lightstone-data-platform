using System.Collections.Generic;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.TestObjects.Builders
{
    public class DataFieldDtoBuilder
    {
        private string _name;
        private string _label;
        private string _definition;
        private IEnumerable<Industry> _industries;
        private double _costOfSale;
        private bool _isSelected;
        private string _type;
        private IEnumerable<DataProviderFieldItemDto> _dataFields;

        public DataProviderFieldItemDto Build()
        {
            return new DataProviderFieldItemDto
            {
                Name = _name,
                Type = _type,
                Label = _label,
                Definition = _definition,
                Industries = _industries,
                CostOfSale = _costOfSale,
                IsSelected = _isSelected,
                DataFields = _dataFields,
            };
        }

        public DataFieldDtoBuilder With(string name, string label, string definition = "")
        {
            _name = name;
            _label = label;
            _definition = definition;
            return this;
        }

        public DataFieldDtoBuilder With(params Industry[] industries)
        {
            _industries = industries;
            return this;
        }

        public DataFieldDtoBuilder With(double costOfSale)
        {
            _costOfSale = costOfSale;
            return this;
        }

        public DataFieldDtoBuilder With(bool isSelected)
        {
            _isSelected = isSelected;
            return this;
        }

        public DataFieldDtoBuilder With(string type)
        {
            _type = type;
            return this;
        }

        public DataFieldDtoBuilder With(params DataProviderFieldItemDto[] dataFields)
        {
            _dataFields = dataFields;
            return this;
        }
    }
}