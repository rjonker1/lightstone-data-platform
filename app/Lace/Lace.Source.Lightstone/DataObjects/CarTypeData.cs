using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Source.Lightstone.DataObjects
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

        public void GetCarTypes(ILaceRequestCarInformation request)
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
