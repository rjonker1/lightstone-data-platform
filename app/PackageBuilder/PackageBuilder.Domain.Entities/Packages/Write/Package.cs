using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using CommonDomain.Core;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.Contracts.States.Read;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.Packages.Events;
using PackageBuilder.Domain.Entities.Requests;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

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
        public decimal CostOfSale { get; internal set; }
        [DataMember]
        public decimal RecommendedSalePrice { get; internal set; }
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
        public Package(Guid id, string name, IEnumerable<IDataProvider> dataProviders)
            : this(id)
        {
            Id = id;
            Name = name;
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

        public Package(Guid id, string name, string description, IEnumerable<Industry> industries, decimal costPrice, decimal salePrice, State state, decimal displayVersion, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProviderOverride> dataProviders)
            : this(id)
        {
            RaiseEvent(new PackageCreated(id, name, description, costPrice, salePrice, industries, state, displayVersion, owner, createdDate, editedDate, dataProviders));
        }

        public void CreatePackageRevision(Guid id, string name, string description, decimal costPrice, decimal salePrice, string notes, IEnumerable<Industry> industries, State state, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProviderOverride> dataProviders)
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

            this.Info(() => "Attempting to map data provider overrides from PackageCreated event. TimeStamp: {0}".FormatWith(DateTime.UtcNow));

            DataProviders = Mapper.Map<IEnumerable<IDataProviderOverride>, IEnumerable<DataProvider>>(@event.DataProviderValueOverrides);

            this.Info(() => "Successfully mapped data provider overrides from PackageCreated event. TimeStamp: {0}".FormatWith(DateTime.UtcNow));
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

            this.Info(() => "Attempting to map data provider overrides from PackageUpdated event. TimeStamp: {0}".FormatWith(DateTime.UtcNow));

            DataProviders = Mapper.Map<IEnumerable<IDataProviderOverride>, IEnumerable<DataProvider>>(@event.DataProviderValueOverrides);

            this.Info(() => "Successfully mapped data provider overrides from PackageUpdated event. TimeStamp: {0}".FormatWith(DateTime.UtcNow));
        }

        private IPointToLaceRequest FormLaceRequest(Guid userId, string userName, string firstName, Guid requestId, string accountNumber,
            Guid contractId, long contractVersion, DeviceTypes fromDevice, string fromIpAddress, string osVersion, SystemType system,
            IEnumerable<RequestFieldDto> requestFieldsDtos, double packageCostPrice, double packageRecommendedPrice, bool hasConsent)
        {
            if (DataProviders == null)
                return null;

            var dataProviders = DataProviders;
            if (!hasConsent)
                dataProviders = DataProviders.Where(dp => !dp.RequiresConsent);

            dataProviders = dataProviders.Where(fld => fld.DataFields.Filter(x => x.IsSelected == true).Any());
            var laceProviders = new List<IAmDataProvider>();
            var fields = Mapper.Map<IEnumerable<RequestFieldDto>, IEnumerable<DataField>>(requestFieldsDtos);

            var user = new User(userId, userName, firstName);
            var requestTypes = new RequestTypeBuilder();

            foreach (var dataProvider in dataProviders.ToList())
            {
                //var selectedfields = dataProvider.RequestFields.Filter(x => x.IsSelected == true); // todo: Validate & compare to api request fields 
                var requestFields = Mapper.Map<IEnumerable<IDataField>, IEnumerable<IAmRequestField>>(fields);
                laceProviders.Add(new LaceDataProvider(dataProvider.Name, requestFields, dataProvider.CostOfSale, RecommendedSalePrice, user, Name,
                    requestTypes, CriticalDataProviders.Find(dataProvider.Name)));
            }

            var request = new LaceRequest(
                user,
                new Contract(contractVersion, accountNumber, contractId),
                new RequestPackage(laceProviders.ToArray(), Id, Name, (long) DisplayVersion, packageCostPrice, packageRecommendedPrice),
                new RequestContext(requestId, fromDevice, fromIpAddress, osVersion, system),
                DateTime.UtcNow);

            return request;
        }

        public IEnumerable<IDataProvider> MapLaceResponses(IEnumerable<IPointToLaceProvider> dataProviders, Guid requestId)
        {
            if (dataProviders == null) yield break;

            this.Info(() => "Map LACE Response Initialized for {0}, TimeStamp: {1}".FormatWith(requestId, DateTime.UtcNow));
            foreach (var dataProvider in dataProviders.Where(x => x.Handled))
            {
                if(dataProvider.HasCriticalFailure)
                    throw new LightstoneAutoException(dataProvider.CriticalFailureMessage);

                var laceResponse = Mapper.Map<IPointToLaceProvider, DataProvider>(dataProvider);
                Mapper.Map(laceResponse, DataProviders.FirstOrDefault(x => x.Name == laceResponse.Name), typeof(IDataProvider), typeof(DataProvider));

                if (laceResponse.DataFields.Any())
                    yield return laceResponse;
            }
            this.Info(() => "Map LACE Response Completed for {0}, TimeStamp: {1}".FormatWith(requestId, DateTime.UtcNow));
        }

        public IEnumerable<IDataProvider> Execute(IEntryPoint entryPoint, Guid userId, string userName,
            string firstName, Guid requestId, string accountNumber, Guid contractId,
            long contractVersion, DeviceTypes fromDevice, string fromIpAddress, string osVersion, SystemType system,
            IEnumerable<RequestFieldDto> requestFieldsDtos, double packageCostPrice, double packageRecommendedPrice, bool hasConsent)
        {
            this.Info(() => "Form LACE Request Initialized for {0}, TimeStamp: {1}".FormatWith(requestId, DateTime.UtcNow));
            var request = FormLaceRequest(userId, userName, firstName, requestId, accountNumber, contractId,
                contractVersion, fromDevice, fromIpAddress, osVersion, system, requestFieldsDtos, packageCostPrice, packageRecommendedPrice, hasConsent);
            this.Info(() => "Form LACE Request Completed for {0}, TimeStamp: {1}".FormatWith(requestId, DateTime.UtcNow));

            if (request == null)
                throw new LightstoneAutoException(string.Format("Request cannot be built to Contract with Id {0}", contractId));

            this.Info(() => "EntryPoint Get LACE Response Initialized for {0}, TimeStamp: {1}".FormatWith(requestId, DateTime.UtcNow));
            var responses = entryPoint.GetResponsesFromLace(new[] { request });
            this.Info(() => "EntryPoint Get LACE Response Completed for {0}, TimeStamp: {1}".FormatWith(requestId, DateTime.UtcNow));

            return MapLaceResponses(responses, requestId).ToList();
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(GetType().FullName, Id, Name);
        }
    }
}
