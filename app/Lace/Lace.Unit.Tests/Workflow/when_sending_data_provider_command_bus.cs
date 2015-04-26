﻿using System;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Mothers.Requests;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Commands;
using Workflow.Lace.Messages.Infrastructure;
using Workflow.Lace.Messages.Shared;
using Xunit.Extensions;
using BusFactory = Workflow.BuildingBlocks.BusFactory;

namespace Lace.Unit.Tests.Workflow
{
    public class when_sending_data_provider_command_bus : Specification
    {
        private readonly SendRequestToDataProviderCommand _command;
        private readonly IAdvancedBus _bus;
        private Exception _exception;


        public when_sending_data_provider_command_bus()
        {
            _command = new SendRequestToDataProviderCommand(Guid.NewGuid(), Guid.NewGuid(),
                new DataProviderIdentifier((int) DataProviderCommandSource.Ivid,
                    DataProviderCommandSource.Ivid.ToString(), 55, 100,
                    DataProviderAction.Request, DataProviderState.Successful), DateTime.UtcNow,
                new ConnectionTypeIdentifier("test"),
                new PayloadIdentifier(new MetadataContainer().ObjectToJson(),
                    new IvidRequestMessage(new LicensePlateNumberIvidOnlyRequest()).ObjectToJson(),
                    "testing message to bus"));
            _bus = BusFactory.CreateAdvancedBus("workflow/dataprovider/queue");
        }

        public override void Observe()
        {
            try
            {
                new WorkflowCommandPublisher(_bus).SendToBus(_command);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Observation]
        public void then_message_should_be_published_to_bus()
        {
            _exception.ShouldBeNull();
        }
    }
}
