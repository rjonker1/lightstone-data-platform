using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Domain.DataProviders.Lightstone.Queries
{
    public class SaleQuery : IGetSales
    {
        private static readonly ILog Log = LogManager.GetLogger<SaleQuery>();
        public IEnumerable<Sale> Sales { get; private set; }

        private readonly IReadOnlyRepository _repository;

        public SaleQuery(IReadOnlyRepository repository)
        {
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
                Log.ErrorFormat("Error getting Sales data because of {0}", ex, ex.Message);
                throw;
            }
        }
    }
}
