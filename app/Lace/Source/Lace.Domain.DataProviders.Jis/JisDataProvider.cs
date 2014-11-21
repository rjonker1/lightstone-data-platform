using System.Configuration;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Factory;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Jis.Infrastructure;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Jis
{
    public class JisDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ILaceRequest _request;

        public JisDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            var spec = new CanHandlePackageSpecification(Services.Jis, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new HandleJisSourceCall(),
                    new CallJisExternalSource(_request,
                        new RepositoryFactory(ConnectionFactory.ForLsCorporateAutoDatabase(),
                            CacheConnectionFactory.LocalClient(),
                            ConfigurationManager.ConnectionStrings["lace/source/database/jis/certificates/configuration"
                                ].ConnectionString)));
                consumer.ConsumeExternalSource(response, monitoring);

                if (response.IvidResponse == null)
                    CallFallbackSource(response, monitoring);
            }

            CallNextSource(response, monitoring);
        }

        private static void NotHandledResponse(IProvideResponseFromLaceDataProviders response)
        {
            response.JisResponse = null;
            response.JisResponseHandled = new JisResponseHandled();
            response.JisResponseHandled.HasNotBeenHandled();
        }
    }
}
