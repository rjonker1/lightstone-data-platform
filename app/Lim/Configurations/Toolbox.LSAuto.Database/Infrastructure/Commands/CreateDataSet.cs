using System;
using Toolbox.LightstoneAuto.Database.Domain.Base;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Commands
{
    public class CreateDataSet : Command
    {
        public CreateDataSet(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public readonly Guid Id;
        public readonly string Name;
    }

    public class DeactivateDataSet : Command
    {

        public DeactivateDataSet(Guid id, int version)
        {
            Id = id;
            Version = version;
        }

        public readonly Guid Id;
        public readonly int Version;
    }
}
