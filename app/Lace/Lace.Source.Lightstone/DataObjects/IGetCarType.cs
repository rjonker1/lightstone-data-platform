using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.DataObjects
{
    public interface IGetCarType
    {
        IEnumerable<CarType> CarTypes { get; }
        void GetCarTypes(ILaceRequestCarInformation request);
    }
}
