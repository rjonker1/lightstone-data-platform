using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.DataObjects
{
    public interface IGetCarVendor
    {
        IEnumerable<CarVendor> CarVendors { get; }
        void GetCarVendors(ILaceRequestCarInformation request);
    }
}
