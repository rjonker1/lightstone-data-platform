using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Infrastructure;
using Lace.Domain.DataProviders.RgtVin.Repositories.Factory;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;
using DataProviderName = PackageBuilder.Domain.Entities.Enums.DataProviders.DataProviderName;

namespace Lace.Domain.DataProviders.RgtVin
{
    public class RgtVinDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;

        public RgtVinDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.RgtVin, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.Rgt);
                _command.Workflow.Begin(new {_request, IvidResponse = response.OfType<IProvideDataFromIvid>().First()},
                    stopWatch, DataProviderCommandSource.RgtVin);

                var consumer = new ConsumeSource(new HandleRgtVinDataProviderCall(),
                    new CallRgtVinDataProvider(_request,
                        new RepositoryFactory(ConnectionFactory.ForAutoCarStatsDatabase(),
                            CacheConnectionFactory.LocalClient())));
                consumer.ConsumeExternalSource(response, _command);

                _command.Workflow.End(response, stopWatch, DataProviderCommandSource.RgtVin);

                if (!response.OfType<IProvideDataFromRgtVin>().Any() ||
                    response.OfType<IProvideDataFromIvid>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);

        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var rgtVinResponse = new RgtVinResponse();
            rgtVinResponse.HasNotBeenHandled();
            response.Add(rgtVinResponse);
        }
    }
}
