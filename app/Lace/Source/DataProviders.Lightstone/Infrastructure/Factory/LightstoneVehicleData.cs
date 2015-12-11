using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Factories.CarInformation;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory
{
    public class LightstoneVehicleDataFactory : AbstractVehicleFactory<ICollection<IPointToLaceProvider>, IAmLightstoneAutoRequest, IQueryCarInformation>
    {
        private static readonly IMineDataProviderResponseFactory Factory = new ResponseDataMiningFactory();

        public override IRetrieveCarInformation CarInformation(ICollection<IPointToLaceProvider> response, IAmLightstoneAutoRequest request, IQueryCarInformation query)
        {
            return new RequestTypeFactory(response, Factory, request.VinNumber, request.CarId, request.Year, query).Build().Retrieve();
        }
    }
}
