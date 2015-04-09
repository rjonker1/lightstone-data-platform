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
                new IvidRequestMessage(request.GetFromRequest<IPointToVehicleRequest>().User,
                    request.GetFromRequest<IPointToVehicleRequest>().Vehicle,
                    request.GetFromRequest<IPointToVehicleRequest>().Package.Name)
                    .HpiQueryRequest;
        }
    }

    public class DataProviderConfigurationBuilder
    {
        public static HpiServiceClient ForIvidWebServiceProxy()
        {
            var ividWebService = new ConfigureIvid();
            return ividWebService.Client;
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
