﻿using System.Linq;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class DataSetBuilder
    {
        private string _name;
        private IDataField[] _fields = Enumerable.Empty<IDataField>().ToArray();
        public IDataSet Build()
        {
            return new DataSet(_name){ DataFields = _fields};
        }

        public DataSetBuilder With(string name)
        {
            _name = name;
            return this;
        }

        public DataSetBuilder With(params IDataField[] fields)
        {
            _fields = fields;
            return this;
        }
    }
}