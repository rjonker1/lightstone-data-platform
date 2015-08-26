using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Domain.DataProviders.Rgt.UnitOfWork
{
    public class CarSpecificationsUnitOfWork : IGetCarSpecifications
    {
        public IEnumerable<CarSpecification> CarSpecifications { get; private set; }

        private readonly ILog _log;
        private readonly IReadOnlyRepository _repository;

        public CarSpecificationsUnitOfWork(IReadOnlyRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetCarSpecifications(IHaveCarInformation request)
        {
            try
            {
                CarSpecifications = _repository.GetAll<CarSpecification>(null)
                    .Where(w => w.CarId == request.CarId);

                if (!CarSpecifications.Any())
                    CarSpecifications = _repository.Get<CarSpecification>(CarSpecification.SelectWithCarId, new {request.CarId});
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Car Specification data because of {0}", ex, ex.Message);
            }
        }
    }
}
