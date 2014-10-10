using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.DataProviders.RgtVin.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Models;

namespace Lace.Domain.DataProviders.RgtVin.UnitOfWork
{
    public class VehicleVinUnitOfWork : IGetVehicleFromVin
    {
        public IEnumerable<Vin> Vins { get; private set; }

        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly IReadOnlyRepository<Vin> _repository;

        public VehicleVinUnitOfWork(IReadOnlyRepository<Vin> repository)
        {
            _repository = repository;
        }

        public void GetVin(string vinNumber)
        {
            try
            {
                Vins = _repository.FindWith(vinNumber);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Vin information because of {0}", ex.Message);
                throw;
            }
        }
    }
}
