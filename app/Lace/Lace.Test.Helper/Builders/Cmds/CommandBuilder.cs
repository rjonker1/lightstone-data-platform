using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Fakes.Responses;

namespace Lace.Test.Helper.Builders.Cmds
{
    public class CommandBuilder
    {
        private readonly Guid _aggregateId;

        public CommandBuilder(Guid aggregateId)
        {
            _aggregateId = aggregateId;
        }


        public CommandBuilder ForAudatex()
        {
            var queue = new QueueSender(DataProviderCommandSource.Audatex, _aggregateId);
            queue.InitQueue(BusBuilder.ForAudatexCommands(_aggregateId))
                .InitStopWatch()
                .StartingExecution(new LicensePlateRequestBuilder().ForAudatex())
                .Configuration(
                    new ConfigureAudatexRequestMessage(new LaceResponseBuilder().WithIvidResponseHandled()).Build()
                        .AudatexRequest, null)
                .StartCall(
                    new ConfigureAudatexRequestMessage(new LaceResponseBuilder().WithIvidResponseHandled()).Build()
                        .AudatexRequest, null)
                .Error(new {NoRequestReceived = "No response received from Audatex Data Provider"}, null)
                .EndCall(FakeAudatexWebResponseData.GetAudatextWebServiceResponse())
                .Transform(
                    new TransformAudatexResponse(FakeAudatexWebResponseData.GetAudatextWebServiceResponse(),
                        new LaceResponseBuilder().WithIvidResponseHandled(),
                        new LicensePlateRequestBuilder().ForAudatex()).Result,
                    new TransformAudatexResponse(FakeAudatexWebResponseData.GetAudatextWebServiceResponse(),
                        new LaceResponseBuilder().WithIvidResponseHandled(),
                        new LicensePlateRequestBuilder().ForAudatex()))
                .EndExecution(
                    new TransformAudatexResponse(FakeAudatexWebResponseData.GetAudatextWebServiceResponse(),
                        new LaceResponseBuilder().WithIvidResponseHandled(),
                        new LicensePlateRequestBuilder().ForAudatex()).Result);

            return this;
        }

        public CommandBuilder ForIvid()
        {
            var queue = new QueueSender(DataProviderCommandSource.Ivid, _aggregateId);
            queue.InitQueue(BusBuilder.ForIvidCommands(_aggregateId))
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
                    new IvidRequestMessage(new LicensePlateRequestBuilder().ForIvid()).HpiQueryRequest, null)
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
