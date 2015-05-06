using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.UnitOfWork;
using Lace.Shared.DataProvider.Models;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_bands : Specification
    {
        private readonly IReadOnlyRepository<Band> _repository;
        private readonly IGetBands _getBands;
        private readonly IHaveCarInformation _request;

        public when_getting_bands()
        {
            _repository = new FakeBandsRepository();
            _getBands = new BandUnitOfWork(_repository);
            _request = LaceRequestCarInformationRequestBuilder.ForCarId_107483();
        }

        public override void Observe()
        {
            _getBands.GetBands(_request);
        }

        [Observation]
        public void lightstone_bands_should_exist()
        {
            _getBands.Bands.ShouldNotBeNull();
            _getBands.Bands.Count().ShouldNotEqual(0);
        }
    }
}
