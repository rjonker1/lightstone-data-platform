using System.Collections.Generic;

namespace Api.Domain.Core.Meta
{
    public class Product
    {
        public string ProductName { get; set; }
        public IEnumerable<SubMenu> SubMenus { get; set; }
    }
}