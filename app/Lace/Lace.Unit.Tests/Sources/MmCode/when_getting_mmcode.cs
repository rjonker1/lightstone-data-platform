using System.Linq;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Domain;
using Lace.Toolbox.Database.Factories;
using Lace.Toolbox.Database.Factories.CarInformation;
using Lace.Toolbox.Database.Repositories;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.MmCode
{
    public class when_getting_mmcode: Specification
    {
        private readonly IReadOnlyRepository _repository;
        private readonly IQueryCarInformation _queryCarInformation;
        private readonly IHaveCarInformation _request;

        public when_getting_mmcode()
        {
            _request = LaceRequestCarInformationRequestBuilder.ForCarId_107483_ButNoVin();
            _repository = new FakeCarInfoRepository();
            //_vin12Repository = new FakeVin12CarInfoRepository(_request.Vin);
            _queryCarInformation = new CarInformationQueryFactory(_repository).Build(); //new CarInformationQuery(_repository);
        }

        public override void Observe()
        {
            _queryCarInformation.Get(_request);
        }

        [Observation]
        public void lightstone_car_information_must_be_valid()
        {
            _queryCarInformation.Cars.ShouldNotBeNull();
            _queryCarInformation.Cars.FirstOrDefault().CarId.ShouldEqual(_request.CarId);
        }
    }
}
