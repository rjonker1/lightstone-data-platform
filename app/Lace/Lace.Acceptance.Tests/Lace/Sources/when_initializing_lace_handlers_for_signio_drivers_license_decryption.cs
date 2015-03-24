using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Signio.DriversLicense;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Scans;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_signio_drivers_license_decryption : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendMonitoringCommandsToBus _monitoring;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_signio_drivers_license_decryption()
        {
            _monitoring = MonitoringBusBuilder.ForSignioDriversLicenseCommands(Guid.NewGuid());
            _request = new DriversLicenseRequestBuilder().ForDriversLicenseScan();
            _response = new Collection<IPointToLaceProvider>();
            _dataProvider = new SignioDataProvider(_request, null, null, _monitoring);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_signio_drivers_license_decryption_response_should_be_handled_test()
        {
            _response.OfType<IProvideDataFromSignioDriversLicenseDecryption>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_signio_drivers_license_decryption_response_shuould_not_be_null_test()
        {
            _response.OfType<IProvideDataFromSignioDriversLicenseDecryption>().First().ShouldNotBeNull();
        }
    }
}
