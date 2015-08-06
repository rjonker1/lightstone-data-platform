using Castle.MicroKernel.SubSystems.Conversion;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;

namespace Lace.CrossCutting.DataProvider.Car.Infrastructure.Dto
{
    public class CarInformationRequest : IHaveCarInformation
    {
        public CarInformationRequest()
        {

        }

        public CarInformationRequest(string vin)
        {
            Vin = vin;
        }

        public CarInformationRequest(int carId, int year)
        {
            CarId = carId;
            Year = year;
        }

        public CarInformationRequest(int carId)
        {
            CarId = carId;
        }

        public CarInformationRequest(int? carId, string make, string model, string vin, string userName, string password,
            int? year, int makeId, bool isVin12)
        {
            CarId = carId.HasValue ? carId.Value : 0;
            Make = make;
            Model = model;
            Vin = vin;
            Username = userName;
            Password = password;
            Year = year.HasValue ? year.Value : 0;
            MakeId = makeId;
            IsVin12 = isVin12;
        }

        public void SetCarModelYearMake(int? carId, string model, int? year, int makeId)
        {
            CarId = carId.HasValue ? carId.Value : 0;
            Model = model;
            Year = year.HasValue ? year.Value : 0;
            MakeId = makeId;
        }

        public bool HasValidCarIdAndYear()
        {
            return CarId > 0 && Year > 0;
        }

        public bool HasValidCarId()
        {
            return CarId > 0;
        }

        public int CarId { get; private set; }

        public string Make { get; private set; }

        public string Model { get; private set; }

        public string Vin { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public int Year { get; private set; }

        public int MakeId { get; private set; }

        public bool IsVin12 { get; private set; }
       
    }
}
