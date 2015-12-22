﻿using System;
using Lim.Domain.Events;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class DatabaseExtractModified : LimEvent
    {
        public DatabaseExtractModified(DatabaseExtractDto databaseExtract, Guid correlationId, string eventType, int eventTypeId, bool newAggregate, string user, long version, Type type)
        {
            AggregateId = databaseExtract.AggregateId;
            DatabaseExtract = databaseExtract;
            EventType = eventType;
            EventTypeId = eventTypeId;
            Type = type;
            TypeName = type.Name;
            AggregateNew = newAggregate;
            User = user;
            CorrelationId = correlationId;
            Version = version;
            DatabaseExtract.Version = version;
            //  Payload = Encoding.UTF8.GetBytes(this.ObjectToJson());

        }

        public DatabaseExtractDto DatabaseExtract { get; private set; }
    }
}
