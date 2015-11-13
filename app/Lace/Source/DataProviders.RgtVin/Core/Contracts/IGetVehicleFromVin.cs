using System.Collections.Generic;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.RgtVin.Core.Contracts
{
    public interface IGetVehicleFromVin
    {
        IEnumerable<Vin> Vins { get; }
        void GetVin(string vin);
    }
}
