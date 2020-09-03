using System.Collections.Generic;

namespace ComputerShop.Core.Entities
{
    public class Discount
        {
            public Discount()
            {
                ProductNavigation = new HashSet<Product>();
            }

            public int DiscountId { get; set; }
            public int ProductId { get; set; }
            public decimal Value { get; set; }

            public virtual Product Product { get; set; }
            public virtual ICollection<Product> ProductNavigation { get; set; }
    }
}