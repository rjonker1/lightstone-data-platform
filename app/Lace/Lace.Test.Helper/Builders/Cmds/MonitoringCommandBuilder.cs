using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Fakes.Responses;

namespace Lace.Test.Helper.Builders.Cmds
{
    public class MonitoringCommandBuilder
    {
        private readonly Guid _aggregateId;

        public MonitoringCommandBuilder(Guid aggregateId)
        {
            _aggregateId = aggregateId;
        }


        public MonitoringCommandBuilder ForAudatex()
        {
            var queue = new MonitoirngQueueSender(DataProviderCommandSource.Audatex, _aggregateId);
            queue.InitQueue(MonitoringBusBuilder.ForAudatexCommands(_aggregateId))
                .InitStopWatch()
                .StartingExecution(new LicensePlateRequestBuilder().ForAudatex())
                .Configuration(
                    new ConfigureRequestMessage(new LaceResponseBuilder().WithIvidResponseHandled()).Build()
                        .AudatexRequest, null)
                .StartCall(
                    new ConfigureRequestMessage(new LaceResponseBuilder().WithIvidResponseHandled()).Build()
                        .AudatexRequest, null)
                .Error(new {NoRequestReceived = "No response received from Audatex Data Provider"}, null)
                .EndCall(FakeAudatexWebResponseData.GetAudatextWebServiceResponse())
                .Transform(
                    new TransformAudatexResponse(FakeAudatexWebResponseData.GetAudatextWebServiceResponse(),
                        new LaceResponseBuilder().WithIvidResponseHandled(),
                        new LicensePlateRequestBuilder().ForAudatex()
                            .GetFromRequest<IPointToVehicleRequest>().Vehicle).Result,
                    new TransformAudatexResponse(FakeAudatexWebResponseData.GetAudatextWebServiceResponse(),
                        new LaceResponseBuilder().WithIvidResponseHandled(),
                        new LicensePlateRequestBuilder().ForAudatex()
                            .GetFromRequest<IPointToVehicleRequest>().Vehicle))
                .EndExecution(
                    new TransformAudatexResponse(FakeAudatexWebResponseData.GetAudatextWebServiceResponse(),
                        new LaceResponseBuilder().WithIvidResponseHandled(),
                        new LicensePlateRequestBuilder().ForAudatex()
                            .GetFromRequest<IPointToVehicleRequest>().Vehicle).Result);

            return this;
        }

        public MonitoringCommandBuilder ForIvid()
        {
            var request = new LicensePlateRequestBuilder().ForIvid();

            var queue = new MonitoirngQueueSender(DataProviderCommandSource.Ivid, _aggregateId);
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
                    new IvidRequestMessage(request.GetFromRequest<IPointToVehicleRequest>().User,
                        request.GetFromRequest<IPointToVehicleRequest>().Vehicle,
                        request.GetFromRequest<IPointToVehicleRequest>().Package.Name).HpiQueryRequest, null)
                .Error(new {NoRequestReceived = "No response received from Ivid Data Provider"}, null)
                .EndCall(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp())
                .Transform(
                    new TransformIvidResponse(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp()).Result,
                    new TransformIvidResponse(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp()))
                .EndExecution(
                    new TransformIvidResponse(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp()).Result);

            return this;
        }
    }
}
