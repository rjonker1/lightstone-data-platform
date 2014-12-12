using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;

namespace Lace.Test.Helper.Builders.DataProviders
{
    public class DataProviderResponseBuilder
    {
        public static HpiStandardQueryRequest IvidHpiStandardQueryRequest(ILaceRequest request)
        {
            return new IvidRequestMessage(request)
               .Build()
               .HpiQueryRequest;
        }
    }

    public class DataProviderConfigurationBuilder
    {
        public static HpiServiceClient ForIvidWebServiceProxy()
        {
            var ividWebService = new ConfigureIvidSource();

            ividWebService.ConfigureIvidWebServiceCredentials();
            ividWebService.ConfigureIvidWebServiceRequestMessageProperty();
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
