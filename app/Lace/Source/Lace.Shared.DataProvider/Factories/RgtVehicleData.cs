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
    public class RgtVehicleDataFactory :
        AbstractVehicleFactory<ICollection<IPointToLaceProvider>, IAmRgtRequest, IReadOnlyRepository>
    {
        private static readonly IMineResponseData<ICollection<IPointToLaceProvider>> Factory = new ResponseDataMiningFactory();

        public override IRetrieveCarInformation CarInformation(ICollection<IPointToLaceProvider> response, IAmRgtRequest request,
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

        private static int GetCarId(IAmRgtRequest request)
        {
            int carId;
            int.TryParse(request.CarId.GetValue(), out carId);
            return carId;
        }
        

        private static readonly
            IDictionary<Order, Func<IAmRgtRequest, ICollection<IPointToLaceProvider>, IReadOnlyRepository, IRetrieveCarInformation>>
            Requests = new Dictionary
                <Order, Func<IAmRgtRequest, ICollection<IPointToLaceProvider>, IReadOnlyRepository, IRetrieveCarInformation>>()
            {
                {
                    Order.First, (request, response, repository) =>
                    {
                        var vinNumber = Factory.MineVinNumber(response);
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
                        var carId = GetCarId(request) > 0 ? GetCarId(request) : Factory.MineCarId(response);
                        return carId == 0
                            ? null
                            : new GetCarInformation(carId, repository).SetupDataSources()
                                .GenerateData()
                                .BuildCarInformation()
                                .BuildCarInformationRequest();

                    }

                }
            };
    }
}
