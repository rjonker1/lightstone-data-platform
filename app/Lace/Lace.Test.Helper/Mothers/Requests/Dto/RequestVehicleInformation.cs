using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestVehicleInformation : IHaveVehicle
    {
        public static IHaveVehicle WithLicensePlate(string licensePlate)
        {
            var vehicle = new RequestVehicleInformation();
            vehicle.SetLicenseNo(licensePlate);
            return vehicle;
        }

        public static IHaveVehicle WithVin(string vinumber)
        {
            var vehicle = new RequestVehicleInformation();
            vehicle.SetVinNumber(vinumber);
            return vehicle;
        }

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
            set;
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

        private RequestVehicleInformation()
        {
            //Vin = "SB1KV58E40F039277";
            //LicenceNo = "XMC167GP";
            //LicenceNo = "DD14HPGP";
        }
    }
}
