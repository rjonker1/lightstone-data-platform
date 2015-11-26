using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Domain.DataProviders.Lightstone.Queries
{
    public class StatisticsQuery : IGetStatistics
    {
        private static readonly ILog Log = LogManager.GetLogger<StatisticsQuery>();
        private readonly IReadOnlyRepository _repository;

        public IEnumerable<StatisticDto> Statistics { get; private set; }

        public StatisticsQuery(IReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public void GetStatistics(IHaveCarInformation request)
        {
            try
            {
                Statistics = _repository.Get<StatisticDto>(StatisticDto.SelectForCarIdMakeYear, new {request.CarId, request.Year, request.MakeId});
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Statistics data because of {0}", ex, ex.Message);
                throw;
            }
        }

        private static readonly int[] RetailMetrics =
        {
            (int) MetricTypes.RetailPriceLow,
            (int) MetricTypes.RetailPriceHigh,
            (int) MetricTypes.RetailEstimatedPrice,
            (int) MetricTypes.RetailConfidence,
            (int) MetricTypes.TradeEstimatedPrice,
            (int) MetricTypes.TradePriceLow,
            (int) MetricTypes.TradePriceHigh,
            (int) MetricTypes.TradeConfidence
        };

        private static readonly int[] PerformanceMetrics =
        {
            (int) MetricTypes.MaxSpeed,
            (int) MetricTypes.Acceleration,
            (int) MetricTypes.KiloWatts,
            (int) MetricTypes.Torque,
            (int) MetricTypes.FuelEconomy,
            (int) MetricTypes.Co2,
        };
    }
}