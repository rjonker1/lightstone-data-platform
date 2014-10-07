using System.Configuration;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Jis.Infrastructure;
using Lace.Shared.CertificateProvider.Infrastructure.Factory;
using Lace.Shared.CertificateProvider.Infrastructure.Providers;

namespace Lace.Domain.DataProviders.Jis
{
    public class JisSourceExecution : ExecuteSourceBase, IExecuteTheSource
    {
        private readonly ILaceRequest _request;

        public JisSourceExecution(ILaceRequest request, IExecuteTheSource nextSource, IExecuteTheSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(IProvideLaceResponse response, ILaceEvent laceEvent)
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
                consumer.ConsumeExternalSource(response, laceEvent);

                if (response.IvidResponse == null)
                    CallFallbackSource(response, laceEvent);
            }

            CallNextSource(response, laceEvent);
        }

        private static void NotHandledResponse(IProvideLaceResponse response)
        {
            response.JisResponse = null;
            response.JisResponseHandled = new JisResponseHandled();
            response.JisResponseHandled.HasNotBeenHandled();
        }
    }
}
