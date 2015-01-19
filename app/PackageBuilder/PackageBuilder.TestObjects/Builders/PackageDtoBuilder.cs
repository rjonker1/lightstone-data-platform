using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Dtos.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.TestObjects.Builders
{
    public class PackageDtoBuilder
    {
        private Guid _id;
        private string _name;
        private string _description;
        private string _notes;
        private IEnumerable<Industry> _industries;
        private int _version;
        private decimal _displayVersion;
        //private string _state;
        private State _state;
        private DateTime _createdDate;
        private DateTime _editedDate;
        private string _owner;
        private double _costOfSale;
        private double _recommendedSalePrice;
        private IEnumerable<DataProviderDto> _dataProviderDtos;
        public PackageDto Build()
        {
            return new PackageDto
            {
                Id =_id,
                Name = _name,
                Description = _description,
                Notes = _notes,
                Industries = _industries,
                Version = _version,
                DisplayVersion = _displayVersion,
                State = _state,
                CreatedDate = _createdDate,
                EditedDate = _editedDate,
                Owner = _owner,
                CostOfSale = _costOfSale,
                RecommendedSalePrice = _recommendedSalePrice,
                DataProviders = _dataProviderDtos,
            };
        }

        public PackageDtoBuilder With(Guid id)
        {
            _id = id;
            return this;
        }

        public PackageDtoBuilder With(string name, string description = "", string notes = "")
        {
            _name = name;
            _description = description;
            _notes = notes;
            return this;
        }

        public PackageDtoBuilder With(params Industry[] industries)
        {
            _industries = industries;
            return this;
        }

        public PackageDtoBuilder With(int version)
        {
            _version = version;
            return this;
        }

        public PackageDtoBuilder With(decimal displayVersion)
        {
            _displayVersion = displayVersion;
            return this;
        }

        public PackageDtoBuilder With(State state, string owner = "")
        {
            _state = state;
            _owner = owner;
            return this;
        }

        public PackageDtoBuilder With(DateTime createdDate, DateTime? editedDate = null)
        {
            _createdDate = createdDate;
            if (editedDate != null) _editedDate = editedDate.Value;
            return this;
        }

        public PackageDtoBuilder With(double costOfSale, double recommendedSalePrice = 0d)
        {
            _costOfSale = costOfSale;
            _recommendedSalePrice = recommendedSalePrice;
            return this;
        }

        public PackageDtoBuilder With(params DataProviderDto[] dataProviderDtos)
        {
            _dataProviderDtos = dataProviderDtos;
            return this;
        }
    }
}