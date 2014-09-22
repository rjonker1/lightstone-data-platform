using Lace.Consumer;
using Lace.Models;
using Lace.Models.Anpr;
using Lace.Request;
using Lace.Source.Anpr.Repository.Factory;
using Lace.Source.Anpr.Repository.Infrastructure;
using Lace.Source.Anpr.SourceCalls;
using Lace.Source.Enums;

namespace Lace.Source.Anpr
{
    public class AnprSourceExecution : ExecuteSourceBase, IExecuteTheSource
    {
        private readonly ILaceRequest _request;

        public AnprSourceExecution(ILaceRequest request, IExecuteTheSource nextSource, IExecuteTheSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(IProvideLaceResponse response, Events.ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.Anpr, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new HandleAnprSourceCall(),
                    new CallAnprExternalSource(_request,
                        new RepositoryFactory(ConnectionFactory.ForLsCorporateAutoDatabase(),
                            CacheConnectionFactory.LocalClient())));

                consumer.ConsumeExternalSource(response, laceEvent);

                if (response.AnprResponse == null)
                    CallFallbackSource(response, laceEvent);
            }
        }

        private static void NotHandledResponse(IProvideLaceResponse response)
        {
            response.AnprResponse = null;
            response.AnprResponseHandled = new AnprResponseHandled();
            response.AnprResponseHandled.HasNotBeenHandled();
        }
    }
}
