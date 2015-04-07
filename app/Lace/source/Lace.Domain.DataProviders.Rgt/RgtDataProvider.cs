using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProvider.Car.Repositories.Factory;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Infrastructure;
using Lace.Domain.DataProviders.Rgt.Repositories.Factory;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;
using DataProviderName = PackageBuilder.Domain.Entities.Enums.DataProviders.DataProviderName;

namespace Lace.Domain.DataProviders.Rgt
{
    public class RgtDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;

        public RgtDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.Rgt, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.Rgt);
                _command.Monitoring.Begin(new {_request, IvidResponse = response.OfType<IProvideDataFromIvid>().First()},
                    stopWatch);

                var consumer = new ConsumeSource(new HandleRgtDataProviderCall(),
                    new CallRgtDataProvider(_request,
                        new RepositoryFactory(ConnectionFactory.ForAutoCarStatsDatabase(),
                            CacheConnectionFactory.LocalClient()),
                        new CarRepositoryFactory(ConnectionFactory.ForAutoCarStatsDatabase(),
                            CacheConnectionFactory.LocalClient())));

                consumer.ConsumeExternalSource(response, _command);

                _command.Monitoring.End(response, stopWatch);

                if (!response.OfType<IProvideDataFromRgt>().Any() ||
                    response.OfType<IProvideDataFromRgt>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var rgtResponse = new RgtResponse();
            rgtResponse.HasNotBeenHandled();
            response.Add(rgtResponse);

        }
    }
}
