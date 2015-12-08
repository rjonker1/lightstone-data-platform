using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using CommonDomain.Core;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Helpers.Json;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Newtonsoft.Json;
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
using PackageBuilder.Domain.Entities.Requests.RequestTypes;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using Shared.Logging;

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
        public PackageEventType? PackageEventType { get; set; }
        [DataMember, JsonConverter(typeof(JsonConcreteTypeConverter<IEnumerable<Industry>>))]
        public IEnumerable<IIndustry> Industries { get; internal set; }
        [DataMember, JsonConverter(typeof(JsonConcreteTypeConverter<State>))]
        public IState State { get; internal set; }
        [DataMember]
        public decimal DisplayVersion { get; internal set; }
        [DataMember]
        public string Owner { get; internal set; }
        [DataMember]
        public DateTime CreatedDate { get; internal set; }
        [DataMember]
        public DateTime? EditedDate { get; internal set; }
        [DataMember, JsonConverter(typeof(JsonConcreteTypeConverter<IEnumerable<DataProvider>>))]
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

        public Package(Guid id, string name, string description, PackageEventType? packageEventType, IEnumerable<Industry> industries, decimal costPrice, decimal salePrice, State state, decimal displayVersion, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProviderOverride> dataProviders)
            : this(id)
        {
            RaiseEvent(new PackageCreated(id, name, description, costPrice, salePrice, packageEventType, industries, state, displayVersion, owner, createdDate, editedDate, dataProviders));
        }

        public void CreatePackageRevision(Guid id, string name, string description, decimal costPrice, decimal salePrice, string notes, PackageEventType? packageEventType, IEnumerable<Industry> industries, State state, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProviderOverride> dataProviders)
        {
            if (state.Name == StateName.Published)
                DisplayVersion = Math.Ceiling(DisplayVersion);
            else
            {
                DisplayVersion += 0.1m;
                Name = name;
            }

            RaiseEvent(new PackageUpdated(id, name, description, costPrice, salePrice, notes, packageEventType, industries, state, Version + 1, DisplayVersion, owner, createdDate, editedDate, dataProviders));
        }

        private async void Apply(PackageCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostOfSale = @event.CostPrice;
            RecommendedSalePrice = @event.SalePrice;
            Notes = @event.Notes;
            PackageEventType = @event.PackageEventType;
            Industries = @event.Industries;
            State = @event.State;
            DisplayVersion = @event.DisplayVersion;
            Owner = @event.Owner;
            CreatedDate = @event.CreatedDate;
            EditedDate = @event.EditedDate;

            this.Info(() => "Attempting to map data provider overrides from PackageCreated event. TimeStamp: {0}".FormatWith(DateTime.UtcNow));

            DataProviders = await Mapper.Map<IEnumerable<IDataProviderOverride>, Task<IEnumerable<DataProvider>>>(@event.DataProviderValueOverrides);

            this.Info(() => "Successfully mapped data provider overrides from PackageCreated event. TimeStamp: {0}".FormatWith(DateTime.UtcNow));
        }

        private async void Apply(PackageUpdated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostOfSale = @event.CostPrice;
            RecommendedSalePrice = @event.SalePrice;
            Notes = @event.Notes;
            PackageEventType = @event.PackageEventType;
            Industries = @event.Industries;
            State = @event.State;
            DisplayVersion = @event.DisplayVersion;
            Owner = @event.Owner;
            CreatedDate = @event.CreatedDate;
            EditedDate = @event.EditedDate;

            this.Info(() => "Attempting to map data provider overrides from PackageUpdated event. TimeStamp: {0}".FormatWith(DateTime.UtcNow));

            DataProviders = await Mapper.Map<IEnumerable<IDataProviderOverride>, Task<IEnumerable<DataProvider>>>(@event.DataProviderValueOverrides);

            this.Info(() => "Successfully mapped data provider overrides from PackageUpdated event. TimeStamp: {0}".FormatWith(DateTime.UtcNow));
        }

        private IPointToLaceRequest FormLaceRequest(ExecuteLaceRequest request)
        {
            if (DataProviders == null)
                return null;

            var dataProviders = DataProviders;
            if (!request.HasConsent)
                dataProviders = DataProviders.Where(dp => !dp.RequiresConsent);

            dataProviders = dataProviders.Where(fld => fld.DataFields.Filter(x => x.IsSelected == true).Any());
            var laceProviders = new List<IAmDataProvider>();
            var fields = Mapper.Map<IEnumerable<RequestFieldDto>, IEnumerable<DataField>>(request.RequestFields).ToList();

            foreach (var dataProvider in dataProviders.ToList())
            {
                //var selectedfields = dataProvider.RequestFields.Filter(x => x.IsSelected == true); // todo: Validate & compare to api request fields 
                var requestFields = Mapper.Map<IEnumerable<IDataField>, IEnumerable<IAmRequestField>>(fields);
                var dataProviderRequest = request.RequestBuilder.Build(new RequestBuilderContext(requestFields.ToArray(), request.User, Name, request.ContactNumber),
                    dataProvider.Name);
                laceProviders.Add(new LaceDataProvider(dataProvider.Name, dataProviderRequest, dataProvider.CostOfSale, RecommendedSalePrice));
            }

            var laceRequest = new LaceRequest(request.User,request.Contract,new RequestPackage(laceProviders.ToArray(), Id, Name, (long) DisplayVersion, request.CostPrice, request.RecommendedPrice),request.RequestContext,DateTime.UtcNow);

            return laceRequest;
        }

        public IEnumerable<IDataProvider> MapLaceResponses(IEnumerable<IPointToLaceProvider> dataProviders, Guid requestId)
        {
            if (dataProviders == null) yield break;

            this.Info(() => "Map LACE Response started for {0}, TimeStamp: {1}".FormatWith(requestId, DateTime.UtcNow));
            var pointToLaceProviders = dataProviders.Where(x => x.Handled).ToList();
            foreach (var dataProvider in pointToLaceProviders)
            {
                var laceResponse = Mapper.Map<IPointToLaceProvider, DataProvider>(dataProvider);
                Mapper.Map(laceResponse, DataProviders.FirstOrDefault(x => x.Name == laceResponse.Name), typeof (IDataProvider), typeof (DataProvider));

                if (laceResponse.DataFields.Any())
                    yield return laceResponse;
            }
            this.Info(() => "Map LACE Response finished for {0}, TimeStamp: {1}".FormatWith(requestId, DateTime.UtcNow));
        }

        public List<IDataProvider> Execute(IEntryPoint entryPoint, ExecuteLaceRequest request)
        {
            this.Info(() => "Form LACE Request started for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));
            var laceRequest = FormLaceRequest(request);
            this.Info(() => "Form LACE Request finished for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));

            if (laceRequest == null)
                throw new LightstoneAutoException(string.Format("Request cannot be built to Contract with Id {0}", request.ContractId));

            this.Info(() => "EntryPoint Get LACE Response started for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));
            var responses = entryPoint.GetResponses(new[] { laceRequest });
            this.Info(() => "EntryPoint Get LACE Response finished for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));

            return MapLaceResponses(responses, request.RequestId).ToList();
        }

        public async Task<List<IDataProvider>> ExecuteAsync(IEntryPointAsync entryPoint, ExecuteLaceRequest request)
        {
            this.Info(() => "Form LACE Request started for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));
            var laceRequest = FormLaceRequest(request);
            this.Info(() => "Form LACE Request finished for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));

            if (laceRequest == null)
                throw new LightstoneAutoException(string.Format("Request cannot be built to Contract with Id {0}", request.ContractId));

            this.Info(() => "EntryPoint Get LACE Response started for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));
            var responses = await entryPoint.GetResponsesAsync(new[] { laceRequest });
            this.Info(() => "EntryPoint Get LACE Response finished for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));

            return MapLaceResponses(responses, request.RequestId).ToList();
        }

        public List<IDataProvider> ExecuteWithCarId(IEntryPoint entryPoint, ExecuteLaceRequest request)
        {
            this.Info(() => "Form LACE Request started for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));
            var laceRequest = FormLaceRequest(request);
            this.Info(() => "Form LACE Request finished for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));

            if (laceRequest == null)
                throw new LightstoneAutoException(string.Format("Request cannot be built to Contract with Id {0}", request.ContractId));

            this.Info(() => "EntryPoint Get LACE Response started for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));
            var responses = entryPoint.GetResponsesForCarId(new[] { laceRequest });
            this.Info(() => "EntryPoint Get LACE Response finished for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));

            return MapLaceResponses(responses, request.RequestId).ToList();
        }

        public async Task<List<IDataProvider>> ExecuteWithCarIdAsync(IEntryPointAsync entryPoint, ExecuteLaceRequest request)
        {
            this.Info(() => "Form LACE Request started for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));
            var laceRequest = FormLaceRequest(request);
            this.Info(() => "Form LACE Request finished for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));

            if (laceRequest == null)
                throw new LightstoneAutoException(string.Format("Request cannot be built to Contract with Id {0}", request.ContractId));

            this.Info(() => "EntryPoint Get LACE Response started for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));
            var responses = await entryPoint.GetResponsesForCarIdAsync(new[] { laceRequest });
            this.Info(() => "EntryPoint Get LACE Response finished for {0}, TimeStamp: {1}".FormatWith(request.RequestId, DateTime.UtcNow));

            return MapLaceResponses(responses, request.RequestId).ToList();
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(GetType().FullName, Id, Name);
        }
    }
}
