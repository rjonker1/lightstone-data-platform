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

        private readonly ILog _log;
        private readonly IReadOnlyRepository<Vin> _repository;

        public VehicleVinUnitOfWork(IReadOnlyRepository<Vin> repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetVin(string vin)
        {
            try
            {
                Vins = _repository.Get(Vin.GetWithVin(), new { @Vin = vin });
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Vin information because of {0}", ex.Message);
                throw;
            }
        }
    }
}
