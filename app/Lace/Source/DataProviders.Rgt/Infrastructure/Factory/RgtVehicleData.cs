using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Factories.CarInformation;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure.Factory
{
    public class RgtVehicleDataFactory :
        AbstractVehicleFactory<ICollection<IPointToLaceProvider>, IAmRgtRequest, IQueryCarInformation>
    {
        private static readonly IMineDataProviderResponseFactory Factory = new ResponseDataMiningFactory();

        public override IRetrieveCarInformation CarInformation(ICollection<IPointToLaceProvider> response, IAmRgtRequest request, IQueryCarInformation query)
        {
            return new RequestTypeFactory(response, Factory, null, request.CarId, null, query).Build().Retrieve();
        }
    }
}