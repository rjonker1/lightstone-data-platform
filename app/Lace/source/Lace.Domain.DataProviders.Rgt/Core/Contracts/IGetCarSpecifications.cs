using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;

namespace Lace.Domain.DataProviders.Rgt.Core.Contracts
{
    public interface IGetCarSpecifications
    {
        IEnumerable<CarSpecification> CarSpecifications { get; }
        void GetCarSpecifications(IHaveCarInformation request);
    }
}
