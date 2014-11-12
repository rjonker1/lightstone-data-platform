﻿using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class WriteDataProviderBuilder
    {
        private Guid _id;
        private DataProviderName _name;
        private IEnumerable<IDataField> _dataFields;
        public DataProvider Build()
        {
            return new DataProvider(_id, _name, new List<IDataField>());
        }

        public WriteDataProviderBuilder With(Guid id)
        {
            _id = id;
            return this;
        }

        public WriteDataProviderBuilder With(DataProviderName name)
        {
            _name = name;
            return this;
        }

        public WriteDataProviderBuilder With(IEnumerable<IDataField> dataFields)
        {
            _dataFields = dataFields;
            return this;
        }
    }
}