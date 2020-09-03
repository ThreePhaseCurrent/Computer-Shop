namespace ComputerShop.Core.Entities
{
    public class OrderList
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? DiskontId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}