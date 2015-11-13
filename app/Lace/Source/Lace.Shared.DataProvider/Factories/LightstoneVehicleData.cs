using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Domain;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Toolbox.Database.Factories
{
    public class LightstoneVehicleDataFactory :
        AbstractVehicleFactory<ICollection<IPointToLaceProvider>, IAmLightstoneAutoRequest, IReadOnlyRepository>
    {
        private static readonly IMineResponseData<ICollection<IPointToLaceProvider>> Factory = new ResponseDataMiningFactory();

        public override IRetrieveCarInformation CarInformation(ICollection<IPointToLaceProvider> response, IAmLightstoneAutoRequest request,
            IReadOnlyRepository repository)
        {
            IRetrieveCarInformation carInformation = new GetCarInformation();
            foreach (var fields in Requests.OrderBy(o => (int)o.Key))
            {
                carInformation = fields.Value(request, response, repository);
                if (carInformation != null)
                    break;
            }

            return carInformation ?? GetCarInformation.Empty();
        }

        private static int GetCarId(IAmLightstoneAutoRequest request)
        {
            int carId;
            int.TryParse(request.CarId.GetValue(), out carId);
            return carId;
        }

        private static int GetYear(IAmLightstoneAutoRequest request)
        {
            int year;
            int.TryParse(request.Year.GetValue(), out year);
            return year;
        }

        private static readonly
            IDictionary<Order, Func<IAmLightstoneAutoRequest, ICollection<IPointToLaceProvider>, IReadOnlyRepository, IRetrieveCarInformation>>
            Requests = new Dictionary
                <Order, Func<IAmLightstoneAutoRequest, ICollection<IPointToLaceProvider>, IReadOnlyRepository, IRetrieveCarInformation>>()
            {
                {
                    Order.First, (request, response, repository) =>
                    {
                        var vinNumber = !string.IsNullOrEmpty(request.VinNumber.GetValue())
                            ? request.VinNumber.GetValue()
                            : Factory.MineVinNumber(response);
                        return string.IsNullOrEmpty(vinNumber)
                            ? null
                            : new GetCarInformation(vinNumber, repository).SetupDataSources()
                                .GenerateData()
                                .BuildCarInformation()
                                .BuildCarInformationRequest();
                    }
                },
                {
                    Order.Second, (request, response, repository) =>
                    {
                        var carId = GetCarId(request);
                        var year = GetYear(request);
                        return carId == 0
                            ? null
                            : new GetCarInformation(carId, year, repository).SetupDataSources()
                                .GenerateData()
                                .BuildCarInformation()
                                .BuildCarInformationRequest();

                    }

                }
            };


    }
}
