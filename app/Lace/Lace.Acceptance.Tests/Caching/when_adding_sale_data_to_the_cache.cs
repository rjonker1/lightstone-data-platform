using System;
using System.Linq;
using Lace.Caching.BuildingBlocks.Handlers;
using Lace.Caching.BuildingBlocks.Repository;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Shared.DataProvider.Contracts;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Caching
{
    public class when_adding_sale_data_to_the_cache : Specification
    {
        private readonly IHandleClearingData _clearing;
        private readonly IHandleRefreshingData _refreshing;
        private readonly ICacheRepository _repository;
        private readonly Sale _sale;
        private readonly IReadOnlyRepository _readRepository;
        private readonly int CarId = 107483;
        private readonly int Year = 2008;

        public when_adding_sale_data_to_the_cache()
        {
            _repository = new CacheDataRepository(
                ConnectionFactory.ForAutoCarStatsDatabase());
            _sale = new Sale();
            _clearing = new ClearData(_repository);
            _readRepository = new DataProviderRepository(ConnectionFactory.ForAutoCarStatsDatabase());

        }

        public override void Observe()
        {
            _clearing.Handle();
        }

        [Observation]
        public void then_sale_data_should_exist_in_the_cache()
        {
            _sale.AddToCache(_repository);
            var sales =
                _readRepository.GetAll<Sale>(Sale.SelectAllSales)
                    .Where(w => w.Car_ID == CarId && w.Year_ID == Year)
                    .OrderByDescending(o => o.SaleDateTime)
                    .Take(5);

            sales.Any().ShouldBeTrue();
            sales.Count().ShouldEqual(5);
        }

        [Observation]
        public void then_sale_data_should_be_able_to_be_added_to_the_cache()
        {
            var sales = _readRepository.Get<Sale>(Sale.SelectTopFiveSalesForCarIdAndYear, new { CarId, Year });
            sales.Any().ShouldBeTrue();
            sales.Count().ShouldEqual(5);
        }
    }
}