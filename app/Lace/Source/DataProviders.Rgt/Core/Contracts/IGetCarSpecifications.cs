using System.Collections.Generic;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Rgt.Core.Contracts
{
    public interface IGetCarSpecifications
    {
        IEnumerable<CarSpecification> CarSpecifications { get; }
        void GetCarSpecifications(IHaveCarInformation request);
    }
}
