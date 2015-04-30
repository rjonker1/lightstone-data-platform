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
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Rgt.Infrastructure;
using Lace.Domain.DataProviders.Rgt.Repositories.Factory;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Rgt
{
    public class RgtDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private IAmDataProvider _dataProvider;
        private ILogComandTypes _logComand;

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
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.Rgt);
                _logComand = new LogCommandTypes(_command, DataProviderCommandSource.Rgt, _dataProvider);

                _logComand.LogBegin(new {_dataProvider, IvidResponse = response.OfType<IProvideDataFromIvid>()});

                var consumer = new ConsumeSource(new HandleRgtDataProviderCall(),
                    new CallRgtDataProvider(_dataProvider,
                        new RepositoryFactory(ConnectionFactory.ForAutoCarStatsDatabase(),
                            CacheConnectionFactory.LocalClient()),
                        new CarRepositoryFactory(ConnectionFactory.ForAutoCarStatsDatabase(),
                            CacheConnectionFactory.LocalClient()), _logComand));

                consumer.ConsumeDataProvider(response);

                _logComand.LogEnd(new {response});

                if (!response.OfType<IProvideDataFromRgt>().Any() || response.OfType<IProvideDataFromRgt>().First() == null)
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
