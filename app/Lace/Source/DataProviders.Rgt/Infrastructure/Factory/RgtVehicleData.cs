using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Factories;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure.Factory
{
    public class RgtVehicleDataFactory :
        AbstractVehicleFactory<ICollection<IPointToLaceProvider>, IAmRgtRequest, IReadOnlyRepository>
    {
        private static readonly IMineDataProviderResponseFactory Factory = new ResponseDataMiningFactory();

        public override IRetrieveCarInformation CarInformation(ICollection<IPointToLaceProvider> response, IAmRgtRequest request, IReadOnlyRepository repository)
        {
            return new RequestTypeFactory(response, repository, Factory, null, request.CarId, null).Build().Retrieve();
        }
    }
}