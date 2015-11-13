using System.Collections.Generic;
using System.Linq;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure.Management
{
    public static class GetSpecifications
    {
        static GetSpecifications()
        {

        }

        public static void ForCar(IGetCarSpecifications query, IHaveCarInformation request, out IList<CarSpecification> carSpecifications)
        {
            query.GetCarSpecifications(request);
            carSpecifications = query.CarSpecifications != null
                ? query.CarSpecifications.ToList()
                : new List<CarSpecification>();
        }
    }
}