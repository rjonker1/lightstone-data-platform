using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes
{
    //public abstract class AbstractRequestBuilder<TContext> : IBuildRequestType<TContext>
    public abstract class AbstractRequestBuilder : IBuildRequest
    {
        public abstract IAmDataProviderRequest Build(RequestBuilderContext request, DataProviderName dataProvider);

        //public IAmDataProviderRequest Build(RequestBuilderContext request, DataProviderName dataProvider)
        //{
        //    return Build(request, dataProvider);
        //}
    }
} 
