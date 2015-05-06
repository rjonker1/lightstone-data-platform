using System.Collections.Generic;
using Lace.Shared.DataProvider.Models;

namespace Lace.Domain.DataProviders.RgtVin.Core.Contracts
{
    public interface IGetVehicleFromVin
    {
        IEnumerable<Vin> Vins { get; }
        void GetVin(string vin);
    }
}
