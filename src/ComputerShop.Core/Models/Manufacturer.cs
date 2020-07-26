using System.Collections.Generic;

namespace ComputerShop.API.Entities
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Product = new HashSet<Product>();
        }

        public int ManufactureId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}