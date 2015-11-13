using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.TestObjects.Builders
{
    public class WritePackageBuilder
    {
        private string _name;
        private string _description;
        private decimal _costOfSale;
        private decimal _recommendedSalePrice;
        private string _notes;
        private IEnumerable<Industry> _industries;
        private State _state;
        public decimal _displayVersion;
        public string _owner;
        public DateTime _createdDate;
        public DateTime? _editedDate;
        public IEnumerable<IDataProvider> _dataProviders;
        public Package Build()
        {
            return new Package
            {
                Name = _name,
                Description = _description,
                CostOfSale = _costOfSale,
                RecommendedSalePrice = _recommendedSalePrice,
                Notes = _notes,
                Industries = _industries,
                State = _state,
                DisplayVersion = _displayVersion,
                Owner = _owner,
                CreatedDate = _createdDate,
                EditedDate = _editedDate,
                DataProviders = _dataProviders
            };
        }

        public WritePackageBuilder With(string name, string description = "", string notes = "", string owner = "")
        {
            _name = name;
            _description = description;
            _notes = notes;
            _owner = owner;
            return this;
        }

        public WritePackageBuilder With(decimal costOfSale = 0m, decimal recommendedSalePrice = 0m)
        {
            _costOfSale = costOfSale;
            _recommendedSalePrice = recommendedSalePrice;
            return this;
        }

        public WritePackageBuilder With(params Industry[] industries)
        {
            _industries = industries;
            return this;
        }

        public WritePackageBuilder With(State state)
        {
            _state = state;
            return this;
        }

        public WritePackageBuilder With(decimal displayVersion)
        {
            _displayVersion = displayVersion;
            return this;
        }

        public WritePackageBuilder With(DateTime createdDate)
        {
            _createdDate = createdDate;
            return this;
        }

        public WritePackageBuilder With(DateTime? editedDate)
        {
            _editedDate = editedDate;
            return this;
        }

        public WritePackageBuilder With(params IDataProvider[] dataProviders)
        {
            _dataProviders = dataProviders;
            return this;
        }
    }
}