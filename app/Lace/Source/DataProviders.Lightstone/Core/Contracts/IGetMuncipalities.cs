using System.Collections.Generic;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetMuncipalities
    {
        IEnumerable<Municipality> Municipalities { get; }
        void GetMunicipalities(IHaveCarInformation request);
    }
}
