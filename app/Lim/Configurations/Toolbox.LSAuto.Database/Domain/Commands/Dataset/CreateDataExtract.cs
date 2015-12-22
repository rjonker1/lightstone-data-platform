using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Commands.Dataset
{
    public class CreateDataExtract : Command
    {
        public CreateDataExtract(DatabaseExtractDto databaseExtract, string createdBy, Guid correlationId)
        {
            DatabaseExtract = databaseExtract;
            EventType = Lim.Enums.EventType.Created.ToString();
            EventTypeId = (int) Lim.Enums.EventType.Created;
            NewAggregate = true;
            User = createdBy;
            AggregateId = Guid.NewGuid();
            Type = GetType();
            CorrelationId = correlationId;
            DatabaseExtract.AggregateId = AggregateId;
        }

        public readonly DatabaseExtractDto DatabaseExtract;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly bool NewAggregate;
        public readonly Guid CorrelationId;
        public readonly Type Type;
    }
}
