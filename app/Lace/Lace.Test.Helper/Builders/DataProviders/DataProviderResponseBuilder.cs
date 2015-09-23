using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Builders.DataProviders
{
    public class DataProviderResponseBuilder
    {
        public static HpiStandardQueryRequest IvidHpiStandardQueryRequest(IAmDataProvider dataProviders)
        {
            return
                HandleRequest.GetHpiStandardQueryRequest(dataProviders.GetRequest<IAmIvidStandardRequest>());
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
            var transformer = new TransformIvidResponse(response, new CriticalFailure(true,"this cannot fail"));

            if (transformer.Continue)
            {
                transformer.Transform();
            }
            return transformer;
        }
    }
}
