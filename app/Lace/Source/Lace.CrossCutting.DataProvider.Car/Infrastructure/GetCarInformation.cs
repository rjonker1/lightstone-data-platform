using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Infrastructure.Dto;
using Lace.CrossCutting.DataProvider.Car.UnitOfWork;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.CrossCutting.DataProvider.Car.Infrastructure
{
    public class GetCarInformation : IRetrieveCarInformation
    {
        public bool IsSatisfied { get; private set; }
        public CarInformation CarInformation { get; private set; }
        public IHaveCarInformation CarInformationRequest { get; private set; }

        private IGetCarInformation _getCarInformation;
        private readonly IReadOnlyRepository _repository;
        private readonly int _year;

        private GetCarInformation()
        {
            
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
            _getCarInformation = new CarInformationWorker(_repository);
            return this;
        }

        public IRetrieveCarInformation BuildCarInformation()
        {
            IsSatisfied = _getCarInformation.Cars.Any() && _getCarInformation.Cars.FirstOrDefault() != null;
            CarInformation = IsSatisfied ? _getCarInformation.Cars.FirstOrDefault().SetYear(_year) : new CarInformation();
            return this;
        }

        public IRetrieveCarInformation GenerateData()
        {
            _getCarInformation.GetCarInformation(CarInformationRequest);
            return this;
        }

        public IRetrieveCarInformation BuildCarInformationRequest()
        {
            if (CarInformation == null) return this;

            CarInformationRequest.SetCarModelYearMake(CarInformation.CarId, CarInformation.CarModel, CarInformation.Year, CarInformation.MakeId);
            return this;
        }
    }
}
