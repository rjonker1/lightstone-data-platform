using System;
using Toolbox.LightstoneAuto.Database.Domain.Base;

namespace Toolbox.LightstoneAuto.Database.Domain.Events
{
    public class DataSetCreated : Event
    {
        public readonly Guid Id;
        public readonly string Name;

        public DataSetCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
