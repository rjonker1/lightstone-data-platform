using System.Collections.Generic;
using Lace.Shared.DataProvider.Models;

namespace Lace.CrossCutting.DataProvider.Car.Core.Contracts
{
    public interface IGetCarInformation
    {
        IEnumerable<CarInformation> Cars { get; }
        void GetCarInformation(IHaveCarInformation request);
    }
}
