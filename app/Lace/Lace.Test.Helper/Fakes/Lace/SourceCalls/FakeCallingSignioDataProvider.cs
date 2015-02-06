using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Builders.Responses;
using Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Management;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingSignioDataProvider : ICallTheDataProviderSource
    {
        private string _resonse;

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendCommandsToBus monitoring)
        {

            _resonse = new SourceResponseBuilder().ForSignioDriversLicenseDecryptedResponse();
            TransformResponse(response, monitoring);
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendCommandsToBus monitoring)
        {
            var transformer =
                new TransformSignioResponse(
                    _resonse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.SignioDriversLicenseDecryptionResponse = transformer.Result;
            response.SignioDriversLicenseDecryptionResponseHandled = new SignioDriversLicenseDecryptionResponseHandled();
            response.SignioDriversLicenseDecryptionResponseHandled.HasBeenHandled();
        }
    }
}
