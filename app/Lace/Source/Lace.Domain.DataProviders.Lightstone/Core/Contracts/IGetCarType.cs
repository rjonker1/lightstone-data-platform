using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetCarType
    {
        IEnumerable<CarType> CarTypes { get; }
        void GetCarTypes(IHaveCarInformation request);
    }
}
