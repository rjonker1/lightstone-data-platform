using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Shared.DataProvider.Models;

namespace Lace.Domain.DataProviders.Rgt.Core.Contracts
{
    public interface IGetCarSpecifications
    {
        IEnumerable<CarSpecification> CarSpecifications { get; }
        void GetCarSpecifications(IHaveCarInformation request);
    }
}
