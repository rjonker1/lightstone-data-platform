﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class BillRunConsumer
    {
        private readonly IPivotBilling<PivotStageBilling> _pivotStageBilling;
        private readonly IPivotBilling<PivotFinalBilling> _pivotFinalBilling;

        public BillRunConsumer(IPivotBilling<PivotStageBilling> pivotStageBilling, IPivotBilling<PivotFinalBilling> pivotFinalBilling)
        {
            _pivotStageBilling = pivotStageBilling;
            _pivotFinalBilling = pivotFinalBilling;
        }

        public void Consume(IMessage<BillingMessage> message)
        {
            if (message.Body.RunType == "Stage")
                _pivotStageBilling.Pivot();

            if (message.Body.RunType == "Final")
                _pivotFinalBilling.Pivot();
        }
    }
}