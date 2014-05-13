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
                    ApplicantName = _request.UserName ?? string.Empty,
                    EngineNo = _request.EngineNo ?? string.Empty,
                    HpiRequestReference = Guid.NewGuid().ToString().Split('-')[0],
                    Label = _request.Product ?? string.Empty,
                    LicenceNo = _request.LicenceNo ?? string.Empty,
                    Make = _request.Make ?? string.Empty,
                    ReasonForApplication = _request.ReasonForApplication ?? string.Empty,
                    RegisterNo = _request.RegisterNo ?? string.Empty,
                    VinOrChassis = _request.VinOrChassis ?? string.Empty
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
