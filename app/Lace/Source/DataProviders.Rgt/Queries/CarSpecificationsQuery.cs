using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Domain.DataProviders.Rgt.Queries
{
    public class CarSpecificationsQuery : IGetCarSpecifications
    {
        public IEnumerable<CarSpecification> CarSpecifications { get; private set; }

        private static readonly ILog Log = LogManager.GetLogger<CarSpecification>();
        private readonly IReadOnlyRepository _repository;

        public CarSpecificationsQuery(IReadOnlyRepository repository)
        {
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
                Log.ErrorFormat("Error getting Car Specification data because of {0}", ex, ex.Message);
            }
        }
    }
}
