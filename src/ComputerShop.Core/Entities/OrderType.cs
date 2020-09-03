using System.Collections.Generic;

namespace ComputerShop.Core.Entities
{
    public class OrderType
    {
        public OrderType()
        {
            Order = new HashSet<Order>();
        }

        public int TypeId { get; set; }
        public int Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}