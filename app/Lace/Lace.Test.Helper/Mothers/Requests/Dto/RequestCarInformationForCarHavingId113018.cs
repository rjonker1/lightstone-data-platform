using Lace.Toolbox.Database.Base;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestCarInformationForCarHavingId113018 : IHaveCarInformation
    {
        public int CarId
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

        public int Year
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


        public void SetCarModelYearMake(int? carId, string model, int? year, int makeId)
        {
            //CarId = carId.HasValue ? carId.Value : 0;
            //Model = model;
            //Year = year.HasValue ? year.Value : 0;
            //MakeId = makeId;
        }

        public bool HasValidCarIdAndYear()
        {
            return CarId > 0 && Year > 0;
        }

        public bool HasValidCarId()
        {
            return CarId > 0;
        }
    }
}
