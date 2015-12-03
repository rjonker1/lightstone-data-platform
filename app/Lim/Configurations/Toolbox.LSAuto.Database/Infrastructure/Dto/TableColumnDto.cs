using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Dto
{
    public class TableColumnDto
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
