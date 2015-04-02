using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetBands
    {
        IEnumerable<Band> Bands { get; }
        void GetBands(IHaveCarInformation request);
    }
}
