using System.Linq;
using Lace.Caching.BuildingBlocks.Handlers;
using Lace.Caching.BuildingBlocks.Repository;
using Lace.Domain.Core.Contracts.Caching;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Caching
{
    public class when_refreshing_objects_in_the_cache : Specification
    {
        private readonly IHandleClearingData _clearing;
        private readonly IHandleRefreshingData _refreshing;
        private readonly ICacheRepository _repository;
        private readonly IReadOnlyRepository _readRepository;

        public when_refreshing_objects_in_the_cache()
        {
            _repository = new CacheDataRepository();
            _readRepository = new DataProviderRepository();

            _clearing = new ClearData(_repository);
            _refreshing = new RefreshData(_repository);
        }

        public override void Observe()
        {
        }

        [Observation]
        public void then_all_keys_in_the_cache_should_be_flushed()
        {
            //_clearing.Handle();

            //var bands = _repository.Get<Band>(Band.CacheAllKey);
            //bands.Count().ShouldEqual(0);

            //var carInfo = _repository.Get<CarInformationDto>(CarInformationDto.CacheAllWithCarIdKey);
            //carInfo.Count().ShouldEqual(0);

            //var carAllInfo = _repository.Get<CarInformationDto>(CarInformationDto.CacheAllWithValidCarIdAndYearKey);
            //carAllInfo.Count().ShouldEqual(0);

            //var carSpecs = _repository.Get<CarSpecification>(CarSpecification.CacheAllKey);
            //carSpecs.Count().ShouldEqual(0);

            //var make = _repository.Get<Make>(Make.CacheAllKey);
            //make.Count().ShouldEqual(0);

            //var metric = _repository.Get<Metric>(Metric.CacheAllKey);
            //metric.Count().ShouldEqual(0);

            //var muncip = _repository.Get<Municipality>(Municipality.CacheAllKey);
            //muncip.Count().ShouldEqual(0);

            //var sale = _repository.Get<Sale>(Sale.CacheAllKey);
            //sale.Count().ShouldEqual(0);

            //var stats = _repository.Get<StatisticDto>(StatisticDto.CacheAllKey);
            //stats.Count().ShouldEqual(0);

            //var vin = _repository.Get<Vin>(Vin.CacheAllKey);
            //vin.Count().ShouldEqual(0);
        }

        [Observation]
        public void then_all_cachable_data_should_be_cached()
        {
            _clearing.Handle();
            _refreshing.Handle();

            //var bands = _readRepository.GetAll<Band>(null);
            //bands.Count().ShouldNotEqual(0);

            var carSpecs = _readRepository.GetAll<CarSpecification>(null);
            carSpecs.Count().ShouldNotEqual(0);

            //var make = _readRepository.GetAll<Make>(null);
            //make.Count().ShouldNotEqual(0);

            //var metric = _readRepository.GetAll<Metric>(null);
            //metric.Count().ShouldNotEqual(0);

            //var muncip = _readRepository.GetAll<Municipality>(null);
            //muncip.Count().ShouldNotEqual(0);

            //var sale = _readRepository.GetAll<Sale>(null);
            //sale.Count().ShouldNotEqual(0);

            //var carInfo = _readRepository.GetAll<CarInformationDto>(CarInformationDto.SelectAllWithValidCarIdAndYear);
            //var count = carInfo.Count();
            //carInfo.Count().ShouldNotEqual(0);
        }
    }
}
