using System;
using System.Collections.Generic;
using Lim.Enums;

namespace Lim.Dtos
{
    public class DatabaseExtractDto
    {
        public DatabaseExtractDto()
        {
            Fields = new List<DatabaseExtractFieldDto>();
            Source = Source.CodeIntiated;
        }

        public long Id { get; set; }
        public long ViewId { get; set; }
        public Guid AggregateId { get;set; }
        public string Name { get;set; }
        public string Description { get;set; }
        public long Version { get;set; }
        public DateTime DateCreated { get;set; }
        public DateTime DateModified { get;set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool Activated { get;set; }
        public List<DatabaseExtractFieldDto> Fields { get; set; }
        public int FieldCount { get; set; }
        public Source Source { get; set; }
    }
}