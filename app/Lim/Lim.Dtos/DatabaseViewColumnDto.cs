using System;

namespace Lim.Dtos
{
    public class DatabaseViewColumnDto
    {
        public long Id { get; set; }
        public long DatabaseViewId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
