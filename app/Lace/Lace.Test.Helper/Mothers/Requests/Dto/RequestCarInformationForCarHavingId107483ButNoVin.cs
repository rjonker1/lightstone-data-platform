using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestCarInformationForCarHavingId107483ButNoVin : IHaveCarInformation
    {
        public int? CarId
        {
            get
            {
                return 107483;
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
                return null;
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
                return 2008;
            }
        }

        public int MakeId
        {
            get
            {
                return 4;
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
