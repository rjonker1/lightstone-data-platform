using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Domain.DataProviders.Signio.DriversLicense
{
    public class SignioDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {

        private readonly ILaceRequest _request;
        private readonly ISendCommandsToBus _monitoring;

        public SignioDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource, ISendCommandsToBus monitoring)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _monitoring = monitoring;
        }

        public void CallSource(IProvideResponseFromLaceDataProviders response)
        {
            //var spec = new CanHandlePackageSpecification(DataProviderName.Ivid, _request);
            //if (!spec.IsSatisfied)
            //{
            //    NotHandledResponse(response);
            //}
            //else
            //{
            //    var stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.Ivid);
            //    _monitoring.Begin(new { _request.User, _request.Vehicle, _request.Context }, stopWatch);

            //    var consumer = new ConsumeSource(new HandleIvidSourceCall(), new CallIvidDataProvider(_request));
            //    consumer.ConsumeExternalSource(response, _monitoring);

            //    _monitoring.End(response, stopWatch);

            //    if (response.IvidResponse == null)
            //        CallFallbackSource(response, _monitoring);
            //}

            //CallNextSource(response, _monitoring);
        }
    }
}
