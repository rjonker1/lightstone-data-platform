using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Infrastructure;
using Lace.Domain.DataProviders.RgtVin.Repositories.Factory;

namespace Lace.Domain.DataProviders.RgtVin
{
    public class RgtVinDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ILaceRequest _request;

        public RgtVinDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.RgtVin, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new HandleRgtVinDataProviderCall(),
                    new CallRgtVinExternalSource(_request,
                        new RepositoryFactory(ConnectionFactory.ForAutoCarStatsDatabase(),
                            CacheConnectionFactory.LocalClient())));
                consumer.ConsumeExternalSource(response, laceEvent);

                if (response.RgtVinResponse == null && FallBack != null)
                    CallFallbackSource(response, laceEvent);
            }

            CallNextSource(response, laceEvent);

        }

        private static void NotHandledResponse(IProvideResponseFromLaceDataProviders response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasNotBeenHandled();
        }
    }
}
