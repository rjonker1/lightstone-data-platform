using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Domain.DataProviders.RgtVin.Core.Contracts;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Domain.DataProviders.RgtVin.UnitOfWork
{
    public class VehicleVinUnitOfWork : IGetVehicleFromVin
    {
        public IEnumerable<Vin> Vins { get; private set; }

        private readonly ILog _log;
        private readonly IReadOnlyRepository _repository;

        public VehicleVinUnitOfWork(IReadOnlyRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetVin(string vin)
        {
            try
            {
                Vins = _repository.GetAll<CarInformation>(CarInformation.SelectAllWithValidCarIdAndYear)
                    .Where(w => w.Vin == vin)
                    .Select(s => new Vin(s.Vin, s.CarId, s.MakeName, s.CarTypeName, s.CarModel, s.Year, s.Quarter, s.Month, s.Colour, s.Source));

                if (!Vins.Any())
                    Vins = _repository.Get<CarInformation>(CarInformation.SelectWithVin, new {@Vin = vin})
                        .Select(s => new Vin(s.Vin, s.CarId, s.MakeName, s.CarTypeName, s.CarModel, s.Year, s.Quarter, s.Month, s.Colour, s.Source));

                if (!Vins.Any())
                    Vins = _repository.Get<Vin>(Vin.SelectWithVin, new {@Vin = vin});
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Vin information because of {0}", ex, ex.Message);
            }
        }
    }
}
