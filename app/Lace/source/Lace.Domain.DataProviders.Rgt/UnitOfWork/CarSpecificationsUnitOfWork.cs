using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;

namespace Lace.Domain.DataProviders.Rgt.UnitOfWork
{
    public class CarSpecificationsUnitOfWork : IGetCarSpecifications
    {
        public IEnumerable<CarSpecification> CarSpecifications { get; private set; }

        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly IReadOnlyRepository<CarSpecification> _repository;

        public CarSpecificationsUnitOfWork(IReadOnlyRepository<CarSpecification> repository)
        {
            _repository = repository;
        }

        public void GetCarSpecifications(IProvideCarInformationForRequest request)
        {
            try
            {
                CarSpecifications = _repository.FindWithRequest(request);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Car Specification data because of {0}", ex.Message);
                throw;
            }
        }
    }
}
