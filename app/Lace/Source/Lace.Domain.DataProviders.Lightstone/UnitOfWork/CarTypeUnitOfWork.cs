using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class CarTypeUnitOfWork : IGetCarType
    {
        private readonly ILog _log;
        public IEnumerable<CarType> CarTypes { get; private set; }
        private readonly IReadOnlyRepository<CarType> _repository;

        public CarTypeUnitOfWork(IReadOnlyRepository<CarType> repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetCarTypes(IHaveCarInformation request)
        {
            try
            {
                CarTypes = _repository.FindByMake(request.MakeId);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Car Type data because of {0}", ex.Message);
            }
        }
    }
}
