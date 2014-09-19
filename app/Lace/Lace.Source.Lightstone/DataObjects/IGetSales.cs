using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.DataObjects
{
    public interface IGetSales
    {
        IEnumerable<Sale> Sales { get; }
        void GetSales(IProvideCarInformationForRequest request);
    }
}
