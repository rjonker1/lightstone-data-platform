using System.Linq;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Toolbox.Database.Domain
{
    public class GetCarInformation : IRetrieveCarInformation
    {
        private readonly IQueryCarInformation _queryCarInformation;
        private readonly IReadOnlyRepository _repository;
        private readonly int _year;

        private GetCarInformation(IQueryCarInformation queryCarInformation)
        {
            _queryCarInformation = queryCarInformation;
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

        public GetCarInformation(string vinNumber, IQueryCarInformation queryCarInformation) : this(queryCarInformation)
        {
           // _repository = repository;
            CarInformationRequest = new CarInformationRequest(vinNumber);
        }

        public GetCarInformation(int carId, int year, IQueryCarInformation queryCarInformation) : this(queryCarInformation)
        {
          //  _repository = repository;
            _year = year;
            CarInformationRequest = new CarInformationRequest(carId, year);
        }

        public GetCarInformation(int carId, IQueryCarInformation queryCarInformation)
            : this(queryCarInformation)
        {
          //  _repository = repository;
            CarInformationRequest = new CarInformationRequest(carId);
        }

        //public IRetrieveCarInformation SetupDataSources()
        //{
        //    _getCarInformation = new CarInformationQueryFactory(_repository).Build(); //new CarInformationQuery(_repository);
        //    return this;
        //}

        public IRetrieveCarInformation BuildCarInformation()
        {
            IsSatisfied = _queryCarInformation != null && _queryCarInformation.Cars != null && _queryCarInformation.Cars.Any() && _queryCarInformation.Cars.FirstOrDefault() != null;
            CarInformationDto = IsSatisfied ? _queryCarInformation.Cars.FirstOrDefault().SetYear(_year) : new CarInformationDto();
            return this;
        }

        public IRetrieveCarInformation GenerateData()
        {
            _queryCarInformation.Get(CarInformationRequest);
            return this;
        }

        public IRetrieveCarInformation BuildCarInformationRequest()
        {
            if (CarInformationDto == null) return this;

            CarInformationRequest.SetCarModelYearMake(CarInformationDto.CarId, CarInformationDto.CarModel, CarInformationDto.Year, CarInformationDto.MakeId);
            return this;
        }

        public bool IsSatisfied { get; private set; }
        public CarInformationDto CarInformationDto { get; private set; }
        public IHaveCarInformation CarInformationRequest { get; private set; }
    }
}
