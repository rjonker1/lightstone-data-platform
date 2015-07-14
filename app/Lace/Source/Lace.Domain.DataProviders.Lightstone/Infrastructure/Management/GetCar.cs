using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Infrastructure;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Shared.DataProvider.Repositories;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Management
{
    public static class GetCar
    {
        static GetCar()
        {
            
        }

        public static bool WithVin(ICollection<IPointToLaceProvider> response, IAmLightstoneAutoRequest request, IReadOnlyRepository carRepository,
            ref IRetrieveCarInformation carInformation)
        {
            var vinnumber = HandleRequest.GetVinNumber(response, request);

            if (string.IsNullOrEmpty(vinnumber)) return false;

            carInformation =
                new GetCarInformation(vinnumber,
                    carRepository)
                    .SetupDataSources()
                    .GenerateData()
                    .BuildCarInformation()
                    .BuildCarInformationRequest();

            return carInformation.IsSatisfied;
        }

        public static bool WithCarId(ICollection<IPointToLaceProvider> response, IAmLightstoneAutoRequest request, IReadOnlyRepository carRepository, ref IRetrieveCarInformation carInformation, bool stop)
        {
            if (stop) return false;

            var carId = HandleRequest.GetCarId(request);

            if (carId == 0) return false;

            carInformation =
                new GetCarInformation(carId,
                    carRepository)
                    .SetupDataSources()
                    .GenerateData()
                    .BuildCarInformation()
                    .BuildCarInformationRequest();

            return carInformation.IsSatisfied;
        }
    }
}