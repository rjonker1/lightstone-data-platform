using System.Collections.Generic;

namespace Api.Domain.Core.Meta
{
    public class Menu
    {
        public IEnumerable<Product> Products { get; set; }
    }
}