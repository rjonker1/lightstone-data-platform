using System.Configuration;
using Lace.Certificate.Repository.Factory;
using Lace.Certificate.Repository.Infrastructure;
using Lace.Consumer;
using Lace.Events;
using Lace.Models;
using Lace.Models.Jis;
using Lace.Request;
using Lace.Source.Enums;
using Lace.Source.Jis.SourceCalls;

namespace Lace.Source.Jis
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
