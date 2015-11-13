using System.Linq;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Domain;
using Lace.Toolbox.Database.Repositories;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.MmCode
{
    public class when_getting_mmcode: Specification
    {
        private readonly IReadOnlyRepository _repository;
        private readonly IGetCarInformation _getCarInformation;
        private readonly IHaveCarInformation _request;

        public when_getting_mmcode()
        {
            _request = LaceRequestCarInformationRequestBuilder.ForCarId_107483_ButNoVin();
            _repository = new FakeCarInfoRepository();
            //_vin12Repository = new FakeVin12CarInfoRepository(_request.Vin);
            _getCarInformation = new CarInformationQuery(_repository);
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
