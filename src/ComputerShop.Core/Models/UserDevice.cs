using ComputerShop.API.Data;

namespace ComputerShop.API.Entities
{
    public class UserDevice
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? ProductId { get; set; }
        public string CustomName { get; set; }
        public int CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}