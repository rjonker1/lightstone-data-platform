using System;
using Lim;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Commands
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
        }

        public readonly DataSetDto DataSet;
        public readonly string EventType;
        public readonly int EventTypeId;
        public readonly bool NewAggregate;
        public readonly Guid User;
    }

    //public class RenameDataSetExport : Command
    //{
    //    public RenameDataSetExport(Guid id, string newName, int originalVersion)
    //    {
    //        Id = id;
    //        Name = newName;
    //        OriginalVersion = originalVersion;
    //    }

    //    public readonly Guid Id;
    //    public readonly string Name;
    //    public readonly int OriginalVersion;
    //}

    //public class DeactivateDataSet : Command
    //{

    //    public DeactivateDataSet(Guid id, int version)
    //    {
    //        Id = id;
    //        Version = version;
    //    }

    //    public readonly Guid Id;
    //    public readonly int Version;
    //}
}
