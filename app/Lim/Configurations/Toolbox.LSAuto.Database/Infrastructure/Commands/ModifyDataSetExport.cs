﻿using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Commands
{
    public class ModifyDataSetExport : Command
    {
        public ModifyDataSetExport(DataSetDto dataSet, Guid modifiedBy, int version, Guid correlationId)
        {
            DataSet = dataSet;
            EventType = Lim.Enums.EventType.Modified.ToString();
            EventTypeId = (int) Lim.Enums.EventType.Modified;
            NewAggregate = false;
            User = modifiedBy;
            Version = version;
            CorrelationId = correlationId;
        }

        public readonly DataSetDto DataSet;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly bool NewAggregate;
        public readonly Guid User;
        public readonly Guid CorrelationId;
        public readonly int Version;
    }
}