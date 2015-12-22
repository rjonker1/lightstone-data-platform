using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Commands.Dataset
{
    public class ModifyDataExtract : Command
    {
        public ModifyDataExtract(DatabaseExtractDto databaseExtract, string modifiedBy, long version, Guid correlationId)
        {
            DatabaseExtract = databaseExtract;
            EventType = Lim.Enums.EventType.Modified.ToString();
            EventTypeId = (int) Lim.Enums.EventType.Modified;
            NewAggregate = false;
            User = modifiedBy;
            Version = version;
            CorrelationId = correlationId;
            AggregateId = databaseExtract.AggregateId;
        }

        public readonly DatabaseExtractDto DatabaseExtract;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly bool NewAggregate;
        public readonly Guid CorrelationId;
        public readonly long Version;
    }
}
