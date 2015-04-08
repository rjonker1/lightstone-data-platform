using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;
using DataProviderName = PackageBuilder.Domain.Entities.Enums.DataProviders.DataProviderName;

namespace Lace.Domain.DataProviders.Signio.DriversLicense
{
    public class SignioDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {

        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;

        public SignioDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.SignioDecryptDriversLicense, _request);
            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var stopWatch =
                    new StopWatchFactory().StopWatchForDataProvider(
                        DataProviderCommandSource.SignioDecryptDriversLicense);

                _command.Workflow.Begin(new { _request }, stopWatch, DataProviderCommandSource.SignioDecryptDriversLicense);

                var consumer = new ConsumeSource(new HandleSignioSourceCall(), new CallSignioDataProvider(_request));
                consumer.ConsumeExternalSource(response, _command);

                _command.Workflow.End(response, stopWatch, DataProviderCommandSource.SignioDecryptDriversLicense);

                if (!response.OfType<IProvideDataFromSignioDriversLicenseDecryption>().Any() ||
                    response.OfType<IProvideDataFromSignioDriversLicenseDecryption>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var signioDriversLicenseDecryptionResponse = new SignioDriversLicenseDecryptionResponse();
            signioDriversLicenseDecryptionResponse.HasNotBeenHandled();
            response.Add(signioDriversLicenseDecryptionResponse);
        }
    }
}
