using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestVehicleInformation : IProvideVehicleInformationForRequest
    {
        public string EngineNo
        {
            get
            {
                return null;
            }
        }

        public string VinOrChassis
        {
            get
            {
                return null;
            }
        }

        public string Make
        {
            get
            {
                return null;
            }
        }

        public string RegisterNo
        {
            get
            {
                return null;
            }
        }

        public string LicenceNo
        {
            get
            {
                return "XMC167GP";
            }
        }

        public string Vin
        {
            get { return "SB1KV58E40F039277"; }
        }
    }
}
