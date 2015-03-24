using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace PackageBuilder.TestObjects.Builders
{
    public class WriteDataProviderBuilder
    {
        private DataProviderName _name;
        private string _description;
        private double _costOfSale;
        private Type _responseType;
        private bool _fieldLevelCostPriceOverride;
        private string _owner;
        private DateTime _createdDate;
        private DateTime? _editedDate;
        private IEnumerable<IDataField> _dataFields;
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