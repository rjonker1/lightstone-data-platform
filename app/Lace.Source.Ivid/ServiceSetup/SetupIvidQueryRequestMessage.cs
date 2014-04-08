using System;
using Lace.Request;
using Lace.Source.Ivid.IvidServiceReference;

namespace Lace.Source.Ivid.ServiceSetup
{
    public class SetupIvidQueryRequestMessage
    {
        public HpiStandardQueryRequest HpiQueryRequest
        {
            get;
            private set;
        }

        private readonly ILaceRequest _request;

        public SetupIvidQueryRequestMessage(ILaceRequest request)
        {
            _request = request;
            BuildStandardIvidQueryRequest();
        }

        private void BuildStandardIvidQueryRequest()
        {
            HpiQueryRequest = new HpiStandardQueryRequest()
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
}
