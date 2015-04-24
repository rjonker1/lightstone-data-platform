using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.CrossCutting.DataProvider.Car.Core.Contracts
{
    public interface IGetCarInformation
    {
        IEnumerable<CarInformation> Cars { get; }
        void GetCarInformation(IHaveCarInformation request);
    }
}
