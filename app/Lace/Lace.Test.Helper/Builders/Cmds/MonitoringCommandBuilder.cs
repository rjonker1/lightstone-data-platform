using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.DataProviders.Ivid.Infrastructure;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Responses;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Builders.Cmds
{
    public class MonitoringCommandBuilder
    {
        private readonly Guid _aggregateId;

        public MonitoringCommandBuilder(Guid aggregateId)
        {
            _aggregateId = aggregateId;
        }
        
        public MonitoringCommandBuilder ForIvid()
        {
            var request = new LicensePlateRequestBuilder().ForIvid();

            var queue = new MonitoirngQueueSender(DataProviderCommandSource.IVIDVerify_E_WS, _aggregateId);
            queue.InitQueue(MonitoringBusBuilder.ForIvidCommands(_aggregateId))
                .InitStopWatch()
                .StartingExecution(new LicensePlateRequestBuilder().ForIvid())
                .Configuration(
                    new
                    {
                        Credentials =
                            new
                            {
                                UserName = "CARSTATS-CARSTATS",
                                Password = "8B5Jk3Q66"
                            }
                    },
                    new {ContextMessage = "Ivid Data Provider Credentials"})
                .StartCall(
                    HandleRequest.GetHpiStandardQueryRequest(
                        request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.IVIDVerify_E_WS).GetRequest<IAmIvidStandardRequest>()), null)
                .Error(new {NoRequestReceived = "No response received from Ivid Data Provider"}, null)
                .EndCall(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp())
                .Transform(
                    new TransformIvidResponse(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp(), new CriticalFailure(true,"this cannot fail")).Result,
                    new TransformIvidResponse(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp(), new CriticalFailure(true, "this cannot fail")))
                .EndExecution(
                    new TransformIvidResponse(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp(), new CriticalFailure(true, "this cannot fail")).Result);

            return this;
        }
    }
}
