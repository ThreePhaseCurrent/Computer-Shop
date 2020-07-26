using System.Collections.Generic;

namespace ComputerShop.API.Entities
{
    public class Product
    {
        public Product()
        {
            Discount = new HashSet<Discount>();
            UserDevice = new HashSet<UserDevice>();
        }

        public int PriductId { get; set; }
        public string ProductImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public string ShortDescription { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public int? DiscountId { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual Discount DiscountNavigation { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Discount> Discount { get; set; }
        public virtual ICollection<UserDevice> UserDevice { get; set; }
    }
}