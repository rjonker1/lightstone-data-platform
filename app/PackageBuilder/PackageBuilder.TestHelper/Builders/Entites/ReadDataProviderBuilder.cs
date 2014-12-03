using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class ReadDataProviderBuilder
    {
        private Guid _id;
        private DataProviderName _name;
        private string _description;
        private double _costPrice;
        private int _version;
        private string _owner;
        private DateTime _createdDate;
        private DateTime _editedDate;
        public DataProvider Build()
        {
            return new DataProvider(_id, _name, _description, _costPrice, _version, _owner, _createdDate, _editedDate);
        }

        public ReadDataProviderBuilder With(Guid id)
        {
            _id = id;
            return this;
        }

        public ReadDataProviderBuilder With(DataProviderName name)
        {
            _name = name;
            _description = name.ToString();
            return this;
        }
        public ReadDataProviderBuilder With(double costPrice)
        {
            _costPrice = costPrice;
            return this;
        }

        public ReadDataProviderBuilder With(int version)
        {
            _version = version;
            return this;
        }

        public ReadDataProviderBuilder With(DateTime createdDate)
        {
            _createdDate = createdDate;
            _editedDate = createdDate;
            return this;
        }
    }
}