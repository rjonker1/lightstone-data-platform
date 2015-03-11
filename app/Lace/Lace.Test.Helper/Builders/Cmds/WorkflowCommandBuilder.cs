using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Responses;

namespace Lace.Test.Helper.Builders.Cmds
{
    public class WorkflowCommandBuilder
    {
        private readonly Guid _requestId;

        public WorkflowCommandBuilder(Guid requestId)
        {
            _requestId = requestId;
        }

        public WorkflowCommandBuilder ForIvid()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Ivid);
            queue.InitQueue(WorkflowBusBuilder.ForIvid(_requestId))
                .ReceiveRequest(DateTime.Now)
                .SendRequestToDataProvider(DateTime.Now,
                    new IvidRequestMessage(new LicensePlateRequestBuilder().ForIvid()).HpiQueryRequest,
                    "(TEST)Web Service", "https://secure1.ubiquitech.co.za:443/ivid/ws/")
                .ReceiveResponseFromDataProvider(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp(),
                    DateTime.Now)
                .ReturnResponse(DateTime.Now, new TransformIvidResponse(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp()).Result);
            return this;
        }
    }
}
