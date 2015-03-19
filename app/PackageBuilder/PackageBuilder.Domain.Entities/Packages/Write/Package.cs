using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AutoMapper;
using CommonDomain.Core;
using DataPlatform.Shared.Helpers.Extensions;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Entities.Contracts.Actions;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.Contracts.States.Read;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.Packages.Events;
using PackageBuilder.Domain.Entities.Requests;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Domain.Entities.Packages.Write
{
    [DataContract]
    public class Package : AggregateBase, IPackage
    {
        [DataMember]
        public string Name { get; internal set; }
        [DataMember]
        public string Description { get; internal set; }
        [DataMember]
        public double CostOfSale { get; internal set; }
        [DataMember]
        public double RecommendedSalePrice { get; internal set; }
        [DataMember]
        public IAction Action { get; internal set; }
        [DataMember]
        public string Notes { get; internal set; }
        [DataMember]
        public IEnumerable<IIndustry> Industries { get; internal set; }
        [DataMember]
        public IState State { get; internal set; }
        [DataMember]
        public decimal DisplayVersion { get; internal set; }
        [DataMember]
        public string Owner { get; internal set; }
        [DataMember]
        public DateTime CreatedDate { get; internal set; }
        [DataMember]
        public DateTime? EditedDate { get; internal set; }
        [DataMember]
        public IEnumerable<IDataProvider> DataProviders { get; internal set; }

        //Used for serialization
        internal Package() { }

        //Used by NEventstore
        private Package(Guid id)
        {
            Id = id;
        }
        
        //TODO: Remove - Constructor used for testing in LACE
        public Package(Guid id, string name, IAction action, IEnumerable<IDataProvider> dataProviders) 
            : this(id)
        {
            Id = id;
            Name = name;
            Action = action;
            DataProviders = dataProviders;
        }

        public Package(Guid id, string name, State state ,IEnumerable<IDataProvider> dataProviders) 
            : this(id)
        {
            Id = id;
            Name = name;
            State = state;
            DataProviders = dataProviders;
        }

        public Package(Guid id, string name, string description, IEnumerable<Industry> industries, double costPrice, double salePrice, State state, decimal displayVersion, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProviderOverride> dataProviders)
            : this(id)
        {
            RaiseEvent(new PackageCreated(id, name, description, costPrice, salePrice, industries, state, displayVersion, owner, createdDate, editedDate, dataProviders));
        }

        public void CreatePackageRevision(Guid id, string name, string description, double costPrice, double salePrice, string notes, IEnumerable<Industry> industries, State state, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProviderOverride> dataProviders)
        {
            if (state.Name == StateName.Published) 
                DisplayVersion = Math.Ceiling(DisplayVersion);
            else
            {
                DisplayVersion += 0.1m;
                Name = name;
            }

            RaiseEvent(new PackageUpdated(id, name, description, costPrice, salePrice, notes, industries, state, Version + 1, DisplayVersion, owner, createdDate, editedDate, dataProviders));
        }

        private void Apply(PackageCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostOfSale = @event.CostPrice;
            RecommendedSalePrice = @event.SalePrice;
            Notes = @event.Notes;
            Industries = @event.Industries;
            State = @event.State;
            DisplayVersion = @event.DisplayVersion;
            Owner = @event.Owner;
            CreatedDate = @event.CreatedDate;
            EditedDate = @event.EditedDate;

            this.Info(() => "Attempting to map data provider overrides from PackageCreated event");

            DataProviders = Mapper.Map<IEnumerable<IDataProviderOverride>, IEnumerable<IDataProvider>>(@event.DataProviderValueOverrides);

            this.Info(() => "Successfully mapped data provider overrides from PackageCreated event");
        }

        private void Apply(PackageUpdated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostOfSale = @event.CostPrice;
            RecommendedSalePrice = @event.SalePrice;
            Notes = @event.Notes;
            Industries = @event.Industries;
            State = @event.State;
            DisplayVersion = @event.DisplayVersion;
            Owner = @event.Owner;
            CreatedDate = @event.CreatedDate;
            EditedDate = @event.EditedDate;

            this.Info(() => "Attempting to map data provider overrides from PackageUpdated event");

            DataProviders = Mapper.Map<IEnumerable<IDataProviderOverride>, IEnumerable<IDataProvider>>(@event.DataProviderValueOverrides);

            this.Info(() => "Successfully mapped data provider overrides from PackageUpdated event");
        }

        public ILaceRequest FormLaceRequest(Guid userId, string userName, string searchTerm, string firstName, Guid requestId)
        {
            var request = new LaceRequest();

            request.LicensePlateNumberRequest(this,
                new User(userId, userName, firstName), new Context(Name, null),
                new Vehicle(string.Empty, searchTerm, string.Empty, string.Empty, string.Empty,
                    string.Empty),
                new Aggregation(requestId));

            return request;
        }

        public IEnumerable<IDataProvider> MapLaceResponses(IEnumerable<IPointToLaceProvider> dataProviders)
        {
            foreach (var dataProvider in dataProviders)
            {
                var dataFields = Mapper.Map(dataProvider, dataProvider.GetType(), typeof(IEnumerable<IDataField>)) as IEnumerable<IDataField>;
                
                yield return new DataProvider(new Guid(), DataProviderName.Ivid, "", 0, null, "", DateTime.UtcNow, dataFields);
            }
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(GetType().FullName, Id, Name);
        }
    }

    public class 
}
