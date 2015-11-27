using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Factories;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory
{
    public class LightstoneVehicleDataFactory : AbstractVehicleFactory<ICollection<IPointToLaceProvider>, IAmLightstoneAutoRequest, IReadOnlyRepository>
    {
        private static readonly IMineDataProviderResponseFactory Factory = new ResponseDataMiningFactory();

        public override IRetrieveCarInformation CarInformation(ICollection<IPointToLaceProvider> response, IAmLightstoneAutoRequest request, IReadOnlyRepository repository)
        {
            return new RequestTypeFactory(response,repository,Factory,request.VinNumber,request.CarId,request.Year).Build().Retrieve();
        }
    }
}
