using System.Linq;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Queries;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Repositories;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_bands : Specification
    {
        private readonly IReadOnlyRepository _repository;
        private readonly IGetBands _getBands;
        private readonly IHaveCarInformation _request;

        public when_getting_bands()
        {
            _repository = new FakeBandsRepository();
            _getBands = new BandQuery(_repository);
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
