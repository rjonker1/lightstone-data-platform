using System;
using System.Collections.Generic;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Dto
{
    public class DataSetDto
    {
        public DataSetDto()
        {
            DataFields = new List<DataFieldDto>();
        }

        public Guid Id { get;set; }
        public string Name { get;set; }
        public string Description { get;set; }
        public long Version { get;set; }
        public DateTime DateCreated { get;set; }
        public DateTime DateModified { get;set; }
        public bool Activated { get;set; }

        public List<DataFieldDto> DataFields { get; set; } 

        //public DataSetDto(Guid id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}
        //public Guid Id;
        //public string Name;
    }
}