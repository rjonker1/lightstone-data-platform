﻿using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Identifiers;
using EasyNetQ;
using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Messages.Commands
{
    [Queue("DataPlatform.DataProvider.Sender", ExchangeName = "DataPlatform.DataProvider.Sender")]
    [DataContract]
    public class ReceiveEntryPointRequest
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public SearchRequestIndentifier Request { get; private set; }

        [DataMember]
        public PayloadIdentifier Payload { get; private set; }
        [DataMember]
        public NoRecordBillableIdentifier BillNoRecords { get; private set; }

        public ReceiveEntryPointRequest(Guid id, Guid requestId,
            DateTime date, SearchRequestIndentifier request, PayloadIdentifier payload,NoRecordBillableIdentifier billNoRecords)
        {
            Id = id;
            Date = date;
            RequestId = requestId;
            Request = request;
            Payload = payload;
            BillNoRecords = billNoRecords;

        }
    }

    [Queue("DataPlatform.DataProvider.Sender", ExchangeName = "DataPlatform.DataProvider.Sender")]
    [DataContract]
    public class ReturnEntryPointResponse
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public StateIdentifier State { get; private set; }

        [DataMember]
        public PayloadIdentifier Payload { get; private set; }
        [DataMember]
        public SearchRequestIndentifier Request { get; private set; }
        [DataMember]
        public NoRecordBillableIdentifier BillNoRecords { get; private set; }

        public ReturnEntryPointResponse(Guid id, Guid requestId,
            DateTime date, StateIdentifier state, PayloadIdentifier payload,SearchRequestIndentifier request,NoRecordBillableIdentifier billNoRecords)
        {
            Id = id;
            Date = date;
            RequestId = requestId;
            Payload = payload;
            State = state;
            Request = request;
            BillNoRecords = billNoRecords;
        }
    }
}
