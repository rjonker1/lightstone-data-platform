using Lace.Request;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestCarInformationForCarHavingId113018 : IProvideCarInformationForRequest
    {
        public int? CarId
        {
            get
            {
                return 113018;
            }
        }

        public string Make
        {
            get
            {
                return "45";
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
                return "KMHTC61DVDU136718";
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
                return 2013;
            }
        }

        public int MakeId
        {
            get
            {
                return 45;
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
