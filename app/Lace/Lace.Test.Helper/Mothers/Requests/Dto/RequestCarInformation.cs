using Lace.Request;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestCarInformation : ILaceRequestCarInformation
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
                return "SB1KV58E40F039277";
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
    }
}
