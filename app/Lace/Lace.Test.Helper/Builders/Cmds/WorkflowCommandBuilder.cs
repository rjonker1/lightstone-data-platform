using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Management;
using Lace.Domain.DataProviders.Rgt.Core.Models;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Management;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Responses;
using Lace.Test.Helper.Mothers.Requests.Dto;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

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
        public readonly DataProviderStopWatch _Watch;

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
            _Watch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.EntryPoint);
        }

        public WorkflowCommandBuilder Wait()
        {
            System.Threading.Thread.Sleep(5000);
            return this;
        }

        public WorkflowCommandBuilder ForRequestReceived()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.EntryPoint);
            queue.InitQueue(_bus)
                .EntryPointRequest(new LicensePlateRequestBuilder().ForAllSources(), _Watch);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallIvid()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Ivid);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za/ivid/ws/hpiService.wsdl", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForIvid(), 15, 30)
                .ReceiveResponseFromDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za/ivid/ws/hpiService.wsdl", DataProviderAction.Response,
                    DataProviderState.Successful,
                    new TransformIvidResponse(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp()).Result,
                    15, 30);
            return this;
        }

        public WorkflowCommandBuilder ForFailedCallIvid()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Ivid);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za/ivid/ws/hpiService.wsdl", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForIvid(), 15, 30)
                .ReceiveResponseFromDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za/ivid/ws/hpiService.wsdl", DataProviderAction.Response,
                    DataProviderState.Failed, null,
                    15, 30);
            return this;
        }

        public WorkflowCommandBuilder ForIvidConfiguration()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Ivid);
            queue.InitQueue(_bus)
                .Configuration(
                    new IvidRequestMessage(
                        new LicensePlateRequestBuilder().ForIvid().GetFromRequest<IPointToVehicleRequest>())
                        .HpiQueryRequest, null);
            return this;
        }

        public WorkflowCommandBuilder ForIvidSecurity()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Ivid);
            queue.InitQueue(_bus)
                .Security(new
                {
                    Credentials =
                        new
                        {
                            UserName = "Ivid User Name",
                            Password = "This Is Some Password"
                        }
                }, new {ContextMessage = "Ivid Data Provider Credentials"});
            return this;
        }

        public WorkflowCommandBuilder ForIvidTransformation()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Ivid);
            queue.InitQueue(_bus)
                .Transformation(
                    new TransformIvidResponse(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp()).Result,
                    null);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallLightstoneAuto()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.LightstoneAuto);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForLightstoneLicensePlate(), 20, 40)
                .ReceiveResponseFromDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Successful,
                    new TransformLightstoneResponse(
                        FakeLighstoneRetrievalData.GetValuationFromMetrics(
                            new RequestCarInformationForCarHavingId107483()),
                        FakeLighstoneRetrievalData.GetCarInformation("SB1KV58E40F039277"))
                        .Result, 20, 40);
            return this;
        }

        public WorkflowCommandBuilder ForFailedCallLightstoneAuto()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.LightstoneAuto);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForLightstoneLicensePlate(), 20, 40)
                .ReceiveResponseFromDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Failed, null, 20, 40);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallRgt()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Rgt);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForRgt(), 30, 60)
                .ReceiveResponseFromDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Successful, new TransformRgtResponse(new List<CarSpecification>()), 30, 60);
            return this;
        }

        public WorkflowCommandBuilder ForFailedCallRgt()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Rgt);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForRgt(), 30, 60)
                .ReceiveResponseFromDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Failed, null, 30, 60);
            return this;
        }


        public WorkflowCommandBuilder ForSuccessfulCallRgtVin()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.RgtVin);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForRgtVin(), 25, 50)
                .ReceiveResponseFromDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Successful,
                    new TransformRgtVinResponse(FakeRgtVinResponse.GetRgtVinResponseForLicensePlateNumber()), 25, 50);
            return this;
        }

        public WorkflowCommandBuilder ForFailedCallRgtVin()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.RgtVin);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForRgtVin(), 25, 50)
                .ReceiveResponseFromDataProvider("Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Failed, null, 25, 50);
            return this;
        }

        //public WorkflowCommandBuilder ForSuccessfulCallAudatex()
        //{
        //    var queue = new WorkflowQueueSender(DataProviderCommandSource.Audatex);
        //    queue.InitQueue(_bus)
        //        .SendRequestToDataProvider("Web Service",
        //            "https://mobile.za.ax-aee.co.uk/audabridge/backofficeservice.asmx", DataProviderAction.Request,
        //            DataProviderState.Successful, new LicensePlateRequestBuilder().ForAudatex(), 0, 0)
        //        .ReceiveResponseFromDataProvider("Web Service",
        //            "https://mobile.za.ax-aee.co.uk/audabridge/backofficeservice.asmx", DataProviderAction.Response,
        //            DataProviderState.Successful,
        //            new TransformAudatexResponse(new SourceResponseBuilder().ForAudatexWithHuyandaiHistory(),
        //                new SourceResponseBuilder().ForAudatexWithLaceResponse(),
        //                new LicensePlateRequestBuilder().ForAudatex().GetFromRequest<IPointToVehicleRequest>().Vehicle),
        //            0, 0);
        //    return this;
        //}

        public WorkflowCommandBuilder ForSuccessfulCallToIvidTitleHolder()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.IvidTitleHolder);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za:443/ivid/ws/", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForIvidTitleHolder(), 35, 70)
                .ReceiveResponseFromDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za:443/ivid/ws/", DataProviderAction.Response,
                    DataProviderState.Successful,
                    new TransformIvidTitleHolderResponse(
                        FakeIvidTitleHolderQueryResponseData.GetTitleHolderResponseForLicenseNumber()), 35, 70);
            return this;
        }

        public WorkflowCommandBuilder ForFailedCallToIvidTitleHolder()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.IvidTitleHolder);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za:443/ivid/ws/", DataProviderAction.Request,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForIvidTitleHolder(), 35, 70)
                .ReceiveResponseFromDataProvider("Web Service",
                    "https://secure1.ubiquitech.co.za:443/ivid/ws/", DataProviderAction.Response,
                    DataProviderState.Failed, null, 35, 70);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulResponseToCaller()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.EntryPoint);
            queue.InitQueue(_bus)
                .EntryPointResponse(
                    new TransformIvidResponse(FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp()).Result,
                    DataProviderState.Successful, new LicensePlateRequestBuilder().ForAllSources(), _Watch)
                .CreateTransaction(_packageId, _packageVersion, _userId, _requestId, _contractId, _system,
                    0, DataProviderState.Successful, _accountNumber);
            return this;
        }

        public WorkflowCommandBuilder ForFailedResponseToCaller()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.EntryPoint);
            queue.InitQueue(_bus)
                .EntryPointResponse(
                    new List<IPointToLaceProvider>(),
                    DataProviderState.Failed, new LicensePlateRequestBuilder().ForAllSources(), _Watch);

            return this;
        }
    }
}
