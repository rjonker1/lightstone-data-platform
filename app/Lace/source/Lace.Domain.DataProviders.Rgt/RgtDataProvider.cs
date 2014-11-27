using Lace.CrossCutting.DataProvider.Car.Repositories.Factory;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Infrastructure;
using Lace.Domain.DataProviders.Rgt.Repositories.Factory;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Rgt
{
    public class RgtDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ILaceRequest _request;

        public RgtDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource) : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            var spec = new CanHandlePackageSpecification(Services.Rgt, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new HandleRgtDataProviderCall(),
                    new CallRgtDataProvider(_request,
                        new RepositoryFactory(ConnectionFactory.ForAutoCarStatsDatabase(),
                            CacheConnectionFactory.LocalClient()),
                        new CarRepositoryFactory(ConnectionFactory.ForAutoCarStatsDatabase(),
                            CacheConnectionFactory.LocalClient())));

                consumer.ConsumeExternalSource(response, monitoring);

                if (response.RgtResponse == null && FallBack != null)
                    CallFallbackSource(response, monitoring);
            }

            CallNextSource(response, monitoring);
        }

        private static void NotHandledResponse(IProvideResponseFromLaceDataProviders response)
        {
            response.RgtResponse = null;
            response.RgtResponseHandled = new RgtResponseHandled();
            response.RgtResponseHandled.HasNotBeenHandled();
        }
    }
}
