using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Core.Lookup
{
    public static class LookupDataProviderRequest
    {
        public static IDictionary<DataProviderName, Func<ICollection<PackageBuilder.Domain.Requests.Contracts.RequestFields.IAmRequestField>, IAmDataProviderRequest>> LookupRequest = new Dictionary<DataProviderName, Func<ICollection<PackageBuilder.Domain.Requests.Contracts.RequestFields.IAmRequestField>, IAmDataProviderRequest>>()
        {
                {
                    DataProviderName.Ivid, Ivid
                } //,
                //{
                //    DataProviderName.LightstoneAuto, LightstoneAuto
                //},
                //{
                //    DataProviderName.IvidTitleHolder, IvidTitleHolder
                //},
                //{
                //    DataProviderName.Rgt, Rgt
                //}
                //,
                //{
                //    DataProviderName.RgtVin, RgtVin
                //},
                //{
                //    DataProviderName.LightstoneProperty, LightstoneProperty
                //}
            };

        private static readonly Func<ICollection<IAmRequestField>, IAmDataProviderRequest> Ivid =
           (requests) =>
               new IvidRequest(requests);


        public static
            IDictionary
                <DataProviderName, Func<ICollection<PackageBuilder.Domain.Requests.Contracts.RequestFields.IAmRequestField>, IAmDataProvider>>
            LookupProvider = new Dictionary
                <DataProviderName, Func<ICollection<PackageBuilder.Domain.Requests.Contracts.RequestFields.IAmRequestField>, IAmDataProvider>>()
            {
                {
                    DataProviderName.Ivid, IvidDataProvider
                }
            };

        private static readonly Func<ICollection<IAmRequestField>, IAmDataProvider> IvidDataProvider = (requests) => new LaceDataProvider(DataProviderName.Ivid,requests,0,0); 
    }
   

    static class RequestFieldExtensions
    {
        public static T GetRequestField<T>(this ICollection<IAmRequestField> requestFields)
        {
            return requestFields.OfType<T>().Any() ? requestFields.OfType<T>().First() : default(T);
        }
    }
    public class LaceDataProvider : IAmDataProvider
    {
        public DataProviderName Name { get; private set; }
        public ICollection<IAmDataProviderRequest> Request { get; private set; }
        public decimal CostPrice { get; private set; }
        public decimal RecommendedPrice { get; private set; }

        public LaceDataProvider(DataProviderName name, IEnumerable<IAmRequestField> requestFields, decimal costPrice, decimal recommendedPrice)
        {
            Name = name;
            Request = new[] { LookupDataProviderRequest.LookupRequest.FirstOrDefault(w => w.Key == name).Value(requestFields.ToList()) };
            CostPrice = costPrice;
            RecommendedPrice = recommendedPrice;
        }
    }

    public class IvidRequest : IAmIvidStandardRequest
    {
        public IvidRequest(ICollection<IAmRequestField> requestFields)
        {
            LicenceNumber = requestFields.GetRequestField<IAmLicenceNumberRequestField>();
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
            RegisterNumber = requestFields.GetRequestField<IAmRegisterNumberRequestField>();
            EngineNumber = requestFields.GetRequestField<IAmEngineNumberRequestField>();
            Label = requestFields.GetRequestField<IAmLabelRequestField>();
            RequesterEmail = requestFields.GetRequestField<IAmRequesterEmailRequestField>();
            RequesterName = requestFields.GetRequestField<IAmRequesterNameRequestField>();
        }


        public IAmRequesterNameRequestField RequesterName { get; private set; }

        public IAmRequesterPhoneRequestField RequesterPhone { get; private set; }

        public IAmRequesterEmailRequestField RequesterEmail { get; private set; }

        public IAmRequestReferenceRequestField RequestReference { get; private set; }

        public IAmApplicantNameRequestField ApplicantName { get; private set; }
        public IAmReasonForApplicationRequestField ReasonForApplication { get; private set; }

        public IAmLabelRequestField Label { get; private set; }

        public IAmEngineNumberRequestField EngineNumber { get; private set; }

        public IAmChassisNumberRequestField ChassisNumber { get; private set; }

        public IAmVinNumberRequestField VinNumber { get; private set; }

        public IAmLicenceNumberRequestField LicenceNumber { get; private set; }

        public IAmRegisterNumberRequestField RegisterNumber { get; private set; }

        public IAmMakeRequestField Make { get; private set; }
    }
}
