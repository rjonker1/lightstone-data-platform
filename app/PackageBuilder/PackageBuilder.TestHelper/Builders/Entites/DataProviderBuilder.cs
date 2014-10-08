﻿using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class DataProviderBuilder
    {
        private Guid _id;
        private string _name;
        public IDataProvider Build()
        {
            return new DataProvider(_id, _name, new []{new DataField(), });
        }

        public DataProviderBuilder With(Guid id)
        {
            _id = id;
            return this;
        }

        public DataProviderBuilder With(string name)
        {
            _name = name;
            return this;
        }
    }
}