using System.Collections.Generic;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.UnitOfWork;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure.Management
{
    public static class GetSpecifications
    {
        static GetSpecifications()
        {

        }

        public static void ForCar(IReadOnlyRepository repository, IHaveCarInformation request, out IList<CarSpecification> carSpecifications)
        {
            var worker = new CarSpecificationsUnitOfWork(repository);
            worker.GetCarSpecifications(request);

            carSpecifications = worker.CarSpecifications != null
                ? worker.CarSpecifications.ToList()
                : new List<CarSpecification>();
        }
    }
}