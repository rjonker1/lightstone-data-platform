using System.Linq;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes
{
    public class RequestTypeBuilderFactory : AbstractRequestBuilder
    {
        public override IAmDataProviderRequest Build(RequestBuilderContext request, DataProviderName dataProvider)
        {
            var requestIndex = RequestTypeDictionary.RequestTypes.FirstOrDefault(w => w.Key == dataProvider);
            return requestIndex.Value != null ? requestIndex.Value(request) : new NullDataProviderRequest();
        }
    }

    public class NullDataProviderRequest : IAmDataProviderRequest
    {

    }
}