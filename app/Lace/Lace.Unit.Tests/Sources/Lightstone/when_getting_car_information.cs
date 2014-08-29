using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_car_information : Specification
    {
        private readonly IReadOnlyRepository<CarInfo> _repository;
        private readonly IReadOnlyRepository<CarInfo> _vin12Repository;
        private readonly IGetCarInfo _getCarInformation;
        private readonly ILaceRequestCarInformation _request;

        public when_getting_car_information()
        {
            _repository = new FakeCarInfoRepository();
            _vin12Repository = new FakeVin12CarInfoRepository();
            _getCarInformation = new CarInfoData(_repository, _vin12Repository);
            _request = LaceRequestCarInformationRequestBuilder.ForCarId_107483_ButNoVin();

        }

        public override void Observe()
        {
            _getCarInformation.GetCarInfo(_request);
        }

        [Observation]
        public void lightstone_car_information_must_be_valid()
        {
            _getCarInformation.Cars.ShouldNotBeNull();
            _getCarInformation.Cars.FirstOrDefault().CarId.ShouldEqual(_request.CarId.Value);
        }
    }
}
