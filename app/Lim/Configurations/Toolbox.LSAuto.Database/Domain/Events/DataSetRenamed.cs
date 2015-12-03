using System;
using Lim;

namespace Toolbox.LightstoneAuto.Database.Domain.Events
{
    public class DataSetRenamed : LimEvent
    {
        public DataSetRenamed(Guid id, string newName)
        {
            Id = id;
            NewName = newName;
        }

        public readonly Guid Id;
        public readonly string NewName;
    }
}
