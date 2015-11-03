using System.Collections.Generic;

namespace Cradle.KeepAlive.Service.Domain.Dtos
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public IEnumerable<SubMenuDto> SubMenus { get; set; }
    }
}