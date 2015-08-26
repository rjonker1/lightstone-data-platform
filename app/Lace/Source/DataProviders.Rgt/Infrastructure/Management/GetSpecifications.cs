using System.Collections.Generic;
using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Shared.DataProvider.Models;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure.Management
{
    public static class GetSpecifications
    {
        static GetSpecifications()
        {

        }

        public static void ForCar(IGetCarSpecifications worker, IHaveCarInformation request, out IList<CarSpecification> carSpecifications)
        {
            worker.GetCarSpecifications(request);
            carSpecifications = worker.CarSpecifications != null
                ? worker.CarSpecifications.ToList()
                : new List<CarSpecification>();
        }
    }
}