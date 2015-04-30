using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.CrossCutting.DataProvider.Car.Repositories;
using Lace.CrossCutting.DataProvider.Car.UnitOfWork;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_car_information : Specification
    {
        private readonly IReadOnlyCarRepository<CarInformation> _repository;
        private readonly IReadOnlyCarRepository<CarInformation> _vin12Repository;
        private readonly IGetCarInformation _getCarInformation;
        private readonly IHaveCarInformation _request;

        public when_getting_car_information()
        {
            _request = LaceRequestCarInformationRequestBuilder.ForCarId_107483_ButNoVin();
            _repository = new FakeCarInfoRepository();
            _vin12Repository = new FakeVin12CarInfoRepository(_request.Vin);
            _getCarInformation = new CarInformationWorker(_repository, _vin12Repository);
        }

        public override void Observe()
        {
            _getCarInformation.GetCarInformation(_request);
        }

        [Observation]
        public void lightstone_car_information_must_be_valid()
        {
            _getCarInformation.Cars.ShouldNotBeNull();
            _getCarInformation.Cars.FirstOrDefault().CarId.ShouldEqual(_request.CarId);
        }
    }
}
