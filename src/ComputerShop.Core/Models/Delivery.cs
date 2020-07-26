using System.Collections;

namespace ComputerShop.API.Entities
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int OrderId { get; set; }
        public int CompanyId { get; set; }
        public BitArray Delivered { get; set; }

        public virtual DeliveryCompany Company { get; set; }
        public virtual Order Order { get; set; }
    }
}