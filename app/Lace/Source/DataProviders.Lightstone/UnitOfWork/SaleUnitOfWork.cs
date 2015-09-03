using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

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
                    _repository.GetAll<Sale>(sale => sale.Car_ID == request.CarId && sale.Year_ID == request.Year)
                        .OrderByDescending(o => o.SaleDateTime)
                        .Take(5);

                if (!Sales.Any())
                {
                    Sales = _repository.Get<Sale>(Sale.SelectTopFiveSalesForCarIdAndYear, new {request.CarId, request.Year});
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Sales data because of {0}", ex, ex.Message);
                throw;
            }
        }
    }
}
