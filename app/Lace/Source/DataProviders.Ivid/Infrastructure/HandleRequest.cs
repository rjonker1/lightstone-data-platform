using System;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure
{
    public static class HandleRequest
    {
        public static HpiStandardQueryRequest GetHpiStandardQueryRequest(IAmIvidStandardRequest request)
        {
            return new HpiStandardQueryRequest()
            {
                ApplicantName = request.ApplicantName.GetValue(),
                EngineNo = request.EngineNumber.GetValue(),
                HpiRequestReference = Guid.NewGuid().ToString().Split('-')[0],
                Label = request.Label.GetValue(),
                LicenceNo = request.LicenceNumber.GetValue(),
                Make = request.Make.GetValue(),
                ReasonForApplication = string.Empty,
                RegisterNo = request.RegisterNumber.GetValue(),
                VinOrChassis = request.VinNumber.GetValue(),
                requesterDetails = new RequesterDetailsElement
                {
                    requesterName = request.ApplicantName.GetValue(), requesterEmail = request.ApplicantName.GetValue(), requesterPhone = request.RequesterPhone.GetValue()
                }
            };
        }
    }
}