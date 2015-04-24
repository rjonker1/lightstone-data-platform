using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;
using Lace.Domain.DataProviders.Rgt.Infrastructure.SqlStatements;

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
                CarSpecifications = _repository.Get(SelectStatements.GetCarSpecifications, new {request.CarId});
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Car Specification data because of {0}", ex.Message);
                throw;
            }
        }
    }
}
