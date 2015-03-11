using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProvider.Car.Repositories.Factory;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.Lightstone
{
    public class LightstoneDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;

        public LightstoneDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendMonitoringCommandsToBus monitoring)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _monitoring = monitoring;
        }

        public void CallSource(IProvideResponseFromLaceDataProviders response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.Lightstone, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.Lightstone);
                _monitoring.Begin(new { _request.User, _request.Vehicle, _request.Context }, stopWatch);

                var consumer = new ConsumeSource(new HandleLightstoneSourceCall(),
                    new CallLightstoneDataProvider(_request,
                        new RepositoryFactory(ConnectionFactory.ForAutoCarStatsDatabase(),
                            CacheConnectionFactory.LocalClient()),
                        new CarRepositoryFactory(ConnectionFactory.ForAutoCarStatsDatabase(),
                            CacheConnectionFactory.LocalClient())));

                consumer.ConsumeExternalSource(response, _monitoring);

                _monitoring.End(response, stopWatch);

                if (response.LightstoneResponse == null)
                    CallFallbackSource(response, _monitoring);
            }

            CallNextSource(response, _monitoring);
        }

        private static void NotHandledResponse(IProvideResponseFromLaceDataProviders response)
        {
            response.LightstoneResponse = null;
            response.LightstoneResponseHandled = new LightstoneResponseHandled();
            response.LightstoneResponseHandled.HasNotBeenHandled();
        }
    }
}
