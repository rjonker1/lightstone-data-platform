using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.DataObjects
{
    public interface IGetBands
    {
        IEnumerable<Band> Bands { get; }
        void GetBands(ILaceRequestCarInformation request);
    }
}
