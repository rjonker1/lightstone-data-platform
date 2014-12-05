using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.TestObjects.Builders
{
    public class WriteDataProviderBuilder
    {
        public DataProviderName _name;
        public string _description;
        public double _costOfSale;
        public Type _responseType;
        public bool _fieldLevelCostPriceOverride;
        public string _owner;
        public DateTime _createdDate;
        public DateTime? _editedDate;
        public IEnumerable<IDataField> _dataFields { get; internal set; }
        public DataProvider Build()
        {
            return new DataProvider
            {
                Name = _name,
                Description = _description,
                CostOfSale = _costOfSale,
                ResponseType = _responseType,
                FieldLevelCostPriceOverride = _fieldLevelCostPriceOverride,
                Owner = _owner,
                CreatedDate = _createdDate,
                EditedDate = _editedDate,
                DataFields = _dataFields
            };
        }

        public WriteDataProviderBuilder With(DataProviderName name)
        {
            _name = name;
            return this;
        }

        public WriteDataProviderBuilder With(string description, string owner = "")
        {
            _description = description;
            _owner = owner;
            return this;
        }

        public WriteDataProviderBuilder With(double costOfSale)
        {
            _costOfSale = costOfSale;
            return this;
        }

        public WriteDataProviderBuilder With(Type responseType)
        {
            _responseType = responseType;
            return this;
        }

        public WriteDataProviderBuilder With(bool fieldLevelCostPriceOverride)
        {
            _fieldLevelCostPriceOverride = fieldLevelCostPriceOverride;
            return this;
        }

        public WriteDataProviderBuilder With(DateTime createdDate)
        {
            _createdDate = createdDate;
            return this;
        }

        public WriteDataProviderBuilder With(DateTime? editedDate)
        {
            _editedDate = editedDate;
            return this;
        }

        public WriteDataProviderBuilder With(params IDataField[] dataFields)
        {
            _dataFields = dataFields;
            return this;
        }
    }
}