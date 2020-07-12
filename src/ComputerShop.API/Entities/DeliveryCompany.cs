using System.Collections;
using System.Collections.Generic;

namespace ComputerShop.API.Entities
{
    public class DeliveryCompany
    {
        public DeliveryCompany()
        {
            Delivery = new HashSet<Delivery>();
        }

        public int CompanyId { get; set; }
        public BitArray Name { get; set; }

        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}