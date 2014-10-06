using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class CarTypeData : IGetCarType
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public IEnumerable<CarType> CarTypes { get; private set; }
        private readonly IReadOnlyRepository<CarType> _repository;

        public CarTypeData(IReadOnlyRepository<CarType> repository)
        {
            _repository = repository;
        }

        public void GetCarTypes(IProvideCarInformationForRequest request)
        {
            try
            {
                CarTypes = _repository.FindByMake(request.MakeId);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Car Type data because of {0}", ex.Message);
            }
        }
    }
}
