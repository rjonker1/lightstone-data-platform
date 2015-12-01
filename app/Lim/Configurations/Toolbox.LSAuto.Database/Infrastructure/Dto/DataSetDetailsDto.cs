using System;
namespace Toolbox.LightstoneAuto.Database.Infrastructure.Dto
{
    public class DataSetDetailsDto
    {
        public DataSetDetailsDto(Guid id, string name, int currentCount, int version)
        {
            Id = id;
            Name = name;
            CurrentCount = currentCount;
            Version = version;
        }

        public Guid Id;
        public string Name;
        public int CurrentCount;
        public int Version;
    }
}
