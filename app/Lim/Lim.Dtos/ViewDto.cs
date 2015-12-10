using System;
using System.Collections.Generic;

namespace Lim.Dtos
{
    public class ViewDto
    {
        public ViewDto()
        {
            ViewColumns = new List<ViewColumnDto>();
        }

        public long Id { get; set; }
        public Guid AggregateId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Activated { get; set; }
        public long Version { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid CreatedBy { get; set; }
        public List<ViewColumnDto> ViewColumns { get; set; } 
    }
}