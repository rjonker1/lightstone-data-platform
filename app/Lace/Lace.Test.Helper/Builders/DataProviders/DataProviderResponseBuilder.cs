using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;

namespace Lace.Test.Helper.Builders.DataProviders
{
    public class DataProviderResponseBuilder
    {
        public static HpiStandardQueryRequest IvidHpiStandardQueryRequest(ICollection<IPointToLaceRequest> request)
        {
            return
                new IvidRequestMessage(request.GetFromRequest<IAmVehicleRequest>().User,
                    request.GetFromRequest<IAmVehicleRequest>().Vehicle,
                    request.GetFromRequest<IAmVehicleRequest>().Package.Name)
                    .HpiQueryRequest;
        }
    }

    public class DataProviderConfigurationBuilder
    {
        public static HpiServiceClient ForIvidWebServiceProxy()
        {
            var ividWebService = new ConfigureIvidSource();
            return ividWebService.IvidServiceProxy;
        }
    }

    public class DataProviderTransformationBuilder
    {
        public static TransformIvidResponse ForIvid(HpiStandardQueryResponse response)
        {
            var transformer = new TransformIvidResponse(response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }
            return transformer;
        }
    }
}
