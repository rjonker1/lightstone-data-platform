using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Dto
{
    public class IvidRequestMessage
    {
        public HpiStandardQueryRequest HpiQueryRequest { get; private set; }

        private readonly ILaceRequest _request;

        public IvidRequestMessage(ILaceRequest request)
        {
            _request = request;
        }

        public IvidRequestMessage Build()
        {
            HpiQueryRequest = new HpiStandardQueryRequest()
            {
                ApplicantName = _request.User.UserName ?? string.Empty,
                EngineNo = _request.Vehicle.EngineNo ?? string.Empty,
                HpiRequestReference = Guid.NewGuid().ToString().Split('-')[0],
                Label = _request.Context.Product ?? string.Empty,
                LicenceNo = _request.Vehicle.LicenceNo ?? string.Empty,
                Make = _request.Vehicle.Make ?? string.Empty,
                ReasonForApplication = _request.Context.ReasonForApplication ?? string.Empty,
                RegisterNo = _request.Vehicle.RegisterNo ?? string.Empty,
                VinOrChassis = _request.Vehicle.VinOrChassis ?? string.Empty
            };

            return this;
        }
    }
}
