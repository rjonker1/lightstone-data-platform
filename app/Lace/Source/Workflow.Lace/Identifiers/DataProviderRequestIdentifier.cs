﻿using System;
using DataPlatform.Shared.Identifiers;

namespace Workflow.Lace.Identifiers
{
    public class DataProviderRequestIdentifier
    {
        public DataProviderRequestIdentifier()
        {
            
        }

        public DataProviderRequestIdentifier(Guid id, Guid streamId, DateTime date, RequestIdentifier parentRequest, DataProviderIdentifier dataProvider, DataProviderConnectionTypeIdentifier connectionType)
        {
            Id = id;
            StreamId = streamId;
            Date = date;
            ParentRequest = parentRequest;
            DataProvider = dataProvider;
            ConnectionType = connectionType;
        }

        public Guid Id { get; private set; }
        public Guid StreamId { get; private set; }
        public DateTime Date { get; private set; }
        public RequestIdentifier ParentRequest { get; set; }
        public DataProviderIdentifier DataProvider { get; set; }
        public DataProviderConnectionTypeIdentifier ConnectionType { get; set; }
    }
}
