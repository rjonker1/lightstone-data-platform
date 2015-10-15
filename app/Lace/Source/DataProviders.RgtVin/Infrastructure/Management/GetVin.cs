using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.RgtVin.Core.Contracts;
using Lace.Toolbox.Database.Models;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure.Management
{
    public static class GetVin
    {
        static GetVin()
        {
            
        }

        public static void AsAList(ICollection<IPointToLaceProvider> response, IAmRgtVinRequest request, IGetVehicleFromVin vinQuery,  out List<Vin> vins)
        {
            var vinnumber = HandleRequest.GetVinNumber(response, request);
            if (string.IsNullOrEmpty(vinnumber))
            {
                vins = new List<Vin>(); 
                return;
            }

            vinQuery.GetVin(vinnumber);
            vins = vinQuery.Vins != null ? vinQuery.Vins.ToList() : new List<Vin>();
        }
    }
}
