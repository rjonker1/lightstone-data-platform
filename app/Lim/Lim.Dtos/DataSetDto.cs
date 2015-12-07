using System;
using System.Collections.Generic;

namespace Lim.Dtos
{
    public class DataSetDto
    {
        public DataSetDto()
        {
            DataFields = new List<DataFieldDto>();
        }

        public long Id { get;set; }
        public Guid AggregateId { get; set; }
        public string Name { get;set; }
        public string Description { get;set; }
        public long Version { get;set; }
        public DateTime DateCreated { get;set; }
        public DateTime DateModified { get;set; }
        public bool Activated { get;set; }
        public List<DataFieldDto> DataFields { get; set; } 
    }
}