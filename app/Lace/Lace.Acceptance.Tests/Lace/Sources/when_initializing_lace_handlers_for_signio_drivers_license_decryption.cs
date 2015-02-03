using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Signio.DriversLicense;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Scans;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_signio_drivers_license_decryption : Specification
    {
        private readonly ILaceRequest _request;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private readonly ISendCommandsToBus _monitoring;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_signio_drivers_license_decryption()
        {
            _monitoring = BusBuilder.ForSignioDriversLicenseCommands(Guid.NewGuid());
            _request = new DriversLicenseRequestBuilder().ForDriversLicenseScan();
            _response = new LaceResponse();
            _dataProvider = new SignioDataProvider(_request, null, null, _monitoring);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_signio_drivers_license_decryption_response_should_be_handled_test()
        {
            _response.SignioDriversLicenseDecryptionResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_signio_drivers_license_decryption_response_shuould_not_be_null_test()
        {
            _response.SignioDriversLicenseDecryption.ShouldNotBeNull();
        }
    }
}
