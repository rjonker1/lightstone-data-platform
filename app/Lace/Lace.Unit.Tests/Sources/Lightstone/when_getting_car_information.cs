using System.Linq;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Factories;
using Lace.Toolbox.Database.Repositories;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_car_information : Specification
    {
        private readonly IReadOnlyRepository _repository;
        private readonly IReadOnlyRepository _vin12Repository;
        private readonly IGetCarInformation _getCarInformation;
        private readonly IHaveCarInformation _request;

        public when_getting_car_information()
        {
            _request = LaceRequestCarInformationRequestBuilder.ForCarId_107483_ButNoVin();
            _repository = new FakeCarInfoRepository();
            _vin12Repository = new FakeVin12CarInfoRepository(_request.Vin);
            _getCarInformation = new CarInformationQueryFactory(_repository).Build(); //new CarInformationQuery(_repository);
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
