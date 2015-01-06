using System.Collections.Generic;
using Lace.CrossCutting.DataProviderCommandSource.Car.Core.Models;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.CrossCutting.DataProviderCommandSource.Car.Core.Contracts
{
    public interface IGetCarInfo
    {
        IEnumerable<CarInfo> Cars { get; }
        void GetCarInfo(IProvideCarInformationForRequest request);
    }
}
