using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Dtos.Write;

namespace PackageBuilder.TestObjects.Builders
{
    public class DataProviderDtoBuilder
    {
        private Guid _id;
        private string _name;
        private string _description;
        private decimal _costOfSale;
        //private bool _sourceConfigurationIsApiConfiguration;
        //private string _sourceConfigurationUrl;
        //private string _sourceConfigurationUsername;
        //private string _sourceConfigurationConnectionString;
        private bool _fieldLevelCostPriceOverride;
        private string _owner;
        private DateTime _createdDate;
        private DateTime? _editedDate;
        private int _version;
        private IEnumerable<DataProviderFieldItemDto> _dataFields;

        public DataProviderDto Build()
        {
            return new DataProviderDto
            {
                Id = _id,
                Name = _name,
                Description = _description,
                CostOfSale = _costOfSale,
                FieldLevelCostPriceOverride = _fieldLevelCostPriceOverride,
                Owner = _owner,
                CreatedDate = _createdDate,
                EditedDate = _editedDate,
                Version = _version,
                DataFields = _dataFields,
            };
        }

        public DataProviderDtoBuilder With(Guid id)
        {
            _id = id;
            return this;
        }

        public DataProviderDtoBuilder With(string name, string description = "")
        {
            _name = name;
            _description = description;
            return this;
        }

        public DataProviderDtoBuilder With(string owner)
        {
            _owner = owner;
            return this;
        }

        public DataProviderDtoBuilder With(decimal costOfSale)
        {
            _costOfSale = costOfSale;
            return this;
        }

        public DataProviderDtoBuilder With(bool fieldLevelCostPriceOverride)
        {
            _fieldLevelCostPriceOverride = fieldLevelCostPriceOverride;
            return this;
        }

        public DataProviderDtoBuilder With(DateTime createdDate)
        {
            _createdDate = createdDate;
            return this;
        }

        public DataProviderDtoBuilder With(DateTime? editedDate)
        {
            _editedDate = editedDate;
            return this;
        }

        public DataProviderDtoBuilder With(int version)
        {
            _version = version;
            return this;
        }

        public DataProviderDtoBuilder With(params DataProviderFieldItemDto[] dataFields)
        {
            _dataFields = dataFields;
            return this;
        }
    }
}