using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestCarInformationForCarHavingId110490 : IHaveCarInformation
    {
        public int? CarId
        {
            get
            {
                return 110490;
            }
        }

        public string Make
        {
            get
            {
                return "4";
            }
        }

        public string Model
        {
            get
            {
               return null;
            }
        }

        public string Vin
        {
            get
            {
                return "WAUZZZ8X8CB034633";
            }
        }

        public string Username
        {
            get
            {
                return null;
            }
        }

        public string Password
        {
            get
            {
                return null;
            }
        }

        public int? Year
        {
            get
            {
                return 2012;
            }
        }

        public int MakeId
        {
            get
            {
                return 7;
            }
        }

        public bool IsVin12
        {
            get
            {
                return false;
            }

        }


        public void SetCarModelYear(int? carId, string model, int? year)
        {
            throw new System.NotImplementedException();
        }
    }
}
