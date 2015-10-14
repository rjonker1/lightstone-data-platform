using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using DataProviderName = DataPlatform.Shared.Enums.DataProviderName;

namespace PackageBuilder.Domain.Entities.Requests
{
    public class LaceRequest : IPointToLaceRequest
    {

        public LaceRequest(IHaveUser user, IHaveContract contract,
            IHavePackageForRequest package, IHaveRequestContext context, DateTime requestDate)
        {
            User = user;
            Contract = contract;
            Package = package;
            Request = context;
            RequestDate = requestDate;
        }

        public IHaveUser User { get; private set; }

        public IHaveContract Contract { get; private set; }

        public IHavePackageForRequest Package { get; private set; }

        public IHaveRequestContext Request { get; private set; }

        public DateTime RequestDate { get; private set; }

    }

    public class User : IHaveUser
    {

        public User(Guid userId, string userName, string firstName)
        {
            UserFirstName = firstName;
            UserId = userId;
            UserName = userName;
        }

        public string UserFirstName { get; private set; }

        public Guid UserId { get; private set; }

        public string UserName { get; private set; }
    }

    public class RequestContext : IHaveRequestContext
    {
        public RequestContext(Guid requestId, DeviceTypes fromDevice, string fromIpAddress, string osVersion, SystemType system)
        {
            RequestId = requestId;
            FromDeviceType = fromDevice;
            FromIpAddress = fromIpAddress;
            OsVersion = osVersion;
            System = system;
        }

        public DeviceTypes FromDeviceType { get; private set; }

        public string FromIpAddress { get; private set; }

        public string OsVersion { get; private set; }

        public Guid RequestId { get; private set; }

        public SystemType System { get; private set; }
    }

    public class Contract : IHaveContract
    {
        public Contract(long contractVersion, string accountNumber, Guid contractId)
        {
            ContractVersion = contractVersion;
            AccountNumber = accountNumber;
            ContractId = contractId;
        }

        public string AccountNumber { get; private set; }

        public Guid ContractId { get; private set; }

        public long ContractVersion { get; private set; }
    }

    public class LaceDataProvider : IAmDataProvider
    {
        public LaceDataProvider(DataProviderName name, IEnumerable<IAmRequestField> requestFields, decimal costPrice, decimal recommendedPrice,
            IHaveUser user, string packageName, IBuildRequestTypes requestTypes)
        {
            Name = name;
            var requestType = requestTypes.RequestTypes.FirstOrDefault(w => w.Key == name);
            if (requestType.Value != null)
                Request = new[] {requestType.Value(requestFields.ToList(), user, packageName)};
            CostPrice = costPrice;
            RecommendedPrice = recommendedPrice;
        }

        public DataProviderName Name { get; private set; }
        public ICollection<IAmDataProviderRequest> Request { get; private set; }
        public decimal CostPrice { get; private set; }
        public decimal RecommendedPrice { get; private set; }

        public IBillStateIndicator BillablleState
        {
            get { return DataProviderBillableState.GetBillStateForDataProvider(Name); }
        }


    }

    public class RequestPackage : IHavePackageForRequest
    {
        public RequestPackage(IAmDataProvider[] dataProviders, Guid id, string name, long version, double packageCostPrice,
            double packageRecommendedPrice)
        {

            DataProviders = dataProviders;
            Id = id;
            Name = name;
            Version = version;
            PackageCostPrice = packageCostPrice;
            PackageRecommendedPrice = packageRecommendedPrice;
        }

        public Guid Id { get; private set; }

        public IAmDataProvider[] DataProviders { get; private set; }
        public string Name { get; private set; }
        public double PackageCostPrice { get; private set; }
        public double PackageRecommendedPrice { get; private set; }
        public long Version { get; private set; }
    }

    public class DataProviderBillState : IBillStateIndicator
    {
        public DataProviderBillState(DataProviderNoRecordState noRecordState)
        {
            NoRecordState = noRecordState;
        }

        public DataProviderNoRecordState NoRecordState { get; private set; }

    }

    public class DataProviderBillableState
    {
        public static IBillStateIndicator GetBillStateForDataProvider(DataProviderName dataProvider)
        {
            var nonBillable = BillStates.Where(w => w.Key == dataProvider).ToList();
            return !nonBillable.Any() ? new DataProviderBillState(DataProviderNoRecordState.Billable) : nonBillable.FirstOrDefault().Value();
        }


        private static readonly List<KeyValuePair<DataProviderName, Func<IBillStateIndicator>>> BillStates = new List
            <KeyValuePair<DataProviderName, Func<IBillStateIndicator>>>()
        {
            new KeyValuePair<DataProviderName, Func<IBillStateIndicator>>(DataProviderName.LSAutoCarStats_I_DB,
                () => new DataProviderBillState(DataProviderNoRecordState.NonBillable)),
            new KeyValuePair<DataProviderName, Func<IBillStateIndicator>>(DataProviderName.LSAutoSpecs_I_DB,
                () => new DataProviderBillState(DataProviderNoRecordState.NonBillable)),
            new KeyValuePair<DataProviderName, Func<IBillStateIndicator>>(DataProviderName.LSAutoVINMaster_I_DB,
                () => new DataProviderBillState(DataProviderNoRecordState.NonBillable))
        };
    }
}