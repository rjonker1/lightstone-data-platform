using System.Collections.Generic;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetMakes
    {
        IEnumerable<Make> Makes { get; }
        void GetMakes(IHaveCarInformation request);
    }
}
