using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetCarInfo
    {
        IEnumerable<CarInfo> Cars { get; }
        void GetCarInfo(IProvideCarInformationForRequest request);
    }
}
