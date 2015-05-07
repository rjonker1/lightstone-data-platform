using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class SaleUnitOfWork : IGetSales
    {
        private readonly ILog _log;
        public IEnumerable<Sale> Sales { get; private set; }

        private readonly IReadOnlyRepository _repository;

        public SaleUnitOfWork(IReadOnlyRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetSales(IHaveCarInformation request)
        {
            try
            {
                Sales =
                    _repository.GetAll<Sale>(Sale.SelectAllSales, Sale.CacheAllKey)
                        .Where(w => w.Car_ID == request.CarId && w.Year_ID == request.Year)
                        .OrderByDescending(o => o.SaleDateTime)
                        .Take(5);

                if (!Sales.Any())
                {
                    Sales = _repository.Get<Sale>(Sale.SelectTopFiveSalesForCarIdAndYear, new {request.CarId, request.Year}, Sale.CacheSaleKey);
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Sales data because of {0}", ex, ex.Message);
            }
        }
    }
}
