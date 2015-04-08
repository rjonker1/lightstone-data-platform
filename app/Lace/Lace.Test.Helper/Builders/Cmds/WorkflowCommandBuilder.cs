using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Management;
using Lace.Domain.DataProviders.Rgt.Core.Models;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Management;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Fakes.Lace.Consumer;
using Lace.Test.Helper.Fakes.Responses;
using Lace.Test.Helper.Mothers.Requests.Dto;
using Microsoft.SqlServer.Server;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Builders.Cmds
{
    public class WorkflowCommandBuilder
    {
        private readonly Guid _requestId;
        private readonly ISendWorkflowCommand _bus;
        private readonly Guid _packageId;
        private readonly Guid _contractId;
        private readonly Guid _userId;
        private readonly string _accountNumber;
        private readonly long _packageVersion;
        private readonly string _system;

        public WorkflowCommandBuilder(ISendWorkflowCommand bus, Guid packageId, Guid contractId, Guid userId,
            long packageVersion, Guid requestId, string system, string accountNumber)
        {
            _requestId = requestId;
            _bus = bus;
            _packageId = packageId;
            _contractId = contractId;
            _userId = userId;
            _packageVersion = packageVersion;
            _system = system;
            _accountNumber = accountNumber;
        }

        public WorkflowCommandBuilder ForRequestReceived()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.EntryPoint);
            queue.InitQueue(_bus)
                .ReceiveResponseFromDataProvider("Lace",
                    "none", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForAllSources());
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallIvid()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Ivid);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za/ivid/ws/hpiService.wsdl", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForIvid())
                .ReceiveResponseFromDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za/ivid/ws/hpiService.wsdl", DataProviderAction.Response,
                    DataProviderState.Successful,
                    new TransformIvidResponse(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp()).Result);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallLightstoneAuto()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.LightstoneAuto);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForLightstone())
                .ReceiveResponseFromDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Successful,
                    new TransformLightstoneResponse(
                        FakeLighstoneRetrievalData.GetValuationFromMetrics(
                            new RequestCarInformationForCarHavingId107483()),
                        FakeLighstoneRetrievalData.GetCarInformation(new LicensePlateRequestBuilder().ForLightstone()))
                        .Result);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallRgt()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Rgt);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForRgt())
                .ReceiveResponseFromDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Successful, new TransformRgtResponse(new List<CarSpecification>()));
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallRgtVin()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.RgtVin);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForRgtVin())
                .ReceiveResponseFromDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Successful,
                    new TransformRgtVinResponse(FakeRgtVinResponse.GetRgtVinResponseForLicensePlateNumber()));
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallAudatex()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Audatex);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Web Service",
                    "https://mobile.za.ax-aee.co.uk/audabridge/backofficeservice.asmx", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForAudatex())
                .ReceiveResponseFromDataProvider("Web Service",
                    "https://mobile.za.ax-aee.co.uk/audabridge/backofficeservice.asmx", DataProviderAction.Response,
                    DataProviderState.Successful,
                    new TransformAudatexResponse(new SourceResponseBuilder().ForAudatexWithHuyandaiHistory(),
                        new SourceResponseBuilder().ForAudatexWithLaceResponse(),
                        new LicensePlateRequestBuilder().ForAudatex().GetFromRequest<IPointToVehicleRequest>().Vehicle));
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallToIvidTitleHolder()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.IvidTitleHolder);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za:443/ivid/ws/", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForIvidTitleHolder())
                .ReceiveResponseFromDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za:443/ivid/ws/", DataProviderAction.Response,
                    DataProviderState.Successful,
                    new TransformIvidTitleHolderResponse(
                        FakeIvidTitleHolderQueryResponseData.GetTitleHolderResponseForLicenseNumber()));
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulResponseToCaller()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.EntryPoint);
            queue.InitQueue(_bus)
                .ReceiveResponseFromDataProvider("Lace",
                    "none", DataProviderAction.Response,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForAllSources())
                .CreateTransaction(_packageId, _packageVersion, _userId, _requestId, _contractId, _system,
                    0, DataProviderState.Successful, _accountNumber);
            return this;
        }
    }
}
