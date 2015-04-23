using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Dto
{
    public class IvidRequestMessage
    {
        public HpiStandardQueryRequest HpiQueryRequest { get; private set; }

        private readonly IHaveUser _user;
        private readonly IHaveVehicle _vehicle;

        public IvidRequestMessage(IPointToVehicleRequest request)
        {
            _user = request.User;
            _vehicle = request.Vehicle;
            BuildRequest(request.Package.Name);
        }

        private void BuildRequest(string packageName)
        {
            HpiQueryRequest = new HpiStandardQueryRequest()
            {
                ApplicantName = _user.UserName ?? string.Empty,
                EngineNo = _vehicle.EngineNo ?? string.Empty,
                HpiRequestReference = Guid.NewGuid().ToString().Split('-')[0],
                Label = packageName ?? string.Empty,
                LicenceNo = _vehicle.LicenceNo ?? string.Empty,
                Make = _vehicle.Make ?? string.Empty,
                ReasonForApplication = string.Empty,
                RegisterNo = _vehicle.RegisterNo ?? string.Empty,
                VinOrChassis = _vehicle.VinOrChassis ?? string.Empty
            };
        }
    }
}
