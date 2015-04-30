using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Dto
{
    public class IvidRequestMessage
    {
        public HpiStandardQueryRequest HpiQueryRequest { get; private set; }

        private readonly IAmIvidStandardRequest _request;

        public IvidRequestMessage(IAmIvidStandardRequest request)
        {
            _request = request;
            BuildRequest();
        }

        private void BuildRequest()
        {
            HpiQueryRequest = new HpiStandardQueryRequest()
            {
                ApplicantName = GetValue(_request.ApplicantName),
                EngineNo = GetValue(_request.EngineNumber),
                HpiRequestReference = Guid.NewGuid().ToString().Split('-')[0],
                Label = GetValue(_request.Label),
                LicenceNo = GetValue(_request.LicenceNumber),
                Make = GetValue(_request.Make),
                ReasonForApplication = string.Empty,
                RegisterNo = GetValue(_request.RegisterNumber),
                VinOrChassis = GetValue(_request.VinNumber)
            };
        }

        private static string GetValue(IAmRequestField field)
        {
            return field == null ? string.Empty : string.IsNullOrEmpty(field.Field) ? string.Empty : field.Field;
        }
    }
}
