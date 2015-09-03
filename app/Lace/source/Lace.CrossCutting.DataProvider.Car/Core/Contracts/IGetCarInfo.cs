using System.Collections.Generic;
using Lace.Toolbox.Database.Models;

namespace Lace.CrossCutting.DataProvider.Car.Core.Contracts
{
    public interface IGetCarInformation
    {
        IEnumerable<CarInformation> Cars { get; }
        void GetCarInformation(IHaveCarInformation request);
    }
}
