using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Source.Lightstone.DataObjects
{
    public class SaleData : IGetSales
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public IEnumerable<Sale> Sales { get; private set; }

        private readonly IReadOnlyRepository<Sale> _repository;

        public SaleData(IReadOnlyRepository<Sale> repository)
        {
            _repository = repository;
        }

        public void GetSales(Request.ILaceRequestCarInformation request)
        {
            try
            {
                Sales = _repository.FindByCarIdAndYear(request.CarId, request.Year.HasValue ? request.Year.Value : 0);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Sales data because of {0}", ex.Message);
            }
        }
    }
}
