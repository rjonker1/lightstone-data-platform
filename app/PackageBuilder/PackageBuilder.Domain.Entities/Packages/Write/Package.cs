﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using CommonDomain.Core;
using DataPlatform.Shared.Helpers.Extensions;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using PackageBuilder.Domain.Entities.Contracts.Actions;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.Contracts.States.Read;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.Packages.Events;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Domain.Entities.Packages.Write
{
    [DataContract]
    public class Package : AggregateBase, IPackage
    {
        [DataMember]
        public Guid Id
        {
            get { return base.Id; }
            internal set { base.Id = value; }
        }

        [DataMember]
        public int Version
        {
            get { return base.Version; }
            internal set { base.Version = value; }
        }
        [DataMember]
        public string Name { get; internal set; }
        [DataMember]
        public string Description { get; internal set; }
        [DataMember]
        public double CostOfSale { get; internal set; }
        [DataMember]
        public double RecommendedSalePrice { get; internal set; }
        [DataMember]
        public IAction Action { get; set; }
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

        public Package(Guid id, string name, State state, IEnumerable<IDataProvider> dataProviders) 
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

            DataProviders = Mapper.Map<IEnumerable<IDataProviderOverride>, IEnumerable<DataProvider>>(@event.DataProviderValueOverrides);

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

            DataProviders = Mapper.Map<IEnumerable<IDataProviderOverride>, IEnumerable<DataProvider>>(@event.DataProviderValueOverrides);

            this.Info(() => "Successfully mapped data provider overrides from PackageUpdated event");
        }

        private IPointToLaceRequest FormLaceRequest(Guid userId, string userName, string searchTerm, string firstName, Guid requestId, string accountNumber, Guid contractId, long contractVersion, Lace.Domain.Core.Requests.DeviceTypes fromDevice, string fromIpAddress, string osVersion, SystemType system)
        {
            var package = this;
            package.DataProviders = DataProviders.Where(fld => fld.DataFields.Filter(x => x.IsSelected == true).Any());

            var dataProviderNames = package.DataProviders.Select(s => s.Name).ToArray();

            //var request = new LicensePlateRequest(
            //    new User(userId, userName, firstName),new Vehicle(string.Empty,searchTerm,string.Empty,string.Empty,string.Empty,string.Empty),
            //    new Contract(contractVersion, accountNumber, contractId),
            //    new RequestPackage("License plate search", dataProviderNames, package.Id, package.Name, (long)package.DisplayVersion),
            //    new RequestContext(requestId,fromDevice,fromIpAddress,osVersion,system),
            //    DateTime.UtcNow);

            //return request;
            return null;
        }

        private IEnumerable<IDataProvider> MapLaceResponses(IEnumerable<IPointToLaceProvider> dataProviders)
        {
            if (dataProviders == null) yield break;
            foreach (var dataProvider in dataProviders.Where(x => x.Handled))
            {
                var laceResponse = Mapper.Map<IPointToLaceProvider, DataProvider>(dataProvider);
                var response = (IDataProvider)Mapper.Map(laceResponse, DataProviders.FirstOrDefault(x => x.Name == laceResponse.Name), typeof(IDataProvider), typeof(DataProvider));
                if (response.DataFields.Any())
                    yield return response;
            }
        }

        public IEnumerable<IDataProvider> Execute(IEntryPoint entryPoint, Guid userId, string userName,
            string searchTerm, string firstName, Guid requestId, string accountNumber, Guid contractId,
            long contractVersion, DeviceTypes fromDevice, string fromIpAddress, string osVersion, SystemType system)
        {
            var request = FormLaceRequest(userId, userName, searchTerm, firstName, requestId, accountNumber, contractId,
                contractVersion, fromDevice, fromIpAddress, osVersion, system);
            var responses = entryPoint.GetResponsesFromLace(new[] {request});

            return MapLaceResponses(responses).ToList();
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(GetType().FullName, Id, Name);
        }
    }
}
