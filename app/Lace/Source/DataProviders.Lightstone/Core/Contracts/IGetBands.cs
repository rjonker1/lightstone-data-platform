using System.Collections.Generic;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetBands
    {
        IEnumerable<Band> Bands { get; }
        void GetBands(IHaveCarInformation request);
    }
}
