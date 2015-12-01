using System;
using Toolbox.LightstoneAuto.Database.Domain.Base;

namespace Toolbox.LightstoneAuto.Database.Domain.Events
{
    public class DataSetDeActivated : Event
    {
        public readonly Guid Id;

        public DataSetDeActivated(Guid id)
        {
            Id = id;
        }
    }
}
