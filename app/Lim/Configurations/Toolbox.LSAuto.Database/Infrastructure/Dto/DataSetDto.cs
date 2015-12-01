using System;
namespace Toolbox.LightstoneAuto.Database.Infrastructure.Dto
{
    public class DataSetDto
    {
        public DataSetDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id;
        public string Name;
    }
}