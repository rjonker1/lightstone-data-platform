using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.DataObjects
{
    public interface IGetCarInfo
    {
        IEnumerable<CarInfo> Cars { get; }
        void GetCarInfo(ILaceRequestCarInformation request);
    }
}
