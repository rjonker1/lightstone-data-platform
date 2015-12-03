using System;
using Lim;

namespace Toolbox.LightstoneAuto.Database.Domain.Events
{
    public class DataSetDeActivated : LimEvent
    {
        public readonly Guid Id;

        public DataSetDeActivated(Guid id)
        {
            Id = id;
        }
    }
}