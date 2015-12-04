using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes
{
    public interface IBuildRequest
    {
        IAmDataProviderRequest Build(RequestBuilderContext request, DataProviderName dataProvider);
    }

    //public interface IBuildRequestType<in TContext> : IBuildRequestType
    //{
    //    IAmDataProviderRequest Build(TContext request, DataProviderName dataProvider);
    //}
}
