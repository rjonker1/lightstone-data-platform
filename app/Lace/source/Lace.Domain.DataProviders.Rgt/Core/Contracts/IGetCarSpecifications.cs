using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Rgt.Core.Models;

namespace Lace.Domain.DataProviders.Rgt.Core.Contracts
{
    public interface IGetCarSpecifications
    {
        IEnumerable<CarSpecification> CarSpecifications { get; }
        void GetCarSpecifications(IProvideCarInformationForRequest request);
    }
}
