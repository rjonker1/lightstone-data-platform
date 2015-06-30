using System.Linq;
using Lace.Caching.BuildingBlocks.Handlers;
using Lace.Caching.BuildingBlocks.Repository;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.Caching;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Caching
{
    public class when_adding_bands_to_the_cache : Specification
    {
        private readonly IHandleClearingData _clearing;
        private readonly IHandleRefreshingData _refreshing;
        private readonly ICacheRepository _repository;
        private readonly Band _band;
        private readonly IReadOnlyRepository _readRepository;

        public when_adding_bands_to_the_cache()
        {
            _repository = new CacheDataRepository();
            _band = new Band();
            _clearing = new ClearData(_repository);
            _readRepository = new DataProviderRepository();
        }

        public override void Observe()
        {
            _clearing.Handle();
            _band.AddToCache(_repository);
        }

        [Observation]
        public void then_bands_should_exist_in_the_cache()
        {
            var bands = _readRepository.GetAll<Band>(null);
            bands.Any().ShouldBeTrue();

            var band = bands.Where(b => b.Band_ID == 55);
            band.ShouldNotBeNull();
            band.FirstOrDefault().BandName.ShouldNotBeEmpty();
        }
    }
}
