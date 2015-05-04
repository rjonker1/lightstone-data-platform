using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using DataProviderName = DataPlatform.Shared.Enums.DataProviderName;

namespace PackageBuilder.Domain.Entities.Requests
{
    public class VechicleRequest : IPointToLaceRequest
    {

        public VechicleRequest(IHaveUser user, IHaveContract contract,
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
        public RequestContext(Guid requestId, Lace.Domain.Core.Requests.DeviceTypes fromDevice, string fromIpAddress, string osVersion, Lace.Domain.Core.Requests.SystemType system)
        {
            RequestId = requestId;
            FromDeviceType = fromDevice;
            FromIpAddress = fromIpAddress;
            OsVersion = osVersion;
            System = system;
        }

        public Lace.Domain.Core.Requests.DeviceTypes FromDeviceType { get; private set; }

        public string FromIpAddress { get; private set; }

        public string OsVersion { get; private set; }

        public Guid RequestId { get; private set; }

        public Lace.Domain.Core.Requests.SystemType System { get; private set; }
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

    //TODO: this needs some work. Some confusion about the requests to be sent to lace...
    public class LaceDataProvider : IAmDataProvider
    {
        public DataProviderName Name { get; private set; }
        //public IEnumerable<IAmRequestField> RequestFields { get; private set; }
        public decimal CostPrice { get; private set; }
        public decimal RecommendedPrice { get; private set; }

        public LaceDataProvider(DataProviderName name, IEnumerable<IAmRequestField> requestFields, decimal costPrice, decimal recommendedPrice,
            IHaveUser user, string packageName)
        {
            Name = name;
            Request = new[] {RequestTypes.FirstOrDefault(w => w.Key == name).Value(requestFields.ToList(), user, packageName)};
            CostPrice = costPrice;
            RecommendedPrice = recommendedPrice;
        }

        public ICollection<IAmDataProviderRequest> Request { get; private set; }

        private IEnumerable<KeyValuePair<DataProviderName, Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest>>>
            RequestTypes
        {
            get
            {
                return new Dictionary<DataProviderName, Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest>>()
                {
                    {
                        DataProviderName.Ivid, _ivid
                    },
                    {
                        DataProviderName.LightstoneAuto, _lightstoneAuto
                    },
                    {
                        DataProviderName.IvidTitleHolder, _ividTitleHolder
                    },
                    {
                        DataProviderName.Rgt, _rgt
                    }
                    ,
                    {
                        DataProviderName.RgtVin, _rgtVin
                    }
                };
            }
        }

        private readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> _ivid =
            (requests, user, packageName) =>
                new IvidLaceRequest(requests, packageName, user);

        private readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> _lightstoneAuto =
            (requests, user, packageName) =>
                new LightstoneAutoLaceReqeust(requests);

        private readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> _ividTitleHolder =
            (requests, user, packageName) =>
                new IvidTitleHolderLaceRequest(requests, user);

        private readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> _rgt =
            (requests, user, packageName) =>
                new RgtLaceRequest(requests);

        private readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> _rgtVin =
            (requests, user, packageName) =>
                new RgtVinLaceReqeust(requests);
    }

    public class RequestPackage : IHavePackageForRequest
    {
        public RequestPackage(string action, IAmDataProvider[] dataProviders, Guid id, string name, long version)
        {
            Action = action;
            DataProviders = dataProviders;
            Id = id;
            Name = name;
            Version = version;
        }

        public string Action { get; private set; }

        public Guid Id { get; private set; }

        public IAmDataProvider[] DataProviders { get; private set; }
        public string Name { get; private set; }

        public long Version { get; private set; }
    }
    
}