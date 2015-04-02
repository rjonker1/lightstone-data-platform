using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestVehicleInformation : IHaveVehicle
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
            get;
            private set;
            //get
            //{
            //    return "XMC167GP";
            //}
        }

        public string Vin
        {
            get;
            private set;
            //get { return "SB1KV58E40F039277"; }
        }


        public void SetLicenseNo(string licenceNo)
        {
            LicenceNo = licenceNo;
        }

        public void SetMake(string make)
        {
            throw new System.NotImplementedException();
        }

        public void SetVinNumber(string vinNumber)
        {
            Vin = vinNumber;
        }

        public RequestVehicleInformation()
        {
            Vin = "SB1KV58E40F039277";
            LicenceNo = "XMC167GP";
        }
    }
}
