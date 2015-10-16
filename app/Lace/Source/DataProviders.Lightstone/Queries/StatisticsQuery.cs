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
        private readonly ILog _log;
        private readonly IReadOnlyRepository _repository;

        public IEnumerable<StatisticDto> Statistics { get; private set; }

        public StatisticsQuery(IReadOnlyRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetStatistics(IHaveCarInformation request)
        {
            try
            {
                Statistics = _repository.Get<StatisticDto>(StatisticDto.SelectForCarIdMakeYear, new {request.CarId, request.Year, request.MakeId});

                //Statistics = _repository.GetAll<StatisticDto>(StatisticDto.SelectAll, StatisticDto.CacheAllKey)
                //    .Where(s => (s.MetricId == (int) MetricTypes.AccidentDistribution) ||
                //                (s.MetricId == (int) MetricTypes.AmortisedValues && s.CarId == request.CarId && s.YearId == request.Year) ||
                //                (s.MetricId == (int) MetricTypes.AreaFactors) ||
                //                (s.MetricId == (int) MetricTypes.AuctionFactors && s.MakeId == request.MakeId) ||
                //                (s.MetricId == (int) MetricTypes.RepairIndex && s.YearId == request.Year) ||
                //                (s.MetricId == (int) MetricTypes.TotalSalesByAge && s.MakeId == request.MakeId) ||
                //                (s.MetricId == (int) MetricTypes.TotalSalesByGender && s.MakeId == request.MakeId) ||
                //                (RetailMetrics.Contains(s.MetricId) && s.CarId == request.CarId && s.YearId == request.Year) ||
                //                (PerformanceMetrics.Contains(s.MetricId) && s.CarId == request.CarId));

                //if (!Statistics.Any())
                //{
                //    Statistics = _repository.Get<StatisticDto>(StatisticDto.SelectForCarIdMakeYear,
                //        new {request.CarId, request.Year, request.MakeId}, StatisticDto.CacheStatisticsKey);
                //}
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Statistics data because of {0}", ex, ex.Message);
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