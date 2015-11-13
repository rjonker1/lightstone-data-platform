using System.Collections.Generic;
using DataProviders.MMCode.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace DataProviders.MMCode.Queries
{
    public class CarIdQuery : IGetCarId
    {
        private static readonly IMineResponseData<ICollection<IPointToLaceProvider>> Factory = new ResponseDataMiningFactory();
        public int RetrieveCarId(ICollection<IPointToLaceProvider> response, IAmMmCodeRequest request)
        {
            var carId = GetCarId(request) > 0 ? GetCarId(request) : Factory.MineCarId(response);
            return carId;
        }

        private static int GetCarId(IAmMmCodeRequest request)
        {
            int carId;
            int.TryParse(request.CarId.GetValue(), out carId);
            return carId;
        }
    }
}
