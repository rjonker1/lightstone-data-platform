using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Acceptance.Tests.Helper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Ivid.Infrastructure;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Callers;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Mothers.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Caching
{
    public class when_requesting_ivid_data_from_the_cache : Specification
    {
        private ICollection<IPointToLaceRequest> _request;
        private IAmDataProvider _dataProvider;
        private readonly ISendCommandToBus _command;
        private ICallTheDataProviderSource _caller;
        private readonly ILog _log = LogManager.GetLogger<when_requesting_ivid_data_from_the_cache>();
        private readonly ILogCommandTypes _logCommand;
        private ICollection<IPointToLaceProvider> _response;

        private HpiStandardQueryRequest _ividRequest;

        public when_requesting_ivid_data_from_the_cache()
        {
            _request = new[] { new LicensePlateNumberIvidOnlyRequest() };
            _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.IVIDVerify_E_WS);
            _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.IVIDVerify_E_WS, _dataProvider, DataProviderNoRecordState.Billable);
        }

        public override void Observe()
        {
            TestCacheRepository.ClearAll();
            _response = new List<IPointToLaceProvider>();
            var callers = new IvidCallerFactory(_dataProvider,_logCommand);
            callers.Create().CallTheDataProvider(_response);
        }

        [Observation(Skip = "Need cache to be running")] //
        public void then_request_for_license_number_should_exist_in_cache()
        {
            Task.Delay(10000);

            _response = new List<IPointToLaceProvider>();
            _request = new[] { new LicensePlateNumberIvidOnlyRequest() };
            _ividRequest = HandleRequest.GetHpiStandardQueryRequest(_dataProvider.GetRequest<IAmIvidStandardRequest>());
            _caller = new IvidCacheCaller(new IvidNullCaller(), _ividRequest, _dataProvider, _logCommand);
            _caller.CallTheDataProvider(_response);
            

            _response.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromIvid>().First().Vin.ShouldEqual("W0LPC6EC8DG072314");
        }

        [Observation(Skip = "Need cache to be running")]
        public void then_request_for_vin_number_should_exist_in_cache()
        {
            Task.Delay(10000);

            _response = new List<IPointToLaceProvider>();
            _request = new[] { new VinNumberIvidOnlyRequest() };
            _ividRequest = HandleRequest.GetHpiStandardQueryRequest(_dataProvider.GetRequest<IAmIvidStandardRequest>());
            _caller = new IvidCacheCaller(new IvidNullCaller(), _ividRequest, _dataProvider, _logCommand);
            _caller.CallTheDataProvider(_response);
            

            _response.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromIvid>().First().License.ShouldEqual("CN62KZGP");
        }

        [Observation(Skip = "Need cache to be running")]
        public void then_request_for_register_no_should_exist_in_cache()
        {
            Task.Delay(10000);

            _response = new List<IPointToLaceProvider>();
            _request = new[] { new RegisterNumberIvidOnlyRequest() };
            _ividRequest = HandleRequest.GetHpiStandardQueryRequest(_dataProvider.GetRequest<IAmIvidStandardRequest>());
            _caller = new IvidCacheCaller(new IvidNullCaller(), _ividRequest, _dataProvider, _logCommand);
            _caller.CallTheDataProvider(_response);
            

            _response.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromIvid>().First().License.ShouldEqual("CN62KZGP");
        }
    }
}
