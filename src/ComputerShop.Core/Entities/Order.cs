using System;
using System.Collections.Generic;

namespace ComputerShop.Core.Entities
{
    public class Order
    {
        public Order()
        {
            Delivery = new HashSet<Delivery>();
        }

        public int OrderId { get; set; }
        public string UserId { get; set; }
        public int TypeId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public virtual OrderType Type { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}