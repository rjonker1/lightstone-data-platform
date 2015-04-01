using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class SaleUnitOfWork : IGetSales
    {
        private readonly ILog _log;
        public IEnumerable<Sale> Sales { get; private set; }

        private readonly IReadOnlyRepository<Sale> _repository;

        public SaleUnitOfWork(IReadOnlyRepository<Sale> repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetSales(IHaveCarInformation request)
        {
            try
            {
                Sales = _repository.FindByCarIdAndYear(request.CarId, request.Year.HasValue ? request.Year.Value : 0);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Sales data because of {0}", ex.Message);
            }
        }
    }
}
