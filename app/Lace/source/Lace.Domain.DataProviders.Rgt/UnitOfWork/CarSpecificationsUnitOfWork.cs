using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Shared.DataProvider.Models;

namespace Lace.Domain.DataProviders.Rgt.UnitOfWork
{
    public class CarSpecificationsUnitOfWork : IGetCarSpecifications
    {
        public IEnumerable<CarSpecification> CarSpecifications { get; private set; }

        private readonly ILog _log;
        private readonly IReadOnlyRepository<CarSpecification> _repository;

        public CarSpecificationsUnitOfWork(IReadOnlyRepository<CarSpecification> repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetCarSpecifications(IHaveCarInformation request)
        {
            try
            {
                CarSpecifications = _repository.GetAll(CarSpecification.SelectAll, CarSpecification.CacheAllKey)
                    .Where(w => w.CarId == request.CarId);

                CarSpecifications = _repository.Get(CarSpecification.CacheWithCarIdKey, new {request.CarId}, CarSpecification.CacheWithCarIdKey);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Car Specification data because of {0}", ex.Message);
                throw;
            }
        }
    }
}
