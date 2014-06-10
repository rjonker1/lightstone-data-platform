using System;
using Lace.Request;
using Lace.Source.Ivid.IvidServiceReference;

namespace Lace.Source.Ivid.ServiceConfig
{
    public class ConfigureIvidRequestMessage
    {
        public HpiStandardQueryRequest HpiQueryRequest
        {
            get
            {
                return new HpiStandardQueryRequest()
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
            }
        }

        private readonly ILaceRequest _request;

        public ConfigureIvidRequestMessage(ILaceRequest request)
        {
            _request = request;
        }
    }
}
