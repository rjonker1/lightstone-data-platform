using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Commands.Dataset
{
    public class CreateDataSetExport : Command
    {
        public CreateDataSetExport(DataSetDto dataSet, Guid createdBy)
        {
            DataSet = dataSet;
            EventType = Lim.Enums.EventType.Created.ToString();
            EventTypeId = (int) Lim.Enums.EventType.Created;
            NewAggregate = true;
            User = createdBy;
            AggregateId = Guid.NewGuid();
            Type = GetType();
        }

        public readonly DataSetDto DataSet;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly bool NewAggregate;
        public readonly Type Type;
    }
}
