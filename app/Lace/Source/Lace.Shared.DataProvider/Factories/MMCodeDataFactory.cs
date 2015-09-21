using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Toolbox.Database.Factories
{
    public class MmCodeDataFactory
    {
        private static readonly IMineResponseData<ICollection<IPointToLaceProvider>> Factory = new ResponseDataMiningFactory();

        public int RetrieveCarId(ICollection<IPointToLaceProvider> response, IAmMmCodeRequest request)
        {
            //IRetrieveCarInformation carInformation = new GetCarInformation();
            //foreach (var fields in Requests.OrderBy(o => (int)o.Key))
            //{
            //    carInformation = fields.Value(request, response, repository);
            //    if (carInformation != null)
            //        break;
            //}

            //return carInformation ?? new GetCarInformation();
            var carId = GetCarId(request) > 0 ? GetCarId(request) : Factory.MineCarId(response);

            return carId;
        }

        private static int GetCarId(IAmMmCodeRequest request)
        {
            int carId;
            int.TryParse(request.CarId.GetValue(), out carId);
            return carId;
        }

        //private static readonly
        //    IDictionary<Order, Func<IAmMmCodeRequest, ICollection<IPointToLaceProvider>, IReadOnlyRepository, IRetrieveCarInformation>>
        //    Requests = new Dictionary<Order, Func<IAmMmCodeRequest, ICollection<IPointToLaceProvider>, IReadOnlyRepository, IRetrieveCarInformation>>()
        //    {
        //        {
        //            Order.First, (request, response, repository) =>
        //            {
        //                var carId = GetCarId(request) > 0 ? GetCarId(request) : Factory.MineCarId(response);
        //                return carId == 0
        //                    ? null
        //                    : new GetCarInformation(carId, repository).SetupDataSources()
        //                        .GenerateData()
        //                        .BuildCarInformation()
        //                        .BuildCarInformationRequest();
        //            }
        //        }
        //    };
    }
}