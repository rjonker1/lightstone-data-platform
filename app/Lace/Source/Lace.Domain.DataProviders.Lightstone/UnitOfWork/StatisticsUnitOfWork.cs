using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class StatisticsUnitOfWork : IGetStatistics
    {
        private readonly ILog _log;
        private readonly IReadOnlyRepository _repository;

        public IEnumerable<Statistic> Statistics { get; private set; }

        public StatisticsUnitOfWork(IReadOnlyRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetStatistics(IHaveCarInformation request)
        {
            try
            {
                Statistics = _repository.Get<Statistic>(Statistic.SelectForCarIdMakeYear, new {request.CarId, request.Year, request.MakeId});

                //Statistics = _repository.GetAll<Statistic>(Statistic.SelectAll, Statistic.CacheAllKey)
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
                //    Statistics = _repository.Get<Statistic>(Statistic.SelectForCarIdMakeYear,
                //        new {request.CarId, request.Year, request.MakeId}, Statistic.CacheStatisticsKey);
                //}
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Statistics data because of {0}", ex, ex.Message);
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