using System.Collections.Generic;
using Lace.Toolbox.Database.Models;

namespace Lace.Toolbox.Database.Base
{
    public interface IGetCarInformation
    {
        IEnumerable<CarInformation> Cars { get; }
        void GetCarInformation(IHaveCarInformation request);
    }
}
