using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto
{
    public class CarInformationRequest : IProvideCarInformationForRequest
    {
        public CarInformationRequest()
        {
            
        }

        public CarInformationRequest(string vin)
        {
            Vin = vin;
        }

        public CarInformationRequest(int? carId, string make, string model, string vin, string userName, string password,
            int? year, int makeId, bool isVin12)
        {
            CarId = carId;
            Make = make;
            Model = model;
            Vin = vin;
            Username = userName;
            Password = password;
            Year = year;
            MakeId = makeId;
            IsVin12 = isVin12;
        }

        public void SetCarModelYear(int? carId, string model, int? year)
        {
            CarId = carId;
            Model = model;
            Year = year;
        }

        public int? CarId { get; private set; }

        public string Make { get; private set; }

        public string Model { get; private set; }

        public string Vin { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public int? Year { get; private set; }

        public int MakeId { get; private set; }

        public bool IsVin12 { get; private set; }
    }
}
