using System.Linq;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Toolbox.Database.Domain
{
    public class GetCarInformation : IRetrieveCarInformation
    {
        public bool IsSatisfied { get; private set; }
        public CarInformationDto CarInformationDto { get; private set; }
        public IHaveCarInformation CarInformationRequest { get; private set; }

        private IGetCarInformation _getCarInformation;
        private readonly IReadOnlyRepository _repository;
        private readonly int _year;

        public GetCarInformation()
        {
            
        }

        private GetCarInformation(bool empty)
        {
            CarInformationDto = new CarInformationDto();
            CarInformationRequest = new CarInformationRequest(0, "", "", "", "", "", 0, 0, false);
        }

        public static GetCarInformation Empty()
        {
            return new GetCarInformation(true);
        }

        public GetCarInformation(string vinNumber, IReadOnlyRepository repository)
        {
            _repository = repository;
            CarInformationRequest = new CarInformationRequest(vinNumber);
        }

        public GetCarInformation(int carId, int year, IReadOnlyRepository repository)
        {
            _repository = repository;
            _year = year;
            CarInformationRequest = new CarInformationRequest(carId, year);
        }

        public GetCarInformation(int carId, IReadOnlyRepository repository)
        {
            _repository = repository;
            CarInformationRequest = new CarInformationRequest(carId);
        }

        public IRetrieveCarInformation SetupDataSources()
        {
            _getCarInformation = new CarInformationQuery(_repository);
            return this;
        }

        public IRetrieveCarInformation BuildCarInformation()
        {
            IsSatisfied = _getCarInformation.Cars.Any() && _getCarInformation.Cars.FirstOrDefault() != null;
            CarInformationDto = IsSatisfied ? _getCarInformation.Cars.FirstOrDefault().SetYear(_year) : new CarInformationDto();
            return this;
        }

        public IRetrieveCarInformation GenerateData()
        {
            _getCarInformation.GetCarInformation(CarInformationRequest);
            return this;
        }

        public IRetrieveCarInformation BuildCarInformationRequest()
        {
            if (CarInformationDto == null) return this;

            CarInformationRequest.SetCarModelYearMake(CarInformationDto.CarId, CarInformationDto.CarModel, CarInformationDto.Year, CarInformationDto.MakeId);
            return this;
        }
    }
}
